using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class ComprarController : Controller
    {
        // GET: Comprar
        public ActionResult Compra()
        {
            return View();
        }

        public ActionResult Confirmar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedido> p)
        {

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public class Pedido
        {
            public int ProductoId { get; set; }
            public string Denominacion { get; set; }
            public int Cantidad { get; set; }
            public string Imagen { get; set; }
            public decimal Precio { get; set; }
        }

    }
}