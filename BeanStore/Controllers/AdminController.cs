using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BeanStore.Models;
using PagedList;
using PagedList.Mvc;
namespace BeanStore.Controllers
{
    public class AdminController : Controller
    {
        dbBeanDataContext data = new dbBeanDataContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var pass = collection["pass"];
            admin adm = data.admins.SingleOrDefault(n => n.username == username && n.password == pass);
            if (adm != null)
            {
                Session["AdminAccount"] = adm;
                return RedirectToAction("Admin_Index", "Admin");
            }
            else
                ViewBag.Notification = "error";
            return View();
        }
        public ActionResult Admin_Index()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.User_name = adm.name;
                ViewBag.User_position = adm.position.name;
                ViewBag.User_position_id = adm.position_id;
            }
            return PartialView();
        }
        public PartialViewResult Account()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] != null)
            {
                ViewBag.User_name = adm.name;
                ViewBag.User_position = adm.position.name;
            }
            else
            {
                ViewBag.User_name = null;
            }
            return PartialView();
        }
        public PartialViewResult Function()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] != null)
            {
                ViewBag.User_position_id = adm.position_id;
            }
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session.Remove("AdminAccount");
            return RedirectToAction("Login", "Admin");
        }
        public ActionResult Items(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.items.ToList().OrderBy(n => n.created).ToPagedList(pageNumber, pageSize));
                }
                var item = from ite in data.items where ite.name.ToUpper().Contains(key.ToUpper()) || ite.brand.name.ToUpper().Contains(key.ToUpper()) || ite.catalog.name.ToUpper().Contains(key.ToUpper()) select ite;
                if (item.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.items.ToList().OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
                }
                return View(item.OrderByDescending(n => n.created).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult Admins(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.admins.ToList().ToPagedList(pageNumber, pageSize));
                }
                var admin = from adminss in data.admins where adminss.name.ToUpper().Contains(key.ToUpper()) || adminss.username.ToUpper().Contains(key.ToUpper()) || adminss.position.name.ToUpper().Contains(key.ToUpper()) select adminss;
                if (admin.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.admins.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                return View(admin.OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult Users(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.users.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                var user = from use in data.users where use.name.ToUpper().Contains(key.ToUpper()) || use.email.ToUpper().Contains(key.ToUpper()) select use;
                if (user.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.users.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
                }
                return View(user.OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpGet]
        public ActionResult Created_admin()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
                return View();
            }
        }
        [HttpPost]
        public ActionResult Created_admin(admin adm)
        {
            if (ModelState.IsValid)
            {
                data.admins.InsertOnSubmit(adm);
                data.SubmitChanges();
            }
            return RedirectToAction("Admins");
        }
        public ActionResult Banner()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.banners.ToList().OrderByDescending(n => n.id));
            }
        }
        public ActionResult Brand(FormCollection collection)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.brands.ToList().OrderBy(n => n.id));
                }
                var brand = from bra in data.brands where bra.name.ToUpper().Contains(key.ToUpper()) select bra;
                if (brand.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.brands.ToList().OrderBy(n => n.id));
                }
                return View(brand.OrderBy(n => n.id));
            }
        }
        public ActionResult Catalog()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(data.catalogs.ToList().OrderBy(n => n.id));
            }
        }
        [HttpGet]
        public ActionResult Create_Items()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");
                ViewBag.TimeNow = DateTime.Now;
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Items(item item, FormCollection collection, HttpPostedFileBase fileUpload, HttpPostedFileBase fileUpload2, HttpPostedFileBase fileUpload3, HttpPostedFileBase fileUpload4, HttpPostedFileBase fileUpload5)
        {
            ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");

            if (fileUpload == null)
            {
                ViewBag.Notification = "Please select the cover photo";
                return View();
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var dedescription = collection["description"];
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images_product"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "Image already exists";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    item.image_link = fileName;
                    if (fileUpload2 != null)
                    {
                        var fileName2 = Path.GetFileName(fileUpload2.FileName);
                        item.image_link2 = fileName2;
                    }
                    if (fileUpload3 != null)
                    {
                        var fileName3 = Path.GetFileName(fileUpload3.FileName);
                        item.image_link3 = fileName3;
                    }
                    if (fileUpload4 != null)
                    {
                        var fileName4 = Path.GetFileName(fileUpload4.FileName);
                        item.image_link4 = fileName4;
                    }
                    if (fileUpload5 != null)
                    {
                        var fileName5 = Path.GetFileName(fileUpload5.FileName);
                        item.image_link5 = fileName5;
                    }
                    item.description = dedescription;
                    item.created = DateTime.Today;
                    data.items.InsertOnSubmit(item);
                    data.SubmitChanges();
                }
                return RedirectToAction("Items");
            }
        }
        public ActionResult Details_product(int id)
        {
                item ite = data.items.SingleOrDefault(n => n.id == id);
                ViewBag.id_items = ite.id;
                if (ite == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                return View(ite);
        }
        [HttpGet]
        public ActionResult Delete_product(int id)
        {
            item item = data.items.SingleOrDefault(n => n.id == id);
            ViewBag.Items_id = item.id;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete_product")]
        public ActionResult Confirm_deletion(int id)
        {
            item item = data.items.SingleOrDefault(n => n.id == id);
            ViewBag.Items_id = item.id;
            if (item == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.items.DeleteOnSubmit(item);
            data.SubmitChanges();
            return RedirectToAction("Items");
        }
        [HttpGet]
        public ActionResult Edit_product(int id)
        {
            item ite = data.items.SingleOrDefault(n => n.id == id);
            if (ite == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Created = ite.created;
            ViewBag.Items_id = ite.id;
            return View(ite);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_product(item items, FormCollection collection)
        {
            ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");
            item ite = data.items.First(n => n.id == items.id);
            if (ModelState.IsValid)
            {
                var dedescription = collection["description"];
                ite.created = DateTime.Now;
                ite.description = dedescription;
                UpdateModel(ite);
                data.SubmitChanges();
                return RedirectToAction("Items");
            }
            return this.Edit_product(ite.id);
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
            ViewBag.User_id = use.id;
            return View(use);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_user(user users)
        {
            user use = data.users.First(n => n.id == users.id);
            if (ModelState.IsValid)
            {
                UpdateModel(use);
                data.SubmitChanges();
                return RedirectToAction("Users");
            }
            return this.Edit_user(use.id);
        }
        [HttpGet]
        public ActionResult Edit_admin(int id)
        {
            ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Admin_id = adm.id;
            return View(adm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_admin(admin admins)
        {
            ViewBag.Position_id = new SelectList(data.positions.ToList().OrderBy(n => n.name), "id", "name");
            admin adm = data.admins.First(n => n.id == admins.id);
            if (ModelState.IsValid)
            {
                UpdateModel(adm);
                data.SubmitChanges();
                return RedirectToAction("Admins");
            }
            return this.Edit_admin(adm.id);
        }
        [HttpGet]
        public ActionResult Inset_banner()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Inset_banner(banner bann, HttpPostedFileBase bannerUpload)
        {
            if (bannerUpload == null)
            {
                ViewBag.Notification = "Please select the banner";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(bannerUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images_banner"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "banner already exists";
                    else
                    {
                        bannerUpload.SaveAs(path);
                    }
                    bann.banner_link = fileName;
                    data.banners.InsertOnSubmit(bann);
                    data.SubmitChanges();
                }
                return RedirectToAction("Banner");
            }
        }
        public ActionResult Delete_banner(int id)
        {
            banner bann = data.banners.SingleOrDefault(n => n.id == id);
            if (bann == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.banners.DeleteOnSubmit(bann);
            data.SubmitChanges();
            return RedirectToAction("Banner");
        }
        public ActionResult Delete_brand(int id)
        {
            brand bra = data.brands.SingleOrDefault(n => n.id == id);
            if (bra == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.brands.DeleteOnSubmit(bra);
            data.SubmitChanges();
            return RedirectToAction("Brand");
        }
        public ActionResult Delete_catalog(int id)
        {
            catalog cata = data.catalogs.SingleOrDefault(n => n.id == id);
            if (cata == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.catalogs.DeleteOnSubmit(cata);
            data.SubmitChanges();
            return RedirectToAction("Catalog");
        }
        [HttpGet]
        public ActionResult Inset_brand()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Inset_brand(brand bra, HttpPostedFileBase braUpload)
        {
            if (braUpload == null)
            {
                ViewBag.Notification = "Please select the logo";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(braUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images_logo"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Notification = "logo already exists";
                    else
                    {
                        braUpload.SaveAs(path);
                    }
                    bra.logo = fileName;
                    data.brands.InsertOnSubmit(bra);
                    data.SubmitChanges();
                }
                return RedirectToAction("Brand");
            }
        }
        [HttpGet]
        public ActionResult Inset_catalog()
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Inset_catalog(catalog cata)
        {
            if (ModelState.IsValid)
            {
                data.catalogs.InsertOnSubmit(cata);
                data.SubmitChanges();
            }
            return RedirectToAction("Catalog");
        }
        [HttpGet]
        public ActionResult Delete_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            ViewBag.Users_id = use.id;
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(use);
        }

        [HttpPost, ActionName("Delete_user")]
        public ActionResult Confirm_deletion_user(int id)
        {
            user use = data.users.SingleOrDefault(n => n.id == id);
            ViewBag.Users_id = use.id;
            if (use == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.users.DeleteOnSubmit(use);
            data.SubmitChanges();
            return RedirectToAction("Users");
        }
        [HttpGet]
        public ActionResult Delete_admin(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            ViewBag.Admins_id = adm.id;
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(adm);
        }

        [HttpPost, ActionName("Delete_admin")]
        public ActionResult Confirm_deletion_admin(int id)
        {
            admin adm = data.admins.SingleOrDefault(n => n.id == id);
            ViewBag.Admins_id = adm.id;
            if (adm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.admins.DeleteOnSubmit(adm);
            data.SubmitChanges();
            return RedirectToAction("Admins");
        }
        public ActionResult Messenger()
        {
            var mess = from messe in data.messeages select messe;
            return PartialView(mess);
        }
        public ActionResult Orders(FormCollection collection, int? page)
        {
            admin adm = (admin)Session["AdminAccount"];
            if (Session["AdminAccount"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 8;
                string key = collection["txtKey"];
                ViewBag.key = key;
                if (key == null || key == "")
                {
                    return View(data.orders.OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
                }
                var order = from ord in data.orders where ord.user.name.ToUpper().Contains(key.ToUpper()) select ord;
                if (order.Count() == 0)
                {
                    ViewBag.Notification = "empty";
                    return View(data.orders.ToList().OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
                }
                return View(order.OrderByDescending(n => n.order_date).ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult Total_price(int id)
        {
            int ? TotalPrice = data.det_orders.Where(or => or.order_id == id).Sum(od => (od.quantity * od.amount));
            ViewBag.TotalPrice = TotalPrice;
            return PartialView();
        }
    }
}