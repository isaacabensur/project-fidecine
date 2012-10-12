using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;

namespace FIDECINEService.Persistencia
{
    public class ProductoDAO
    {
        public List<Producto> listar(ProductoBE objProductoBE)
        {

            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();

            if (!string.IsNullOrEmpty(objProductoBE.Estado))
            {
                sbScript.Append(" ( ToUpper(it.Estado) = @pi_Estado )");
                lstParameters.Add(new ObjectParameter("pi_Estado", objProductoBE.Estado.ToUpper()));
            }

            using (var context = new FideCineEntities())
            {
                return context.Producto.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Producto>();
            }

        }
    }
}