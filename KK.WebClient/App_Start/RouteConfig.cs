using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KK.WebClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //this use to redirect all call with car to carApp
            routes.MapRoute(
                name: "CarApplicationRoutes",
                url: "car/{*url}",
                defaults: new { controller = "CarApp", action = "Index" }
            );

            //this default routes will default it to CarApp
            routes.MapRoute(
                name: "DefaultRoutes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CarApp", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}