using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;

namespace FIDECINEService.Service
{
    
    [ServiceContract]
    public interface ICarteleraService
    {
        [OperationContract]
        void insertar(int int_pIdPelicula, int int_pIdSala, string str_pFechaHora);

        [OperationContract]
        void eliminar(int int_pIdCartelera);

        [OperationContract]
        List<CarteleraBE> listar(int int_pIdPelicula, int int_pIdSala, string str_pFechaInicio, string str_pFechaFin);

    }
}
