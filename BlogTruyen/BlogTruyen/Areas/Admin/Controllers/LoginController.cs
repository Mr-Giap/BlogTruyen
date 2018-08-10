using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogTruyen_Controller;
using BlogTruyen_ValueObjects.Commonstants;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            HttpContext.Server.ScriptTimeout = 1000;
            string username = frm["UserName"].ToString();
            string password = frm["Password"].ToString();
            var check = "";
            if (frm["Remember"] != null)
            {
                 check = frm["Remember"].ToString();
            }
            var rs = new cUsers().Checklogin(username, password);
            if(rs.IdUser != Guid.Empty)
            {                
                Session.Add(CommonClass.SESSION_USER, rs);
                if(check.Contains("on"))
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                }
                
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View(); 
            }
        }
    }
}