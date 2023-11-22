using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GestionVehiculos.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Coches", action = "ListaCoches", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: null,
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Coches",action = "VerCoches",id = UrlParameter.Optional }
           );
        }
    }
}
