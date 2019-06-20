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
    }
}