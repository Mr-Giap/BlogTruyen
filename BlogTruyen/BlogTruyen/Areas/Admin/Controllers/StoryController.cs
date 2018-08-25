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
        public ActionResult Index(int trang = 0)
        {
            int pageindex = 0;
            if (trang > 0) {
                 pageindex = trang - 1;
            }            
            cPosts post = new cPosts();
            var getcount = post.Gettotal();
            var data = post.GetAllpaging(pageindex * pagesize, pagesize);
            ViewBag.Maxpage = (getcount / pagesize) - (getcount % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageindex;
            return View(data);
        }
        public ActionResult Insert()
        {
            ViewBag.listType = new SelectList(new cTypes().Getall(), "IdType", "TypeName");
            ViewBag.listCate  = new SelectList(new cCategories().Getall(), "IdCategory", "CategoryName");
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
            if(post.Child == null)
            {
                post.Child = "Không có hậu truyện";
            }

            cpost.Add(post);
            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)
        {
            cPosts cpost = new cPosts();
            ViewBag.listType = new SelectList(new cTypes().Getall(), "IdType", "TypeName");
            ViewBag.listCate = new SelectList(new cCategories().Getall(), "IdCategory", "CategoryName");

            var data = cpost.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Oposts post)
        {
            cPosts cpost = new cPosts();
            cpost.Update(post);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            return Json(new { rs = "ok" });
        }

    }
}