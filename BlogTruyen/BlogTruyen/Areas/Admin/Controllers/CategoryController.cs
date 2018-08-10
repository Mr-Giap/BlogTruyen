using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogTruyen_Controller;
using BlogTruyen_ValueObjects;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private static int _pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/Category
        public ActionResult Index(int pageIndex = 0 )
        {
            cCategories cate = new cCategories();
            var data = cate.Getall(pageIndex * _pageSize, _pageSize);
            int total = cate.Gettotal();
            ViewBag.MaxPage = (total / _pageSize) - (total % _pageSize == 0 ? 0 : 1);
            return View(data);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Ocategories cate)
        {
            cCategories ccate = new cCategories();
            ccate.Add(cate);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            cCategories cate = new cCategories();
            var data = cate.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(Ocategories cate)
        {
            cCategories ccate = new cCategories();
            ccate.Update(cate);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(new { rs = "ok" });
        }

    }
}