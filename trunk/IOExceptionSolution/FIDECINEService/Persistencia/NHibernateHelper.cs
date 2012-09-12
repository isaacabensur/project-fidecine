using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace FIDECINEService.Persistencia
{
    public class NHibernateHelper
    {
        private static ISessionFactory _FabricaDeSesiones; //Fábrica de conexiones

        private static ISessionFactory FabricaDeSesiones
        {
            get
            {
                if (_FabricaDeSesiones == null)
                {
                    var configuration = new Configuration();

                    configuration.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                    configuration.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
                    configuration.SetProperty("connection.connection_string", ConexionUtil.obtenerCadena());
                    configuration.SetProperty("adonet.batch_size", "10");
                    configuration.SetProperty("show_sql", "true");
                    configuration.SetProperty("dialect", "NHibernate.Dialect.MsSql2000Dialect");
                    configuration.SetProperty("command_timeout", "60");
                    configuration.SetProperty("query.substitutions", "true 1, false 0, yes 'Y', no 'N'");
                    configuration.AddAssembly(typeof(NHibernateHelper).Assembly);
                    _FabricaDeSesiones = configuration.BuildSessionFactory();
                }
                return _FabricaDeSesiones;
            }
        }

        public static ISession AbrirSesion()
        {
            return FabricaDeSesiones.OpenSession();
        }

        public static void CerrarSesion()
        {
            _FabricaDeSesiones = null;
        }
    }
}