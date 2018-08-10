using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogTruyen_ValueObjects;
using BlogTruyen_ValueObjects.Commonstants;
using BlogTruyen_Simple;
using BlogTruyen_Controller;
using System.Configuration;
using BlogTruyen_Simple.Utility;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class StoryController : BaseController
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/Story
        public ActionResult Index(int pageindex = 0)
        {
            cPosts post = new cPosts();
            var getcount = post.Gettotal();
            var data = post.GetAllpaging(pageindex * pagesize, pagesize);
            ViewBag.Maxpage = (getcount / pagesize) - (getcount % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageindex;
            return View(data);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(Oposts post)
        {
            cPosts cpost = new cPosts();
            post.IdPost = Guid.NewGuid();
            var user = (Ousers)Session[CommonClass.SESSION_USER];
            post.IdUser = user.IdUser;
            var name = (Utility.RemoveSign4VietnameseString(post.PostName)).ToLower();
            post.NameAscii = name.Replace(" ", "-");
            post.DateCreate = DateTime.Now;

            cpost.Add(post);
            return RedirectToAction("Index");

        }

    }
}