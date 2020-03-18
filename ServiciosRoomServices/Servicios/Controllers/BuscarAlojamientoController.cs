using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Servicios.ILogicaNegocio;
using Servicios.APIRestService;
using Servicios.EntidadesDelDominio;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarAlojamientoController : ControllerBase
    {
        IBuscarAlojamiento obtenerInfo;
        
        public BuscarAlojamientoController()
        {
            obtenerInfo = new ControlBuscarAlojamiento();
        }

        // GET: api/BuscarAlojamiento
        [HttpGet]
        public IEnumerable<EntidadesDelDominio.Entidades.Alojamiento> BuscarAlojamiento(string filtro)
        {
            var m = 4;
            var alojamientos = obtenerInfo.ListarAlojamientos(filtro);

            return alojamientos.ToList();
        }

        // GET: api/BuscarAlojamiento/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BuscarAlojamiento
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BuscarAlojamiento/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
