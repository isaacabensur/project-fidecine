using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;

namespace FIDECINEService.Persistencia
{
    public class SalaDAO
    {
        public List<Sala> listar(SalaBE objSalaBE)
        {

            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();

            if (!string.IsNullOrEmpty(objSalaBE.Estado))
            {
                sbScript.Append(" ( ToUpper(it.Estado) = @pi_Estado )");
                lstParameters.Add(new ObjectParameter("pi_Estado", objSalaBE.Estado.ToUpper()));
            }

            using (var context = new FideCineEntities())
            {
                return context.Sala.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Sala>();
            }

        }
    }
}