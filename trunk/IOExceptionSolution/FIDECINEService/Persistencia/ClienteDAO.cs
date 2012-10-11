using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Objects;
using System.Data.SqlClient;

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
        /*
        public Cliente obtenerCliente(Cliente objCliente)
        {

            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();

            if (!string.IsNullOrEmpty(objCliente.estado))
            {
                sbScript.Append(" ( ToUpper(it.estado) = @pi_estado )");
                sbScript.Append(" ( ToUpper(it.idcliente) = @pi_idcliente )");
                lstParameters.Add(new ObjectParameter("pi_Estado", objCliente.estado.ToUpper()));
            }

            return null;

        }*/
        /* public Cliente obtenerCliente(int idCliente)
         {
             Cliente objCliente = null;
             string sql = " WHERE idcliente = @idcliente";
             using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
             {
                 con.Open();
                 using (SqlCommand com = new SqlCommand(sql, con))
                 {
                     com.Parameters.Add(new SqlParameter("@ID_ITINERARIO", ID_ITINERARIO));
                     using (SqlDataReader resultado = com.ExecuteReader())
                     {
                         if (resultado.Read())
                         {
                             itinerarioEncontrado = new Itinerario()
                             {
                                 Id_Itinerario = (int)resultado["ID_ITINERARIO"],
                                 Id_Origen = (int)resultado["ID_ORIGEN"],
                                 Descripcion_Origen = (string)resultado["DESCRIPCION_ORIGEN"],
                                 Id_Destino = (int)resultado["ID_DESTINO"],
                                 Descripcion_Destino = (string)resultado["DESCRIPCION_DESTINO"],
                                 Salida = (DateTime)resultado["SALIDA"],
                                 Llegada = (DateTime)resultado["LLEGADA"],
                                 Total_Asiento = int.Parse(resultado["TOTAL_ASIENTO"].ToString()),
                                 Estado = (string)resultado["ESTADO"]
                             };
                         }
                     }
                 }
             }
             return itinerarioEncontrado;
         }*/

    }
}