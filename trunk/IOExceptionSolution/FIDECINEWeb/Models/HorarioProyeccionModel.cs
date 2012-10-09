using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FIDECINEWeb.Common;
using FIDECINEService.Dominio;


namespace FIDECINEWeb.Models
{
    public class HorarioProyeccionModel : GenericModel
    {

        public List<PeliculaBE> ListaPelicula { set; get; }

        public List<SalaBE> ListaSala { set; get; }

        public List<CarteleraBE> ListaCartelera { set; get; }


    }

}