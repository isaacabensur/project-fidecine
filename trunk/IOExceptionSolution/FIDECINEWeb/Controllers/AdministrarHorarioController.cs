using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;

using FIDECINEWeb.PeliculaServiceReference;
using FIDECINEWeb.SalaServiceReference;
using FIDECINEWeb.CarteleraServiceReference;

using System.Threading;

using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarHorarioController : Controller
    {

        public ActionResult Index()
        {

            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.ListaPelicula = new PeliculaServiceClient().listar("","A").ToList<PeliculaBE>();
            objHorarioProyeccionModel.ListaSala = new SalaServiceClient().listar("","A").ToList<SalaBE>();

            return View("../Administracion/AdministrarCartelera", objHorarioProyeccionModel);
        }

        [HttpPost]
        public JsonResult buscarHorario(int IdPelicula, int IdSala, string FechaInicio, string FechaFin)
        {

            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.ListaCartelera = new CarteleraServiceClient().listar(IdPelicula, IdSala, FechaInicio, FechaFin).ToList<CarteleraBE>();
            return Json(objHorarioProyeccionModel);
        }

        [HttpPost]
        public JsonResult nuevoHorario()
        {
   
            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.ListaPelicula = new PeliculaServiceClient().listar("", "A").ToList<PeliculaBE>();
            objHorarioProyeccionModel.ListaSala = new SalaServiceClient().listar("", "A").ToList<SalaBE>();

            return Json(objHorarioProyeccionModel);

        }


        [HttpPost]
        public JsonResult insertarHorario(int IdPelicula, int IdSala, string FechaHora)
        {

            new CarteleraServiceClient().insertar(IdPelicula, IdSala, FechaHora);

            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.Mensaje = "El Horario de Proyección fue ingresado exitosamente";
            objHorarioProyeccionModel.Resultado = Constantes.EXITO;

            return Json(objHorarioProyeccionModel);

        }

        [HttpPost]
        public JsonResult eliminarHorario(int IdCartelera)
        {

            new CarteleraServiceClient().eliminar(IdCartelera);

            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.Mensaje = "El Horario de Proyección fue eliminado exitosamente";
            objHorarioProyeccionModel.Resultado = Constantes.EXITO;

            return Json(objHorarioProyeccionModel);

        }

    }
}
