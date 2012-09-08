using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIDECINEWeb.Entity;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarHorarioController : Controller
    {
        
        [HttpPost]
        public JsonResult buscar()
        {

            List<HorarioProyeccion> listaHorarios = new List<HorarioProyeccion>();
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "Los Invensibles", Sala = "Sala 01", FechaHora = "15/09/2012 16:30" });
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "La Era del Rock", Sala = "Sala 01", FechaHora = "15/09/2012 18:30" });
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "Los Pitufos 3D", Sala = "Sala 01", FechaHora = "15/09/2012 20:30" });

            return Json(listaHorarios);
        }

    }
}
