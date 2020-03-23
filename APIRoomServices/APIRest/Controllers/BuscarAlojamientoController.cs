using System.Collections.Generic;
using System.Web.Http;
using Negocio.ControlRepository;
using Dominio;
using Datos;
using APIRest.IServices;
using APIRest.APIRestService;
using Newtonsoft.Json.Linq;

namespace APIRest.Controllers
{
    public class BuscarAlojamientoController : ApiController
    {
        readonly IControlBuscarAlojamiento control;

        public BuscarAlojamientoController()
        {
            control = new APIRestService.ControlBuscarAlojamiento();
        }


        // GET api/values
        [HttpGet]
        public IList<JObject> GetConsultarAlojamientos(string filtro)
        {

            return control.ListarAlojamientos(filtro);
            
        }

        // GET api/values/5
        [HttpGet]
        public JObject ConsultarInformacionAlojamiento(int id)
        {
            return control.RetornarInformacionAlojamiento(id);
        }
        
    }
}
