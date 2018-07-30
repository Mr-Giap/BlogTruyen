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
    public class UserController : Controller
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/User
        public ActionResult Index(int pageindex = 0)
        {
            cUsers csers = new cUsers();
            var getCount = csers.Gettotal();
            List<Ousers> listdata = csers.Getall(pageindex * pagesize, pagesize);
            ViewBag.Maxpage = (getCount / pagesize) - (getCount % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageindex;
            return View(listdata);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Ousers user)
        {
            cUsers csers = new cUsers();
            csers.Add(user);
            return RedirectToAction("Index");
        }
    }
}