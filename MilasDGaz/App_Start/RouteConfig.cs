using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MilasDGaz
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
        name: "Service",
        url: "Servisler",
        defaults: new { controller = "Service", action = "Index" }
    );

            routes.MapRoute(
            name: "Contact",
            url: "İletişim",
            defaults: new { controller = "Contact", action = "Index" }
        );
            routes.MapRoute(
        name: "Testimonial",
        url: "Deneyimlerimiz",
        defaults: new { controller = "Testimonial", action = "Index" }
        );


            routes.MapRoute(
              name: "Home",
              url: "Anasayfa",
              defaults: new { controller = "Default", action = "Index" }
          );
            routes.MapRoute(
               name: "About",
               url: "Hakkimizda",
               defaults: new { controller = "About", action = "Index" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
