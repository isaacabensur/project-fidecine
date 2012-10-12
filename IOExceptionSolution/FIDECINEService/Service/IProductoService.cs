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
    public interface IProductoService
    {
        [OperationContract]
        List<ProductoBE> listar(string str_pNombre, string str_pEstado);
    }
}
