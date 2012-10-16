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

        public PeliculaBE ObtenerPelicula(string idPelicula)
        {
            throw new NotImplementedException();
        }

        public PeliculaBE ModificarPelicula(ClienteBE objClienteBE)
        {
            throw new NotImplementedException();
        }

        public void EliminarPelicula(string idPelicula)
        {
            dao.eliminar(Int32.Parse(idPelicula));
        }

        public List<PeliculaBE> ListarPeliculas(string nombre, string idCategoria, string idTipo, string idGenero, string estado)
        {
            PeliculaBE objPeliculaBE = new PeliculaBE()
            {
                Nombre = nombre,
                IdCategoria = Int32.Parse(idCategoria),
                IdTipo = Int32.Parse(idTipo),
                IdGenero = Int32.Parse(idGenero),
                Estado = estado
            };
            PeliculaBE objTmp = null;
            List<PeliculaBE> lstPeliculaBE = new List<PeliculaBE>();
            foreach (Pelicula objPeliculaIter in dao.listar(objPeliculaBE))
            {
                objTmp = new PeliculaBE()
                {
                    IdPelicula = objPeliculaIter.IdPelicula,
                    Nombre = objPeliculaIter.Nombre,
                    IdCategoria = (int)objPeliculaIter.idcategoria,
                    Trailer = objPeliculaIter.trailer,
                    Descripcion = objPeliculaIter.descripcion,
                    IdTipo = (int)objPeliculaIter.idtipo,
                    Estado = objPeliculaIter.Estado,
                    IdGenero = (int)objPeliculaIter.idgenero,
                    Duracion = (int)objPeliculaIter.duracion
                };
                lstPeliculaBE.Add(objTmp);
            }
            return lstPeliculaBE;
        }

        public List<PeliculaBE> ListarGeneroPelicula()
        {
            List<PeliculaBE> lstReturn = new List<PeliculaBE>();
            foreach (GeneroPelicula objIter in dao.listarGeneroPelicula())
            {
                PeliculaBE objTmp = new PeliculaBE()
                {
                    IdGenero = objIter.idgenero,
                    descGenero = objIter.nombreGenero
                };
                lstReturn.Add(objTmp);
            }
            return lstReturn;
        }

        public List<PeliculaBE> ListarTipoPelicula()
        {
            List<PeliculaBE> lstReturn = new List<PeliculaBE>();
            foreach (TipoPelicula objIter in dao.listarTipoPelicula())
            {
                PeliculaBE objTmp = new PeliculaBE()
                {
                    IdTipo = objIter.idtipo,
                    descTipo = objIter.nombreTipo
                };
                lstReturn.Add(objTmp);
            }
            return lstReturn;
        }

        public List<PeliculaBE> ListarCategoriaPelicula()
        {
            List<PeliculaBE> lstReturn = new List<PeliculaBE>();
            foreach (CategoriaPelicula objIter in dao.listarCategoriaPelicula())
            {
                PeliculaBE objTmp = new PeliculaBE()
                {
                    IdCategoria = objIter.idcategoria,
                    descCategoria = objIter.nombreCategoria
                };
                lstReturn.Add(objTmp);
            }
            return lstReturn;
        }
        public List<PeliculaBE> listar(string str_pNombre, string str_pEstado)
        {

            PeliculaBE obj_pPeliculaBE = new PeliculaBE();
            obj_pPeliculaBE.Nombre = str_pNombre;
            obj_pPeliculaBE.Estado = str_pEstado;

            List<PeliculaBE> listaPelicula = new List<PeliculaBE>();
            PeliculaBE objPeliculaBE = null;

            foreach (Pelicula objPelicula in new PeliculaDAO().listar(obj_pPeliculaBE))
            {
                objPeliculaBE = new PeliculaBE();
                objPeliculaBE.IdPelicula = objPelicula.IdPelicula;
                objPeliculaBE.Nombre = objPelicula.Nombre;
                objPeliculaBE.Estado = objPelicula.Estado;
                listaPelicula.Add(objPeliculaBE);
            }

            return listaPelicula;
        }
    }
}
