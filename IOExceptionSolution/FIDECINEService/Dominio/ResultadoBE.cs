using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{

    [DataContract]
    public class ResultadoBE
    {

        [DataMember]
        public string Resultado { set; get; }

        [DataMember]
        public string Mensaje { set; get; }

    }
}