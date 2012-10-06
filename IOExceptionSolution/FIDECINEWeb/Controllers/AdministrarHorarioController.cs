﻿using System;
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
        public JsonResult buscar()
        {

            List<HorarioProyeccion> listaHorarios = new List<HorarioProyeccion>();
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "Los Invensibles", Sala = "Sala 01", FechaHora = "15/09/2012 16:30" });
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "La Era del Rock", Sala = "Sala 01", FechaHora = "15/09/2012 18:30" });
            listaHorarios.Add(new HorarioProyeccion() { Pelicula = "Los Pitufos 3D", Sala = "Sala 01", FechaHora = "15/09/2012 20:30" });

            Thread.Sleep(2000);//Borrar

            return Json(listaHorarios);
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

    }
}