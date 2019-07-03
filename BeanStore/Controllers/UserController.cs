using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeanStore.Models;

namespace BeanStore.Controllers
{
    public class UserController : Controller
    {
        dbBeanDataContext data = new dbBeanDataContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user use, FormCollection collection)
        {
            var email = collection["Email"];
            //----------------
            user Use_email = data.users.SingleOrDefault(n => n.email == email);
            //----------------
            if (Use_email != null)
            { ViewBag.Notification = "Email already exists !!!"; }
            else
            {
                if (ModelState.IsValid)
                {
                    data.users.InsertOnSubmit(use);
                    data.SubmitChanges();
                    return RedirectToAction("Register_Success", "User");
                }
            }
            //----------------
            return View(use);
        }
        public ActionResult Register_Success()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var email = collection["Email"];
            var pass = collection["Pass"];
            //----------------
            user Use_email = data.users.SingleOrDefault(n => n.email == email);
            //----------------
            if (Use_email == null)
            { ViewBag.Notification = "Email does not exist !!!"; }
            else
            {
                user use = data.users.SingleOrDefault(n => n.email == email && n.password == pass);
                if (use != null)
                {
                    Session["UserAccount"] = use;
                    return RedirectToAction("Index", "Bean");
                }
                else
                { ViewBag.Notification = "Incorrect password !!!"; }

            }
            //----------------
            return View();
        }
        public PartialViewResult Account()
        {
            user use = (user)Session["UserAccount"];
            if (Session["UserAccount"] != null)
            {
                ViewBag.User_name = use.name;
            }
            else
            {
                ViewBag.User_name = null;
            }
            return PartialView();
        }
        public ActionResult MyAccount()
        {
            user users = (user)Session["UserAccount"];
            user use = data.users.SingleOrDefault(n => n.id == users.id);
            return View(use);
        }
        public ActionResult Total_price(int id)
        {
            int? TotalPrice = data.det_orders.Where(or => or.order_id == id).Sum(od => (od.quantity * od.amount));
            ViewBag.TotalPrice = TotalPrice;
            return PartialView();
        }
        public PartialViewResult Order()
        {
            user users = (user)Session["UserAccount"];
            var ord = from orders in data.orders
                      where orders.user_id == users.id
                      select orders;
            if (ord == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //return data.orders.OrderByDescending(a => a.order_date).Where(or => or.user_id == users.id).ToList();
            return PartialView(ord);
        }
        public PartialViewResult DetOrderPart(int id)
        {
            var detor = from detord in data.det_orders
                        where detord.order_id == id
                        select detord;
            return PartialView(detor);
        }
        public ActionResult Det_Order(int id)
        {
            order ord = data.orders.SingleOrDefault(n => n.id == id);
            if (ord == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ord);
        }
        public PartialViewResult Det_Orders(int id)
        {
            var detor = from detord in data.det_orders
                        where detord.order_id == id
                        select detord;
            return PartialView(detor);
        }
        [HttpGet]
        public ActionResult Edit_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(use);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_user(user users, FormCollection collection)
        {
            user use = data.users.First(n => n.id == users.id);
            if (ModelState.IsValid)
            {
                use.name = collection["name"];
                UpdateModel(use);
                data.SubmitChanges();
                ViewBag.Notification = "Updated your information";
                return RedirectToAction("MyAccount");
            }
            return this.Edit_user(use.id);
        }
        [HttpGet]
        public ActionResult Change_pass()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Change_pass(FormCollection collection)
        {
            if (Session["UserAccount"] == null)
            {
                return RedirectToAction("Login");
            }
            user users = (user)Session["UserAccount"];
            user use = data.users.SingleOrDefault(n => n.id == users.id);
            var pass1 = use.password;
            var pass2 = collection["old_password"];
            var pass3 = collection["new_password"];
            if (Equals(pass1, pass2) == true)
            {
                use.password = pass3;
                UpdateModel(use);
                data.SubmitChanges();
                ViewBag.Notification = 1;
                Session.Remove("UserAccount");
                return this.Change_pass();
            }
            ViewBag.Notification = 0;
            return this.Change_pass();
        }
        [HttpGet]
        public ActionResult Forgot_pass()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Forgot_pass(FormCollection collection)
        {
            var email = collection["email"];
            user use = data.users.SingleOrDefault(n => n.email == email);
            if (use == null)
            {
                ViewBag.Notification = 0;
                return this.Forgot_pass();
            }
            use.password = collection["password"];
            UpdateModel(use);
            data.SubmitChanges();
            ViewBag.Notification = 1;
            Session.Remove("UserAccount");
            return this.Forgot_pass();
        }
        public ActionResult Logout()
        {
            Session.Remove("UserAccount");
            return RedirectToAction("Index", "Bean");
        }
    }
}