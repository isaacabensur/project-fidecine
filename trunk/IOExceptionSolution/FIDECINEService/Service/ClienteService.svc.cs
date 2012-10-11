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
        /*
        public Cliente ObtenerAlumno(string codigo)
        {
            return dao.Obtener(codigo);
        }

        public Cliente ModificarAlumno(Cliente alumnoAModificar)
        {
            return dao.Modificar(alumnoAModificar);
        }

        public void EliminarAlumno(string codigo)
        {
            dao.Eliminar(dao.Obtener(codigo));
        }

        public List<Cliente> ListarAlumnos()
        {
            return dao.ListarTodos();
        }*/
    }
}
