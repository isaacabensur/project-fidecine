using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{
    /*public class Cliente
    {
        public int CLI_ID {get; set;}
        public char CLI_TIPO {get; set;}
        public char CLI_TIPODOC {get; set;}
        public string CLI_NRODOC { get; set; }
        public string CLI_NOMBCOMP { get; set; }
        public string CLI_MAIL{ get; set; }
        public string CLI_TELF { get; set; }
        public string CLI_DIREC { get; set; }


    }*/
    [DataContract]
    public class ClienteBE
    {
        [DataMember]
        public int idcliente { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidoPaterno { get; set; }
        [DataMember]
        public string apellidoMaterno { get; set; }
        [DataMember]
        public int dni { get; set; }
        [DataMember]
        public string fechaNacimiento { get; set; }
        [DataMember]
        public string correo { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string tipocliente { get; set; }
        [DataMember]
        public int puntos { get; set; }
        [DataMember]
        public string estado { get; set; }
    }

}