﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarClienteController : Controllerss
    {
        public ActionResult Index()
        {
            return View("../Administracion/AdministrarCliente");
        }
    }
}