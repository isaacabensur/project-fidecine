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
    public class RestTestCliente
    {
        [TestMethod]
        public void CRUDClienteTest()
        {
            // Prueba de creación de alumno vía HTTP POST
            /*string postdata = "{\"nombre\":\"Juan\",\"apellidoPaterno\":\"Juan\",\"apellidoMaterno\":\"Juan\",\"dni\":\"7\",\"direccion\":\"AvS\",\"tipocliente\":\"P\",\"estado\":\"A\"}"; //JSON
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
            Assert.AreEqual("Juan", clienteCreado.nombre);

            // Prueba de Obtencion de alumno via HTTP GET
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente/1");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            ClienteBE alumnoObtenido = js2.Deserialize<ClienteBE>(alumnoJson2);
            Assert.AreEqual(1, alumnoObtenido.idcliente);
            */

            //Prueba de Modificación de alumnos via HTTP POST
            string postdata3 = "{\"idcliente\":\"1\",\"nombre\":\"Juan2\",\"direccion\":\"NuvaDireccion\",\"tipocliente\":\"C\"}"; // JSON
            byte[] data3 = Encoding.UTF8.GetBytes(postdata3);
            HttpWebRequest req3 = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente");
            req3.Method = "PUT";
            req3.ContentLength = data3.Length;
            req3.ContentType = "application/json";
            var reqStream3 = req3.GetRequestStream();
            reqStream3.Write(data3, 0, data3.Length);
            var res3 = (HttpWebResponse)req3.GetResponse();
            StreamReader reader3 = new StreamReader(res3.GetResponseStream());
            string alumnoJson3 = reader3.ReadToEnd();
            JavaScriptSerializer js3 = new JavaScriptSerializer();
            ClienteBE alumnoModificado = js3.Deserialize<ClienteBE>(alumnoJson3);
            Assert.AreEqual(1, alumnoModificado.idcliente);
            //Assert.AreEqual("Juan", alumnoModificado.nombre);


            // Prueba de Eliminacion de alumno via HTTP DELETE
            /*HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente/1");
            req2.Method = "DELETE";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer  js2 = new JavaScriptSerializer();*/


            //Prueba de obtencion de listado via HTTP GET
            /*HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:12139/Service/ClienteService.svc/Cliente/Juan/7/AvS/A");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson2 = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<ClienteBE> alumnosAll = js2.Deserialize<List<ClienteBE>>(alumnoJson2);
            Assert.AreEqual(1, alumnosAll.Count);
           */
        }
    }
}
