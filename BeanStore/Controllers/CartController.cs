using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeanStore.Models;
namespace BeanStore.Controllers
{
    public class CartController : Controller
    {
        dbBeanDataContext data = new dbBeanDataContext();
        public List<Cart> GetCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }
        public ActionResult AddCart(int cId, string strURL)
        {
            List<Cart> lstCart = GetCart();
            Cart ite = lstCart.Find(n => n.cId == cId);
            if (ite == null)
            {
                ite = new Cart(cId);
                lstCart.Add(ite);
                return Redirect(strURL);
            }
            else
            {
                ite.cQuantity++;
                return Redirect(strURL);
            }
        }
        public ActionResult Cart()
        {
            List<Cart> lstCart = GetCart();
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Bean");
            }
            ViewBag.totalQuantity = totalQuantity();
            ViewBag.totalPrice = totalPrice();
            return View(lstCart);
        }
        private int totalQuantity()
        {
            int cTotalQuantity = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                cTotalQuantity = lstCart.Sum(n => n.cQuantity);
            }
            return cTotalQuantity;
        }
        private double totalPrice()
        {
            double cTotalPrice = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                cTotalPrice = lstCart.Sum(n => n.cAmount);
            }
            return cTotalPrice;
        }
        public ActionResult CartPartial()
        {
            List<Cart> lstCart = GetCart();
            if (lstCart.Count == 0)
            {
                ViewBag.cartempty = true;
            }
            ViewBag.totalQuantity = totalQuantity();
            return PartialView(lstCart);
        }
        public ActionResult UpdateCart(int cId, FormCollection frm)
        {
            List<Cart> lstCart = GetCart();
            Cart ite = lstCart.SingleOrDefault(n => n.cId == cId);
            if (ite != null)
            {
                ite.cQuantity = int.Parse(frm["txtQuantity"].ToString());
            }
            return RedirectToAction("Cart");
        }
        public ActionResult DeleteCart(int cId)
        {
            List<Cart> lstCart = GetCart();
            Cart ite = lstCart.SingleOrDefault(n => n.cId == cId);
            if (ite != null)
            {
                lstCart.RemoveAll(n => n.cId == cId);
                return RedirectToAction("Cart");

            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Bean");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult DeleteAllCart()
        {
            List<Cart> lstCart = GetCart();
            lstCart.Clear();
            return RedirectToAction("Index", "Bean");
        }
        [HttpGet]
        public ActionResult Order()
        {
            if (Session["UserAccount"] == null || Session["UserAccount"].ToString() == "")
            {
                return RedirectToAction("Login", "User");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Bean");
            }
            List<Cart> lstCart = GetCart();
            ViewBag.totalQuantity = totalQuantity();
            ViewBag.totalPrice = totalPrice();
            return View(lstCart);
        }
        [HttpPost]
        public ActionResult Order(FormCollection collection)
        {
            order ord = new order();
            user use = (user)Session["UserAccount"];
            List<Cart> cart = GetCart();
            ord.user_id = use.id;
            ord.order_date = DateTime.Today;
            ord.status_id = 1;
            data.orders.InsertOnSubmit(ord);
            data.SubmitChanges();   
            foreach (var item in cart)
            {
                det_order d_ord = new det_order();
                d_ord.order_id = ord.id;
                d_ord.item_id = item.cId;
                d_ord.quantity = item.cQuantity;
                d_ord.amount = (int)item.cAmount;
                data.det_orders.InsertOnSubmit(d_ord);
            }
            data.SubmitChanges();
            Session["Cart"] = null;
            return RedirectToAction("Order_confirmation", "Cart");
        }
        public ActionResult Order_confirmation()
        {
            return View();
        }
    }
}