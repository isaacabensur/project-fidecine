using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

using FIDECINEService.Dominio;

namespace FIDECINEService.Service
{
    
    [ServiceContract]
    public interface IPromocionService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Promocion", ResponseFormat = WebMessageFormat.Json)]
        PromocionBE insertar(PromocionBE objPromocionBE);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Promocion/{IdPromocion}", ResponseFormat = WebMessageFormat.Json)]
        PromocionBE obtener(string IdPromocion);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Promocion", ResponseFormat = WebMessageFormat.Json)]
        PromocionBE actualizar(PromocionBE objPromocionBE);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Promociones", ResponseFormat = WebMessageFormat.Json)]
        List<PromocionBE> buscar(PromocionBE objPromocionBE);

    }
}
