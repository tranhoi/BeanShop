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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register_Success()
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
                ViewBag.Notification = use.name;
            }
            else
            {
                ViewBag.Notification = null;
            }
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session.Remove("UserAccount");
            return RedirectToAction("Index", "Bean");
        }
    }
}