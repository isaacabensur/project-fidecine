using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;

namespace FIDECINEService.Persistencia
{
    public class PeliculaDAO
    {
        public List<Pelicula> listar(PeliculaBE objPeliculaBE)
        {

            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();

            if (!string.IsNullOrEmpty(objPeliculaBE.Estado))
            {
                sbScript.Append(" ( ToUpper(it.Estado) = @pi_Estado )");
               

                
            }

            return (new FideCineEntities().Pelicula.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Pelicula>());

        }
    }
}