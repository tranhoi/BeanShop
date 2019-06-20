using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        // GET: Admin
        public ActionResult Admin_Index()
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
            var username = collection["username"];
            var pass = collection["pass"];
            admin ad = data.admins.SingleOrDefault(n => n.username == username && n.password == pass);
            if (ad != null)
            {
                Session["AdminAccount"] = ad;
                return RedirectToAction("Admin_Index", "Admin");
            }
            else
                ViewBag.Notification = "error";
            return View();
        }
        public ActionResult Items(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            return View(data.items.ToList().OrderByDescending(n => n.id).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Banner()
        {
            return View(data.banners.ToList().OrderByDescending(n => n.id));
        }
        [HttpGet]
        public ActionResult Create_Items()
        {
            ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Items(item item, HttpPostedFileBase fileUpload, HttpPostedFileBase fileUpload2, HttpPostedFileBase fileUpload3, HttpPostedFileBase fileUpload4, HttpPostedFileBase fileUpload5)
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
                    data.items.InsertOnSubmit(item);
                    data.SubmitChanges();
                }
                return RedirectToAction("Items");
            }
        }
        public ActionResult Details(int id)
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
        public ActionResult Delete(int id)
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

        [HttpPost, ActionName("Delete")]
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
        public ActionResult Edit(int id)
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
            return View(ite);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(item sp, FormCollection col)
        {
            ViewBag.Brand_id = new SelectList(data.brands.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Catalog_id = new SelectList(data.catalogs.ToList().OrderBy(n => n.name), "id", "name");
            ViewBag.Ranked_id = new SelectList(data.rankeds.ToList().OrderBy(n => n.name), "id", "name");
            item ite = data.items.First(n => n.id == sp.id);
            if (ModelState.IsValid)
            {
                ite.created = DateTime.Now;
                UpdateModel(ite);
                data.SubmitChanges();
                return RedirectToAction("Items");
            }
            return this.Edit(ite.id);
        }
        [HttpGet]
        public ActionResult Inset_banner()
        {
            return View();
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
    }
}