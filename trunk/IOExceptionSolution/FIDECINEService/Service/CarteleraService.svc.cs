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
    }
}
