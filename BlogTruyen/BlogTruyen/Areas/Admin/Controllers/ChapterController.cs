using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogTruyen_ValueObjects;
using BlogTruyen_Controller;
using System.Configuration;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class ChapterController : BaseController
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/Chapter
        public ActionResult Index(int pageIndex = 0,Guid? id = null)
        {
            cChapters cchap = new cChapters();
            var data = cchap.Getall();
            int total = cchap.Gettotal();
            if (id != null)
            {
                Guid idpost = Guid.Parse(id.Value.ToString());
                data = cchap.GetallPagingbypost(idpost, pageIndex * pagesize, pagesize);
                total = cchap.Getallbypost(idpost).Count;
                ViewBag.idpost = idpost;
            }       
            
            ViewBag.Maxpage = (total / pagesize) - (total % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageIndex;
            return View(data);
        }
        public ActionResult Insert(Guid? idpost)
        {
            if(idpost != null)
            {
                var post = new cPosts().GetbyId(idpost.Value);
                ViewBag.idpost = idpost;
                ViewBag.namepost = post.PostName;
            }
            else
            {
                ViewBag.listpost = new SelectList(new cPosts().Getall(), "IdPost", "PostName");
            }            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(Ochapters chap)
        {
            Guid id = chap.IdPost;
            var total = new cChapters().Getallbypost(chap.IdPost).Count;
            chap.NameChap = total + 1;
            chap.DateCreate = DateTime.Now;
            chap.IdChapter = Guid.NewGuid();
            var item = new cChapters().Add(chap);
            return RedirectToAction("Index", new { id = id });
        }
        public ActionResult Update(Guid id)
        {
            cChapters cchap = new cChapters();
            var data = cchap.GetbyId(id);
            ViewBag.listpost = new SelectList(new cPosts().Getall(), "IdPost", "PostName");
            return View(data);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Ochapters chap)
        {
            cChapters cchap = new cChapters();
            var item = cchap.Update(chap);
            return RedirectToAction("Index","Chapter", new {id=chap.IdPost });
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            return Json(new { rs = "ok" });
        }
    }
}