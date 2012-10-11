using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{
  /*  public class Cliente
    {
        public int cliId {get; set;}
        public char cliTipo {get; set;}
        public char cliTipoDoc {get; set;}
        public string cliNroDoc { get; set; }
        public string cliNombComp { get; set; }
        public string cliMail { get; set; }
        public string cliTelf { get; set; }
        public string cliDirec { get; set; }


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