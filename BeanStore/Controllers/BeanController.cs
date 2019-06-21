using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeanStore.Models;
using PagedList;
using PagedList.Mvc;
namespace BeanStore.Controllers
{
    public class BeanController : Controller
    {
        dbBeanDataContext data = new dbBeanDataContext();

        private List<item> Getnewitems(int count)
        {
            return data.items.OrderByDescending(a => a.created).Take(count).ToList();
        }
        private List<item> Gettopsale(int count)
        {
            return data.items.OrderByDescending(a => a.sale).Take(count).ToList();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Newitem()
        {
            var newitems = Getnewitems(6);
            return PartialView(newitems);
        }
        public ActionResult Topsale()
        {
            var itemsales = Gettopsale(6);
            return PartialView(itemsales);
        }
        public ActionResult Item_All(int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);

            var item = from ite in data.items select ite;
            return View(item.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Brand()
        {
            var brands = from bra in data.brands select bra;
            return PartialView(brands);
        }
        public ActionResult Brand_Item(int id)
        {
            var brands = from bra in data.brands
                         where bra.id == id
                         select bra;
            return PartialView(brands);
        }
        public ActionResult Catalog_Item(int id)
        {
            var catalogs = from cal in data.catalogs
                         where cal.id == id
                         select cal;
            return PartialView(catalogs);
        }
        public ActionResult Banner()
        {
            var banner = from bra in data.banners
                         select bra;
            return PartialView(banner);
        }
        public ActionResult Items_Brand(int id, int? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);

            var item = from ite in data.items
                       where ite.brand_id == id
                       select ite;
            return View(item.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Items_Catalog(int id, int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);

            var item = from ite in data.items
                       where ite.catalog_id == id
                       select ite;
            ViewBag.paging = pageSize;
            return View(item.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Details(int id)
        {
            var item = from s in data.items
                       where s.id == id
                       select s;
            return View(item.Single());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Items_Catalog_Brand(int cid, int bid, int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);

            var item = from ite in data.items
                       where ite.catalog_id == cid && ite.brand_id == bid
                       select ite;
            if (item.Count() == 0)
            {
                return RedirectToAction("Blank_page", "Bean");
            }
            ViewBag.paging = pageSize;
            return View(item.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Items_Catalog_Ranked(int cid, int rid, int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);

            var item = from ite in data.items
                       where ite.catalog_id == cid && ite.ranked_id == rid
                       select ite;
            if (item.Count() == 0)
            {
                return RedirectToAction("Blank_page", "Bean");
            }
            ViewBag.paging = pageSize;
            return View(item.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Catalog_Brand(int id)
        {
            var brands = from bra in data.brands select bra;
            ViewBag.Catalog_brand_id = id;
            return PartialView(brands);
        }
        public ActionResult Catalog_Ranked(int id)
        {
            var ranked = from ran in data.rankeds select ran;
            ViewBag.Catalog_ranked_id = id;
            return PartialView(ranked);
        }
        public ActionResult Blank_page()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Messenger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Messenger(messeage mess)
        {
            if (ModelState.IsValid)
            {
                data.messeages.InsertOnSubmit(mess);
                data.SubmitChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Order()
        {
            return View(data.orders.ToList().OrderByDescending(n => n.id));
        }
    }
}