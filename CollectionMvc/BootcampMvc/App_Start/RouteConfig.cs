using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BootcampMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // this is how server manages the route in Web app
            routes.MapRoute(
                name: "Store", // route name
                url: "MyStore/BrowseProduct/{category}", // url showed at browser
                defaults: new
                {
                    controller = "Store", // Controller that will be called
                    action = "Browse", // Action will be executed
                    category = UrlParameter.Optional // parameter (if any)
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
