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
        string postdata = "{\"IdPromocion\":\"1\",\"Puntos\":\"15\",\"VigenciaInicio\":\"01/10/2012\",\"VigenciaFin\":\"31/12/2012\",\"IdProducto\":\"1\",\"ProductoNombre\":\"P1\",\"Estado\":\"A\"}"; //JSON
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
        ResultadoBE promocionCreado = js.Deserialize<ResultadoBE>(promocionJson);
        Assert.AreEqual("La Oferta ingresada fue registrada con éxito", promocionCreado.Mensaje);
        

        // Prueba de Obtencion de la promoción via HTTP GET
        string postdata2 = "{\"VigenciaInicio\":\"01/10/2012\",\"VigenciaFin\":\"31/12/2012\"}"; //JSON
        byte[] data2 = Encoding.UTF8.GetBytes(postdata2);
        HttpWebRequest req2 = (HttpWebRequest)WebRequest
        .Create("http://localhost:12136/Service/PromocionService.svc/Promociones");
        req2.Method = "POST";
        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
        StreamReader reader2 = new StreamReader(res2.GetResponseStream());
        string promocionJson2 = reader2.ReadToEnd();
        JavaScriptSerializer js2 = new JavaScriptSerializer();
        List<PromocionBE> promocionObtenido = js2.Deserialize<List<PromocionBE>>(promocionJson2);
        Assert.AreEqual(2, promocionObtenido.Count);

        // Prueba de Eliminacion de promociones via HTTP DELETE
        HttpWebRequest req4 = (HttpWebRequest)WebRequest.Create("http://localhost:12136/Service/PromocionService.svc/Promocion/1");
        req4.Method = "DELETE";
        HttpWebResponse res4 = (HttpWebResponse)req4.GetResponse();
        StreamReader reader4 = new StreamReader(res4.GetResponseStream());
        string promocionJaon4 = reader4.ReadToEnd();
        JavaScriptSerializer js4 = new JavaScriptSerializer();
        }
    }
}
