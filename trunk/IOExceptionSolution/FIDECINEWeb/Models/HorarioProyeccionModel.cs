using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEWeb.PeliculaServiceReference;
using FIDECINEWeb.SalaServiceReference;
using FIDECINEWeb.Common;

namespace FIDECINEWeb.Models
{
    public class HorarioProyeccionModel : GenericModel
    {

        public List<PeliculaBE> ListaPelicula { set; get; }

        public List<SalaBE> ListaSala{ set; get; }
    }

}