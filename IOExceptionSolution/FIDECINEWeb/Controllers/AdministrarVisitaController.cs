using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarVisitaController : Controller
    {
        public ActionResult Index()
        {
            return View("../Administracion/AdministrarVisita");
        }
    }
}