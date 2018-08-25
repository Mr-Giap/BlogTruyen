using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogTruyen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "paging Default",
                url: "Ds-truyen/{id}",
                defaults: new { controller = "Story", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BlogTruyen.Areas.Admin.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BlogTruyen.Controllers" }
            );
        }
    }
}
