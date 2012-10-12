using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{

    [DataContract]
    public class ProductoBE
    {

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Estado { get; set; }

    }
}