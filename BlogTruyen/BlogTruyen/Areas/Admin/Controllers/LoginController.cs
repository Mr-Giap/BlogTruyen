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
            if(Request.Cookies[CommonClass.COOKIE_USER] != null)
            {
                ViewBag.username = Request.Cookies[CommonClass.COOKIE_USER].Value;
            }
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
                if(check.Contains("on"))
                {
                    if (Request.Cookies[CommonClass.COOKIE_USER] == null)
                    {
                        HttpCookie cookie = new HttpCookie(CommonClass.COOKIE_USER);
                        cookie.Value = username;
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        //var ex = Convert.ToInt32((Request.Cookies[CommonClass.COOKIE_USER].Expires.Date - DateTime.Now.Date).TotalDays);
                        //if(ex >= 0 && ex < 7)
                        //{
                        //    HttpCookie ck = new HttpCookie(CommonClass.COOKIE_USER);
                        //    ck.Value = username;
                        //    var dayadd = 7 - ex;
                        //    ck.Expires = DateTime.Now.AddDays(dayadd);
                        //    Response.Cookies.Add(ck);
                        //}
                    }
                    //FormsAuthentication.SetAuthCookie(username, true);                    
                }
                Session.Add(CommonClass.SESSION_USER, rs);
                if(Session[CommonClass.SESSION_CURURL] != null)
                {
                    return new RedirectResult(Session[CommonClass.SESSION_CURURL].ToString());
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
                
            }
            else
            {
                return View(); 
            }
        }
        public ActionResult Logout()
        {
            Session[CommonClass.SESSION_USER] = null;
            FormsAuthentication.SignOut();
            Session[CommonClass.SESSION_CURURL] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}