using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIDECINEWeb.Entity;
using FIDECINEWeb.Models;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using FIDECINEWeb.Common;
using FIDECINEService.Dominio;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarClienteController : Controller
    {
        public ActionResult Index()
        {
            return View("../Administracion/AdministrarCliente");
        }
        [HttpPost]
        public JsonResult insertarCliente(string nombre, string apellidoPaterno, string apellidoMaterno, string dni,
            string fechaNacimiento, string correo, string direccion, string tipocliente)
        {

            string postdata = "{\"nombre\":\"" + nombre +
                                "\",\"apellidoPaterno\":\"" + apellidoPaterno +
                                "\",\"apellidoMaterno\":\"" + apellidoMaterno +
                                "\",\"dni\":\"" + dni +
                                "\",\"fechaNacimiento\":\"" + fechaNacimiento +
                                "\",\"correo\":\"" + correo +
                                "\",\"direccion\":\"" + direccion +
                                "\",\"tipocliente\":\"" + tipocliente +
                                "\",\"estado\":\"A\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:12139/Service/ClienteService.svc/Cliente");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string alumnoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            ClienteModel objClienteModel = new ClienteModel();
            objClienteModel.Mensaje = "El Cliente fue ingresado exitosamente";
            objClienteModel.Resultado = Constantes.EXITO;

            return Json(objClienteModel);

        }

        [HttpPost]
        public JsonResult buscarCliente(string strNombre, string strDNI, string strTipoCliente, string strEstado)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente/" + (!string.IsNullOrEmpty(strNombre) ? strNombre : "0") + "/" + (!string.IsNullOrEmpty(strDNI) ? strDNI : "0") + "/" + strTipoCliente + "/" + strEstado);
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string strLista = reader.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<ClienteBE> lstClientes = js2.Deserialize<List<ClienteBE>>(strLista);

            ClienteModel objClienteModel = new ClienteModel();
            objClienteModel.lstClientes = lstClientes;

            return Json(objClienteModel);
        }

        [HttpPost]
        public JsonResult eliminarCliente(int IdCliente)
        {

            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente/" + IdCliente);
            req2.Method = "DELETE";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            //JavaScriptSerializer js2 = new JavaScriptSerializer();

            HorarioProyeccionModel objHorarioProyeccionModel = new HorarioProyeccionModel();
            objHorarioProyeccionModel.Mensaje = "El Cliente fue eliminado exitosamente";
            objHorarioProyeccionModel.Resultado = Constantes.EXITO;

            return Json(objHorarioProyeccionModel);

        }
    }
}