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
        [WebInvoke(Method = "POST", UriTemplate = "Pelicula", ResponseFormat = WebMessageFormat.Json)]
        PeliculaBE InsertarPelicula(PeliculaBE entidad);
   
    }
}

