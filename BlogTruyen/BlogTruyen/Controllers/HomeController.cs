using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogTruyen_Controller;
using BlogTruyen_ValueObjects;

namespace BlogTruyen.Controllers
{
    public class HomeController : Controller
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        public ActionResult Index(int pageindex = 0)
        {
            cPosts post = new cPosts();
            var getcount = post.Gettotal();
            var data = post.GetAllpaging(pageindex * pagesize, pagesize);
            ViewBag.Maxpage = (getcount / pagesize) - (getcount % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageindex;
            return View(data);
        }
        
    }
}
