﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Kentico.Web.Mvc;

namespace HRMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Kentico().MapRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Redirect to NotFound controller
            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "HttpErrors", action = "NotFound" }
                );
        }
    }
}
