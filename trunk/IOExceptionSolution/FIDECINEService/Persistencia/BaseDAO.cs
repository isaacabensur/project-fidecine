using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace FIDECINEService.Persistencia
{
    public class BaseDAO<Entidad, Id>
    {
        public Entidad Crear(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaccion = sesion.BeginTransaction())
                {
                    sesion.Save(entidad);
                    sesion.Flush();
                }
            }
            return entidad;
        }

        public Entidad Obtener(Id id)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                return sesion.Get<Entidad>(id);
            }
        }

        public Entidad Modificar(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaccion = sesion.BeginTransaction())
                {
                    sesion.Update(entidad);
                    sesion.Flush();
                }
            }
            return entidad;
        }

        public void Eliminar(Entidad entidad)
        {
            using (ISession sesion = NHibernateHelper.AbrirSesion())
            {
                using (ITransaction transaction = sesion.BeginTransaction())
                {
                    sesion.Delete(entidad);
                    sesion.Flush();
                }
            }
        }
    }
}