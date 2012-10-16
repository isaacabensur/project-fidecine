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
using FIDECINEWeb.PeliculaServiceReference;

namespace FIDECINEWeb.Controllers
{
    public class AdministrarPeliculaController : Controller
    {
        public ActionResult Index()
        {
            PeliculaModel objModel = new PeliculaModel();

            objModel.lstGenero = (new PeliculaServiceClient().ListarGeneroPelicula()).ToList<PeliculaBE>();
            objModel.lstTipo = (new PeliculaServiceClient().ListarTipoPelicula()).ToList<PeliculaBE>();
            objModel.lstCategoria = (new PeliculaServiceClient().ListarCategoriaPelicula()).ToList<PeliculaBE>();

/*            //new PeliculaServiceClient().
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/PeliculaService.svc/GeneroPelicula");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string strLista = reader.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<PeliculaBE> lstGenero = js2.Deserialize<List<PeliculaBE>>(strLista);
            
            

            // LstCategorio
            req = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/PeliculaService.svc/CategoriaPelicula");
            req.Method = "GET";
            res = (HttpWebResponse)req.GetResponse();
            reader = new StreamReader(res.GetResponseStream());
            strLista = reader.ReadToEnd();
            js2 = new JavaScriptSerializer();
            List<PeliculaBE> lstCategoria = js2.Deserialize<List<PeliculaBE>>(strLista);

            objModel.lstCategoria = lstCategoria;

            // Lista TIPO
            req = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/PeliculaService.svc/TipoPelicula");
            req.Method = "GET";
            res = (HttpWebResponse)req.GetResponse();
            reader = new StreamReader(res.GetResponseStream());
            strLista = reader.ReadToEnd();
            js2 = new JavaScriptSerializer();
            List<PeliculaBE> lstTipo = js2.Deserialize<List<PeliculaBE>>(strLista);

            objModel.lstTipo = lstTipo;
            */


            return View("../Administracion/AdministrarPelicula", objModel);
        }

        [HttpPost]
        public JsonResult insertarPelicula(string nombre, string descripcion, string trailer, string cboGenero,
            string cboCategoria, string cboTipo, string cboestado, string duracion)
        {
            PeliculaModel objeto = new PeliculaModel();

            PeliculaBE objPeliculaBE = new PeliculaBE(){
                Nombre = nombre,
                Descripcion = descripcion,
                Trailer = trailer,
                IdGenero = Int32.Parse(cboGenero),
                IdCategoria = Int32.Parse(cboCategoria),
                IdTipo = Int32.Parse(cboTipo),
                Estado = cboestado,
                Duracion =  Int32.Parse(duracion)
            };
            new PeliculaServiceClient().InsertarPelicula(objPeliculaBE);

            objeto.Mensaje = "La Pelicula fue registrada satisfactoriamente";
            objeto.Resultado = Constantes.EXITO;

            /*try

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
             */
            return Json(objeto);
        }

        public JsonResult buscarPelicula(string strNombre, string strIdCategoria, string strIdTipo, string strIdGenero, string strEstado)
        {
            
            PeliculaModel objClienteModel = new PeliculaModel();
            objClienteModel.lstPeliculas = new PeliculaServiceClient().ListarPeliculas(strNombre, strIdCategoria, strIdTipo, strIdGenero, strEstado).ToList<PeliculaBE>();

            return Json(objClienteModel);
        }

        [HttpPost]
        public JsonResult eliminarPelicula(int IdPelicula)
        {

            new PeliculaServiceClient().EliminarPelicula(IdPelicula.ToString());
            PeliculaModel objPeliculaModel = new PeliculaModel();
            objPeliculaModel.Mensaje = "La Pelicula fue eliminada exitosamente";
            objPeliculaModel.Resultado = Constantes.EXITO;

            return Json(objPeliculaModel);

        }
    }
}

