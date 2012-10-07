using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using FIDECINEService;

namespace FIDECINETest
{
  
    [TestClass]
    public class RestTestCliente
    {
        [TestMethod]
        public void CRUDClienteTest()
        {
            // Prueba de creación de alumno vía HTTP POST
            string postdata = "{\"idcliente\":\"1\",\"nombre\":\"Juan\",\"apellidoPaterno\":\"Juan\",\"apellidoMaterno\":\"Juan\",\"dni\":\"Juan\",\"estado\":\"Juan\"}"; //JSON
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
            /*Cliente clienteCreado = js.Deserialize<Cliente>(alumnoJson);
            Assert.AreEqual("1", clienteCreado.idcliente);
            Assert.AreEqual("Juan", clienteCreado.nombre);*/
        }
    }
}
