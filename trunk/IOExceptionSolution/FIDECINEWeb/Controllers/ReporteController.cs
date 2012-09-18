using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIDECINEWeb.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            return View("../Reportes/ReporteConsultaGeneral");
        }

    }
}
