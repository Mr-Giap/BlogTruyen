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
    public class TypeController : BaseController
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/Type
        public ActionResult Index(int pageIndex = 0)
        {
            cTypes ctype = new cTypes();
            var total = ctype.Gettotal();
            var data = ctype.GetAllpaging(pageIndex * pagesize, pagesize);
            ViewBag.Maxpage = (total / pagesize) - (total % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageIndex;
            return View(data);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Otypes type)
        {
            cTypes ctype = new cTypes();
            ctype.Add(type);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            cTypes ctype = new cTypes();
            var data = ctype.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Update(Otypes type)
        {
            cTypes ctype = new cTypes();
            ctype.Update(type);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(new { rs = "ok" });
        }
    }
}