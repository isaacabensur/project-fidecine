using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Globalization;
using FIDECINEService.Dominio;

namespace FIDECINEService.Persistencia
{
    public class ClienteDAO
    {
        public void insertar(Cliente objCliente)
        {

            using (var context = new FideCineEntities())
            {
                context.Cliente.AddObject(objCliente);
                context.SaveChanges();
            }
        }
        public Cliente obtener(Cliente objCliente)
        {   
            return new FideCineEntities().Cliente.Where(" it.idcliente = @pi_IdCliente", new ObjectParameter[] { new ObjectParameter("pi_IdCliente", objCliente.idcliente) }).First<Cliente>();
        }

        public void eliminar(int int_pIdCartelera)
        {

            using (var context = new FideCineEntities())
            {
                context.Cliente.DeleteObject(context.Cliente.Where(" it.idcliente = @pi_IdCliente", new ObjectParameter[] { new ObjectParameter("pi_IdCliente", int_pIdCartelera) }).First<Cliente>());
                context.SaveChanges();
            }
        }

        public List<Cliente> listar(ClienteBE objClienteBE)
        {
            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();


            if (objClienteBE.idcliente != 0)
            {
                sbScript.Append(" ( it.idcliente = @pi_idcliente )");
                lstParameters.Add(new ObjectParameter("pi_idcliente", objClienteBE.idcliente));
            }

            if (!string.IsNullOrEmpty(objClienteBE.nombre))
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.nombre = @pi_nombre )");
                lstParameters.Add(new ObjectParameter("pi_nombre", objClienteBE.nombre));
            }
            if (objClienteBE.dni != 0)
            {
                sbScript.Append(" ( it.dni = @pi_dni )");
                lstParameters.Add(new ObjectParameter("pi_dni", objClienteBE.dni));
            }
            if (lstParameters.Count > 0)
                return (new FideCineEntities().Cliente.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Cliente>());
            else
                return (new FideCineEntities().Cliente.ToList<Cliente>());
        }
        public Cliente actualizar(Cliente objCliente)
        {

            using (var context = new FideCineEntities())
            {
                context.Cliente.Attach(objCliente);
                context.SaveChanges();
            }
            return obtener(objCliente);

        }

    }
}