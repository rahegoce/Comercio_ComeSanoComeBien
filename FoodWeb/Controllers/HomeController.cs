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

        public ActionResult Login(string usuario, string clave)
        {
            var u = bd.Cliente.FirstOrDefault(x => x.Usuario == usuario && x.Clave == clave);
            if (u != null)
            {
                Helper.SessionHelper.AddUserToSession(u.ClienteId.ToString());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Helper.SessionHelper.DestroyUserSession();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegistrarCliente(Models.Cliente c)
        {
            bd.Cliente.Add(c);
            bd.SaveChanges();
            Helper.SessionHelper.AddUserToSession(c.ClienteId.ToString());
            return RedirectToAction("Index", "Home");
        }

        public static string ObtenerNombreUsuario()
        {
            using (var b = new Models.TiendaEntities1())
            {
                return b.Cliente.Find(Helper.SessionHelper.GetUser()).Nombres;
            }
        }

    }
}