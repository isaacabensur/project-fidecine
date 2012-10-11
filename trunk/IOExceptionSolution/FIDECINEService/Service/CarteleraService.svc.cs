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
    
    public class CarteleraService : ICarteleraService
    {

        public void insertar(int int_pIdPelicula, int int_pIdSala, string str_pFechaHora)
        {
            Cartelera objCartelera = new Cartelera();
            objCartelera.IdPelicula = int_pIdPelicula;
            objCartelera.IdSala = int_pIdSala;
            objCartelera.FechaHora = DateTime.ParseExact(str_pFechaHora,  "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            new CarteleraDAO().insertar(objCartelera);
        }

        public void eliminar(int int_pIdCartelera)
        {
            new CarteleraDAO().eliminar(int_pIdCartelera);
        }

        public List<CarteleraBE> listar(int int_pIdPelicula, int int_pIdSala, string str_pFechaInicio, string str_pFechaFin)
        {

            List<CarteleraBE> listaCartelera = new List<CarteleraBE>();
            CarteleraBE objCarteleraBE = null;

            foreach (Cartelera objCartelera in new CarteleraDAO().listar(int_pIdPelicula, int_pIdSala, str_pFechaInicio, str_pFechaFin))
            {
                objCarteleraBE = new CarteleraBE();
                objCarteleraBE.IdCartelera = objCartelera.IdCartelera;
                objCarteleraBE.PeliculaNombre = objCartelera.Pelicula.Nombre;
                objCarteleraBE.SalaNombre = objCartelera.Sala.Nombre;
                objCarteleraBE.FechaHora = objCartelera.FechaHora.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                listaCartelera.Add(objCarteleraBE);
            }

            return listaCartelera;
        }

    }
}
