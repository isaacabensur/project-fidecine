using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{

    [DataContract]
    public class SalaBE
    {

        [DataMember]
        public int IdSala { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Estado { get; set; }

    }
}