using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WebServiceAlojamiento()
        {
            var httpClient = new HttpClient();
            var direccion = "https://localhost:44337/api/BuscarAlojamiento";
            var json = httpClient.GetAsync(direccion).Result;
            Assert.AreEqual(json.StatusCode, HttpStatusCode.OK);
        }
    }
}