using System.Web.Mvc;

namespace BlogTruyen.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin",
                "Admin",
                new {controller="Home" ,action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "BlogTruyen.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "BlogTruyen.Areas.Admin.Controllers" }
            );
        }
    }
}