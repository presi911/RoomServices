using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class LogueController : ApiController
    {
        // GET: api/Logue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Logue/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Logue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Logue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Logue/5
        public void Delete(int id)
        {
        }
    }
}
