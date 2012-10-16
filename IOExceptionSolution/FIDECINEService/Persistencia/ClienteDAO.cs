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

                sbScript.Append(" ( it.nombre like @pi_nombre or it.apellidoPaterno like @pi_apellidoPaterno or it.apellidoMaterno like @pi_apellidoMaterno )");
                lstParameters.Add(new ObjectParameter("pi_nombre", "%" + objClienteBE.nombre + "%"));
                lstParameters.Add(new ObjectParameter("pi_apellidoPaterno", "%" + objClienteBE.nombre + "%"));
                lstParameters.Add(new ObjectParameter("pi_apellidoMaterno", "%" + objClienteBE.nombre + "%"));
            }
            if (objClienteBE.dni != 0)
            {
                if (lstParameters.Count > 0) sbScript.Append(" and ");
                sbScript.Append(" ( it.dni = @pi_dni )");
                lstParameters.Add(new ObjectParameter("pi_dni", objClienteBE.dni));
            }
            if (!string.IsNullOrEmpty(objClienteBE.tipocliente) && !objClienteBE.tipocliente.Equals("T"))
            {
                if (lstParameters.Count > 0) sbScript.Append(" and ");
                sbScript.Append(" ( it.tipocliente = @pi_tipocliente )");
                lstParameters.Add(new ObjectParameter("pi_tipocliente", objClienteBE.tipocliente));
            }
            if (!string.IsNullOrEmpty(objClienteBE.estado))
            {
                if (lstParameters.Count > 0) sbScript.Append(" and ");
                sbScript.Append(" ( it.estado = @pi_estado )");
                lstParameters.Add(new ObjectParameter("pi_estado", objClienteBE.estado));
            }
            if (lstParameters.Count > 0)
                return (new FideCineEntities().Cliente.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Cliente>());
            else
                return (new FideCineEntities().Cliente.ToList<Cliente>());
        }
        public Cliente actualizar(Cliente objCliente)
        {
            Cliente objConsulta = null;
            using (var context = new FideCineEntities())
            {
                objConsulta = context.Cliente.Where(" it.idcliente = @pi_IdCliente", new ObjectParameter[] { new ObjectParameter("pi_IdCliente", objCliente.idcliente) }).First<Cliente>();
                objConsulta.nombre = objCliente.nombre;
                objConsulta.apellidoPaterno = objCliente.apellidoPaterno;
                objConsulta.apellidoMaterno = objCliente.apellidoMaterno;
                objConsulta.dni = objCliente.dni;
                objConsulta.fechaNacimiento = objCliente.fechaNacimiento;
                objConsulta.correo = objCliente.correo;
                objConsulta.direccion = objCliente.direccion;
                objConsulta.tipocliente = objCliente.tipocliente;
                objConsulta.puntos = objCliente.puntos;
                objConsulta.estado = objCliente.estado;
                context.SaveChanges();
            }
            return obtener(objCliente);

        }

    }
}