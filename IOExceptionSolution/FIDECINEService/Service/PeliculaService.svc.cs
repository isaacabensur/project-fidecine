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
    public class PeliculaService : IPeliculaService
    {
        private PeliculaDAO dao = new PeliculaDAO();

        public PeliculaBE InsertarPelicula(PeliculaBE entidad)
        {
            Pelicula objeto = new Pelicula();

            objeto.IdPelicula = entidad.IdPelicula;
            objeto.Nombre = entidad.Nombre;
            objeto.idcategoria = entidad.IdCategoria;
            objeto.trailer = entidad.Trailer;
            objeto.descripcion = entidad.Descripcion;
            objeto.idtipo = entidad.IdTipo;
            objeto.Estado = entidad.Estado;
            objeto.idgenero = entidad.IdGenero;
            objeto.duracion = entidad.Duracion;
            dao.insertar(objeto);
            return null;
        }
   
    }
}
