using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;
using FIDECINEService.Persistencia;

namespace FIDECINEService.Service
{
    public class Cliente : IClienteService
    {
        private ClienteDAO dao = new ClienteDAO();

        public Cliente CrearAlumno(Cliente alumnoACrear)
        {
            return dao.Crear(alumnoACrear);
        }

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
        }
    }
}
