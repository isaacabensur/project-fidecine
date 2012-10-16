using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{

    [DataContract]
    public class VisitaBE
    {

        [DataMember]
        public int IdVisita { get; set; }

        [DataMember]
        public int IdCartelera { get; set; }

        [DataMember]
        public int IdCliente { get; set; }

        [DataMember]
        public int CantidadEntradas { get; set; }

        [DataMember]
        public string PeliculaNombre { get; set; }

        [DataMember]
        public string SalaNombre { get; set; }

        [DataMember]
        public string FechaHora { get; set; }

    }
}