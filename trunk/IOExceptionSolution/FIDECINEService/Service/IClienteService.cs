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
    public interface IClienteService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
        ClienteBE InsertarCliente(ClienteBE objCliente);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cliente/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        ClienteBE ObtenerCliente(string idcliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
        ClienteBE ModificarCliente(ClienteBE objClienteBE);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Cliente/{idcliente}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarCliente(string idcliente);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cliente/{nombre}/{dni}/{tipocliente}/{estado}", ResponseFormat = WebMessageFormat.Json)]
        List<ClienteBE> ListarClientes(string nombre, string dni, string tipocliente, string estado);

    }
}
