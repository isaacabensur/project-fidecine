using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;

using FIDECINEWeb.ProductoServiceReference;

using System.Threading;

using FIDECINEWeb.Common;
using FIDECINEService.Dominio;
using System.Text;
using System.Net;
using System.Web.Configuration;
using System.IO;
using System.Web.Script.Serialization;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarOfertaController : Controller
    {

        public ActionResult Index()
        {

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            return View("../Administracion/AdministrarOfertas", objOfertaPromocionModel);

        }

        [HttpPost]
        public JsonResult nuevaOferta()
        {

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            objOfertaPromocionModel.ListaProducto = new ProductoServiceClient().listar("", "A").ToList<ProductoBE>();

            return Json(objOfertaPromocionModel);

        }

        [HttpPost]
        public JsonResult insertarOferta(int IdProducto, int Puntos, string VigenciaInicio, string VigenciaFin)
        {

            StringBuilder sbPostData = new StringBuilder();
            sbPostData.Append("{");
            sbPostData.AppendFormat(" \"IdProducto\": {0} , ", IdProducto);
            sbPostData.AppendFormat("\"Puntos\": {0} , ", Puntos);
            sbPostData.AppendFormat("\"VigenciaInicio\": \"{0}\" , ", VigenciaInicio);
            sbPostData.AppendFormat("\"VigenciaFin\": \"{0}\"  ", VigenciaFin);
            sbPostData.Append("}");

            byte[] data = Encoding.UTF8.GetBytes(sbPostData.ToString());
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(WebConfigurationManager.AppSettings[Constantes.URL_PROMOCION_REST] + "Promocion");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();

            StreamReader reader = new StreamReader(res.GetResponseStream());
            string resultado = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            ResultadoBE objResultadoBE = js.Deserialize<ResultadoBE>(resultado);

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            objOfertaPromocionModel.Mensaje = objResultadoBE.Mensaje;
            objOfertaPromocionModel.Resultado = Constantes.EXITO;

            return Json(objOfertaPromocionModel);

        }

        [HttpPost]
        public JsonResult buscarOferta(string FechaInicio, string FechaFin)
        {

            StringBuilder sbPostData = new StringBuilder();
            sbPostData.Append("{");
            sbPostData.AppendFormat("\"VigenciaInicio\": \"{0}\" , ", FechaInicio);
            sbPostData.AppendFormat("\"VigenciaFin\": \"{0}\"  ", FechaFin);
            sbPostData.Append("}");

            byte[] data = Encoding.UTF8.GetBytes(sbPostData.ToString());
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(WebConfigurationManager.AppSettings[Constantes.URL_PROMOCION_REST] + "Promociones");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();

            StreamReader reader = new StreamReader(res.GetResponseStream());
            string resultado = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PromocionBE> listaPromocion = js.Deserialize<List<PromocionBE>>(resultado);

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            objOfertaPromocionModel.ListaPromocion = listaPromocion;

            return Json(objOfertaPromocionModel);

        }

        [HttpPost]
        public JsonResult eliminarOferta(int IdPromocion)
        {

            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("{0}", IdPromocion);

            byte[] data = Encoding.UTF8.GetBytes(sbPostData.ToString());
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(WebConfigurationManager.AppSettings[Constantes.URL_PROMOCION_REST] + "Promocion");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();

            StreamReader reader = new StreamReader(res.GetResponseStream());
            string resultado = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            ResultadoBE objResultadoBE = js.Deserialize<ResultadoBE>(resultado);

            OfertaPromocionModel objOfertaPromocionModel = new OfertaPromocionModel();
            objOfertaPromocionModel.Mensaje = objResultadoBE.Mensaje;
            objOfertaPromocionModel.Resultado = Constantes.EXITO;

            return Json(objOfertaPromocionModel);

        }

    }
}
