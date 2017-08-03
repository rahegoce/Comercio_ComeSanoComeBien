using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWeb.Controllers
{
    public class ComprarController : Controller
    {

        private Models.TiendaEntities1 bd = new Models.TiendaEntities1();
        // GET: Comprar
        public ActionResult Compra()
        {
            return View();
        }

        public ActionResult Confirmar()
        {
            var cliente = bd.Cliente.Find(Helper.SessionHelper.GetUser());
            return View(cliente);
        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedidos> p)
        {
            var clienteid = Helper.SessionHelper.GetUser();
            var pcab = new Models.Pedido
            {
                ClienteId = clienteid,
                Estado = "P",
                Fecha = DateTime.Now
            };

            bd.Pedido.Add(pcab);
            bd.SaveChanges();


            foreach (var item in p)
            {
                var pdet = new Models.PedidoDetalle
                {
                    PedidoId = pcab.PedidoId,
                    Cantidad = item.Cantidad,
                    ProductoId = item.ProductoId
                };
                bd.PedidoDetalle.Add(pdet);
                bd.SaveChanges();
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public class Pedidos
        {
            public int ProductoId { get; set; }
            public string Denominacion { get; set; }
            public int Cantidad { get; set; }
            public string Imagen { get; set; }
            public decimal Precio { get; set; }
        }

    }
}