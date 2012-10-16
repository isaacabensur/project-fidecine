using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Objects;

namespace FIDECINEService.Persistencia
{

    public class VisitaDAO
    {
        public List<VisitaCliente> listar(int int_pIdCliente, int int_pIdCartelera)
        {
            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();


            if (int_pIdCliente != 0)
            {
                sbScript.Append(" ( it.idlciente = @pi_idcliente )");
                lstParameters.Add(new ObjectParameter("pi_idcliente", int_pIdCliente));
            }

            if (int_pIdCartelera != 0)
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.IdCartelera = @pi_IdCartelera )");
                lstParameters.Add(new ObjectParameter("pi_IdCartelera", int_pIdCartelera));
            }

            if (lstParameters.Count > 0)
                return (new FideCineEntities().VisitaCliente.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<VisitaCliente>());
            else
                return (new FideCineEntities().VisitaCliente.ToList<VisitaCliente>());

        }
    }

}