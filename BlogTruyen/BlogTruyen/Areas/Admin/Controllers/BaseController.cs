﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogTruyen_ValueObjects;
using BlogTruyen_ValueObjects.Commonstants;

namespace BlogTruyen.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Ousers)Session[CommonClass.SESSION_USER];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", Area = "Admin", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}