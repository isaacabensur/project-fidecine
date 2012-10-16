using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Models
{
    public class ClienteModel : GenericModel
    {
        public List<ClienteBE> lstClientes { set; get; }
    }
}