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
    public class Cliente
    {
        [DataMember]
        public int cliId { get; set; }
        [DataMember]
        public char cliTipo { get; set; }
        [DataMember]
        public char cliTipoDoc { get; set; }
        [DataMember]
        public string cliNroDoc { get; set; }
        [DataMember]
        public string cliNombComp { get; set; }
        [DataMember]
        public string cliMail { get; set; }
        [DataMember]
        public string cliTelf { get; set; }
        [DataMember]
        public string cliDirec { get; set; }
    }

}