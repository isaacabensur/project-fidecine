using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;
using FIDECINEService.Persistencia;
using System.Globalization;

namespace FIDECINEService.Service
{
    public class ClienteService : IClienteService
    {
        private ClienteDAO dao = new ClienteDAO();

        public ClienteBE InsertarCliente(ClienteBE objCliente)
        {
            Cliente objClienteEntity = new Cliente();
            objClienteEntity.idcliente = objCliente.idcliente;
            objClienteEntity.nombre = objCliente.nombre;
            objClienteEntity.apellidoPaterno = objCliente.apellidoPaterno;
            objClienteEntity.apellidoMaterno = objCliente.apellidoMaterno;
            objClienteEntity.dni = objCliente.dni;
            if (objCliente.fechaNacimiento != null && objCliente.fechaNacimiento.Length > 0)
            {
                objClienteEntity.fechaNacimiento = DateTime.ParseExact(objCliente.fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            objClienteEntity.correo = objCliente.correo;
            objClienteEntity.direccion = objCliente.direccion;
            objClienteEntity.tipocliente = objCliente.tipocliente;
            objClienteEntity.puntos = objCliente.puntos;
            objClienteEntity.estado = objCliente.estado;

            dao.insertar(objClienteEntity);
            return null;

        }

        public ClienteBE ObtenerCliente(string idcliente)
        {
            Cliente objCliente = new Cliente();
            objCliente.idcliente = Int32.Parse(idcliente);
            objCliente = dao.obtener(objCliente);
            ClienteBE ojbClienteBE = new ClienteBE()
            {
                idcliente = objCliente.idcliente,
                nombre = objCliente.nombre,
                apellidoPaterno = objCliente.apellidoPaterno,
                apellidoMaterno = objCliente.apellidoMaterno,
                dni = (int)objCliente.dni,
                fechaNacimiento = ((DateTime)objCliente.fechaNacimiento).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo),
                correo = objCliente.correo,
                direccion = objCliente.direccion,
                tipocliente = objCliente.tipocliente,
                puntos = (int)objCliente.puntos,
                estado = objCliente.estado,

            };
            return ojbClienteBE;
        }

        public ClienteBE ModificarCliente(ClienteBE objClienteBE)
        {
            Cliente objCliente = new Cliente()
            {
                idcliente = objClienteBE.idcliente,
                nombre = objClienteBE.nombre,
                apellidoPaterno = objClienteBE.apellidoPaterno,
                apellidoMaterno = objClienteBE.apellidoMaterno,
                correo = objClienteBE.correo,
                direccion = objClienteBE.direccion,
                tipocliente = objClienteBE.tipocliente,
                estado = objClienteBE.estado,
            };
            if (!string.IsNullOrEmpty(objClienteBE.fechaNacimiento))
            {
                objCliente.fechaNacimiento = DateTime.ParseExact(objClienteBE.fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (objClienteBE.dni != null && objClienteBE.dni != 0)
            {
                objCliente.dni = (int)objClienteBE.dni;
            }
            if (objClienteBE.puntos != null && objClienteBE.puntos != 0)
            {
                objCliente.puntos = (int)objClienteBE.puntos;
            }
            objCliente = dao.actualizar(objCliente);
            ClienteBE ojbClienteBE = new ClienteBE()
            {
                idcliente = objCliente.idcliente,
                nombre = objCliente.nombre,
                apellidoPaterno = objCliente.apellidoPaterno,
                apellidoMaterno = objCliente.apellidoMaterno,
                dni = (int)objCliente.dni,
                correo = objCliente.correo,
                direccion = objCliente.direccion,
                tipocliente = objCliente.tipocliente,
                puntos = (int)objCliente.puntos,
                estado = objCliente.estado
            };
            if (objCliente.fechaNacimiento != null)
                ojbClienteBE.fechaNacimiento = ((DateTime)objCliente.fechaNacimiento).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            return ojbClienteBE;
        }

        public void EliminarCliente(string idcliente)
        {
            dao.eliminar(Int32.Parse(idcliente));
        }

        public List<ClienteBE> ListarClientes(string nombre, string dni, string tipocliente, string estado)
        {
            ClienteBE objClienteBE = new ClienteBE()
            {
                nombre = (nombre.Equals("0") ? "" : nombre),
                dni = Int32.Parse(dni),
                tipocliente = tipocliente,
                estado = estado
            };

            List<ClienteBE> lstClienteBE = new List<ClienteBE>();
            foreach (Cliente objCliente in dao.listar(objClienteBE))
            {
                ClienteBE objTempBE = new ClienteBE()
                {
                    idcliente = objCliente.idcliente,
                    nombre = objCliente.nombre,
                    apellidoPaterno = objCliente.apellidoPaterno,
                    apellidoMaterno = objCliente.apellidoMaterno,
                    correo = objCliente.correo,
                    direccion = objCliente.direccion,
                    tipocliente = objCliente.tipocliente,
                    puntos = (int)objCliente.puntos,
                    estado = objCliente.estado,
                };
                if (objCliente.dni != 0) objTempBE.dni = (int)objCliente.dni;
                if (objCliente.fechaNacimiento != null) objTempBE.fechaNacimiento = ((DateTime)objCliente.fechaNacimiento).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                lstClienteBE.Add(objTempBE);

            }
            return lstClienteBE;
        }
    }
}
