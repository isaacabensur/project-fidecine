using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using FIDECINEService;
using FIDECINEService.Dominio;

namespace FIDECINETest
{
    [TestClass]
    public class RestPromociones
    {
        [TestMethod]
        public void CRUDPromocionesTest()
        {
            // Prueba de creación de nueva promoción vía HTTP POST
            string postdata = "{\"IdPromocion\":\"1\",\"nombrepromocion\":\"Entrada gratis\",\"puntos\":\"15\",\"regalo\":\"1\",\"vigenciaInicio\":\"01/10/2012\",\"vigenciaFin\":\"31/12/2012\",\"IdProducto\":\"1\",\"ProductoNombre\":\"P1\",\"Estado\":\"A\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:12136/Service/PromocionService.svc/Promocion");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string promocionJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            PromocionBE promocionCreado = js.Deserialize<PromocionBE>(promocionJson);
            Assert.AreEqual("1", promocionCreado.IdPromocion);
            Assert.AreEqual("Entrada gratis", promocionCreado.ProductoNombre);

            // Prueba de Obtencion de la promoción via HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:12136/Service/PromocionService.svc/Promocion/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string promocionJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            PromocionBE promocionObtenido = js2.Deserialize<PromocionBE>(promocionJson2);
            Assert.AreEqual(1, promocionObtenido.IdPromocion);
          
        }
    }
}
