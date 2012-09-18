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
    
    public class PeliculaService : IPeliculaService
    {

        public List<PeliculaBE> listar(string str_pNombre, string str_pEstado)
        {

            PeliculaBE obj_pPeliculaBE = new PeliculaBE();
            obj_pPeliculaBE.Nombre = str_pNombre;
            obj_pPeliculaBE.Estado = str_pEstado;

            List<PeliculaBE> listaPelicula = new List<PeliculaBE>();
            PeliculaBE objPeliculaBE = null;

            foreach(Pelicula objPelicula in new PeliculaDAO().listar(obj_pPeliculaBE))
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
