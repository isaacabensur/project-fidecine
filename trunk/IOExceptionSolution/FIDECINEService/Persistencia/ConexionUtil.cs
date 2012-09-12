using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIDECINEService.Persistencia
{
    public class ConexionUtil
    {
        public static string obtenerCadena(){
            return "Data Source=(local);Initial Catalog=BDFIDECINE;Integrated Security=SSPI;";
        }
        
    }
}