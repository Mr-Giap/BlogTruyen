using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BlogTruyen_Controller;
using BlogTruyen_ValueObjects;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private int pagesize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
        // GET: Admin/User
        public ActionResult Index(int pageindex = 0)
        {
            cUsers csers = new cUsers();
            var getCount = csers.Gettotal();
            List<Ousers> listdata = csers.Getallpaging(pageindex * pagesize, pagesize);
            ViewBag.Maxpage = (getCount / pagesize) - (getCount % pagesize == 0 ? 1 : 0);
            ViewBag.Page = pageindex;
            return View(listdata);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.listRole = new SelectList((new cRoles().Getall()), "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Ousers user)
        {
            user.DateCreate = DateTime.Now;
            user.IdUser = Guid.NewGuid();
            if(user.Avatar == null)
            {
                user.Avatar = "default";
            }
            cUsers csers = new cUsers();
            csers.Add(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(Guid id)
        {
            cUsers csers = new cUsers();
            var user = csers.GetbyId(id);
            ViewBag.listRole = new SelectList((new cRoles().Getall()), "RoleId", "RoleName");
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(Ousers user)
        {
            cUsers csers = new cUsers();
            csers.Update(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            var item = new cUsers().Delete(id);   
            return Json(new {rs = "ok" });
        }
        public JsonResult CheckuserName(string username)
        {
            cUsers csers = new cUsers();
            var rs = csers.CheckUsername(username);
            return Json(new { kq = rs});
        }
    }
}