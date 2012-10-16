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

namespace FIDECINEWeb.Controllers
{
    public class AdministrarPeliculaController : Controller
    {
        public ActionResult Index()
        {
            return View("../Administracion/AdministrarPelicula");
        }

        [HttpPost]
        public JsonResult insertarPelicula(string nombre, string descripcion, string trailer, string cboGenero,
            string cboCategoria, string cboTipo, string cboestado)
        {
            PeliculaModel objeto = new PeliculaModel();

            try
            {
                string postdata = "{\"Nombre\":\"" + nombre +
                    "\",\"IdGenero\":\"" + cboGenero +
                    "\",\"IdCategoria\":\"" + cboCategoria +
                    "\",\"Trailer\":\"" + trailer +
                    "\",\"Descripcion\":\"" + descripcion +
                    "\",\"IdTipo\":\"" + cboTipo +
                    "\",\"Estado\":\"" + cboestado +
                    "\",\"Duracion\":\"45\"}"; //JSON; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://localhost:12139/Service/PeliculaService.svc/Pelicula");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string alumnoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();


                objeto.Mensaje = "La Pelicula fue registrada satisfactoriamente";
                objeto.Resultado = Constantes.EXITO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(objeto);
        }
    }
}

