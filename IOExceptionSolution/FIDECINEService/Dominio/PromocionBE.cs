using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{

    [DataContract]
    public class PromocionBE
    {
        [DataMember]
        public int IdPromocion { get; set; }

        [DataMember]
        public int Puntos { get; set; }

        [DataMember]
        public String VigenciaInicio { get; set; }

        [DataMember]
        public String VigenciaFin { get; set; }

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public string ProductoNombre { get; set; }

        [DataMember]
        public string Estado { get; set; }

    }

}