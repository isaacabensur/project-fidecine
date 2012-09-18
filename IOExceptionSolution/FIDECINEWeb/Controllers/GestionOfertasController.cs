using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIDECINEWeb.Controllers
{
    public class GestionOfertasController : Controller
    {
        //
        // GET: /GestionOfertas/

        public ActionResult Index()
        {
            return View("../Oferta/GestionOfertas");
        }

    }
}
