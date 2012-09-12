using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIDECINEService.Dominio
{
    public class Cliente
    {
        public int cliId {get; set;}
        public char cliTipo {get; set;}
        public char cliTipoDoc {get; set;}
        public string cliNroDoc { get; set; }
        public string cliNombComp { get; set; }
        public string cliMail { get; set; }
        public string cliTelf { get; set; }
        public string cliDirec { get; set; }


    }
}