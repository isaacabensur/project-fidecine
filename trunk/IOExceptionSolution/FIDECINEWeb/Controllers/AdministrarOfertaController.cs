using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;

using FIDECINEWeb.ProductoServiceReference;

using System.Threading;

using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarOfertaController : Controller
    {

        public ActionResult Index()
        {

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            return View("../Administracion/AdministrarOfertas", objOfertaPromocionModel);

        }

        [HttpPost]
        public JsonResult nuevaOferta()
        {

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            objOfertaPromocionModel.ListaProducto = new ProductoServiceClient().listar("", "A").ToList<ProductoBE>();

            return Json(objOfertaPromocionModel);

        }

    }
}
