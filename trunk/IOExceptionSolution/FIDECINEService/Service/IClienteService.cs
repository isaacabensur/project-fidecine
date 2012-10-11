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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
        ClienteBE InsertarCliente(ClienteBE objCliente);

    }
}
