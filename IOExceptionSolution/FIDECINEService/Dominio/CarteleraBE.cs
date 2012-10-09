using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{
    [DataContract]
    public class CarteleraBE
    {

        [DataMember]
        public int IdCartelera { get; set; }

        [DataMember]
        public int IdPelicula { get; set; }

        [DataMember]
        public int IdSala { get; set; }

        [DataMember]
        public String FechaHora { get; set; }

        [DataMember]
        public string PeliculaNombre { get; set; }

        [DataMember]
        public string SalaNombre { get; set; }

    }
}