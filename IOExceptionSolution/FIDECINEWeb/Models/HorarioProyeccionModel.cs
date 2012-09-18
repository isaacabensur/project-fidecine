using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEWeb.PeliculaServiceReference;
using FIDECINEWeb.SalaServiceReference;

namespace FIDECINEWeb.Models
{
    public class HorarioProyeccionModel
    {

        public List<PeliculaBE> ListaPelicula { set; get; }

        public List<SalaBE> ListaSala{ set; get; }
    }

}