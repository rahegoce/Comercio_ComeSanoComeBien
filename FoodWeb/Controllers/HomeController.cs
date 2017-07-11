using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class HomeController : Controller
    {
        private Models.TiendaEntities1 bd = new Models.TiendaEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string id="")
        {
            //logica de acceso a BD
            var productos = bd.Producto.Where(x=>x.Descripcion.Contains(id))
                .Take(20)
                .ToList();
            //lista de productos
            ViewBag.clave = id;
            return View(productos);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}