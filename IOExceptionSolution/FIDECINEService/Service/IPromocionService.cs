using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

using FIDECINEService.Dominio;
using System.ServiceModel.Activation;

namespace FIDECINEService.Service
{
    
    [ServiceContract]
    public interface IPromocionService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Promocion", ResponseFormat = WebMessageFormat.Json)]
        ResultadoBE insertar(PromocionBE objPromocionBE);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Promocion", ResponseFormat = WebMessageFormat.Json)]
        ResultadoBE eliminar(int IdPromocion);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Promocion", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        ResultadoBE modificar(int IdPromocion);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Promocion/{IdPromocion}", ResponseFormat = WebMessageFormat.Json)]
        ResultadoBE obtener(int IdPromocion);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Promociones", ResponseFormat = WebMessageFormat.Json)]
        List<PromocionBE> listar(PromocionBE objPromocionBE);

    }
}
