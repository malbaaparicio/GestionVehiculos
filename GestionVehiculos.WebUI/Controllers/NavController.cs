using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionVehiculos.WebUI.Controllers
{
    public class NavController : Controller
    {
        IEnumerable<string> categorias;

        public NavController() {
            this.categorias = new List<string>() {
                "Vehículos",
                "Clientes",
                "Delegaciones",
                "Reservas"
            };
        }
        public PartialViewResult Menu(bool horizontalLayout = false) {           
            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categorias);
        }
     
    }
}