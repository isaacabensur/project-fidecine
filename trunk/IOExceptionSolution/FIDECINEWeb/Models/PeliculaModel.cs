using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Models

{
    public class PeliculaModel : GenericModel  

    {
        public List<PeliculaBE> lstPeliculas { set; get; }
        public List<PeliculaBE> lstGenero { set; get; }
        public List<PeliculaBE> lstCategoria { set; get; }
        public List<PeliculaBE> lstTipo { set; get; }

    }
}