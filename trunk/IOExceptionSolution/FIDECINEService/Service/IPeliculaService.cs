using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;
using System.ServiceModel.Web;

namespace FIDECINEService.Service
{

    [ServiceContract]
    public interface IPeliculaService
    {
        [OperationContract]
        List<PeliculaBE> listar(string str_pNombre, string str_pEstado);

        [OperationContract]
        PeliculaBE InsertarPelicula(PeliculaBE entidad);

        [OperationContract]
        PeliculaBE ObtenerPelicula(string idPelicula);

        [OperationContract]
        PeliculaBE ModificarPelicula(ClienteBE objClienteBE);

        [OperationContract]
        void EliminarPelicula(string idPelicula);

        [OperationContract]
        List<PeliculaBE> ListarPeliculas(string nombre, string idCategoria, string idTipo, string idGenero, string estado);

        [OperationContract]
        List<PeliculaBE> ListarGeneroPelicula();

        [OperationContract]
        List<PeliculaBE> ListarTipoPelicula();

        [OperationContract]
        List<PeliculaBE> ListarCategoriaPelicula();

   
    }
}

