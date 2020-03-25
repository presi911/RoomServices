using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class RegistroUsuarioController : ApiController
    {
        // GET: api/RegistroUsuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RegistroUsuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegistroUsuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RegistroUsuario/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/RegistroUsuario/5
        public void Delete(int id)
        {
        }
    }
}
