using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Models
{
    public class OfertaPromocionModel : GenericModel
    {
        public List<ProductoBE> ListaProducto{ set; get; }
        public List<PromocionBE> ListaPromocion { set; get; }
    }
}