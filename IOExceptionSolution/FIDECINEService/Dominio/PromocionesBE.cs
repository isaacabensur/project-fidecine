using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{
    [DataContract]
    public class PromocionesBE
    {
        [DataMember]
        public int IdPromocion { get; set; }

        [DataMember]
        public String nombrepromocion { get; set; }

        [DataMember]
        public int puntos { get; set; }

        [DataMember]
        public char regalo { get; set; }

        [DataMember]
        public String vigenciaInicio { get; set; }

        [DataMember]
        public String vigenciaFin { get; set; }

    }
}