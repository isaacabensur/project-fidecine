using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;

namespace FIDECINEWeb.Common
{
    public class GenericModel
    {

        public string Resultado { set; get; }
        public string Mensaje { set; get; }

        public string BaseUrlRest
        {
            get { return WebConfigurationManager.AppSettings["baseUrlRest"]; }
        }

    }
}