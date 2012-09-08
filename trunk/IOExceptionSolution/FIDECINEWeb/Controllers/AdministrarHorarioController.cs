using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarHorarioController : Controller
    {
        
        [HttpPost]
        public JsonResult buscar()
        {            
            return Json(null);
        }

    }
}
