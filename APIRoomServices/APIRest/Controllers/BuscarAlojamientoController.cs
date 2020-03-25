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

        /// <summary>
        /// A partir de un criterio de búsqueda específicado por el usuario, consulta y retorna una lista de alojamientos
        /// que cumplen con el criterio específicado
        /// </summary>
        /// <param name="filtro">Cadena, Criterio de consulta específicado por el usuario</param>
        /// <returns>Lista de Objetos JObject (JSON) con la información básica de los alojamientos encontrados</returns>
        // GET api/values
        [HttpGet]
        public IList<JObject> GetConsultarAlojamientos(string filtro)
        {

            return control.ListarAlojamientos(filtro);
            
        }

        /// <summary>
        /// Consulta en el repositorio y retorna la información completa de un alojamiento proporcionando como criterio de 
        /// consulta el id de habitación
        /// </summary>
        /// <param name="id">Entero, identificador de habitación</param>
        /// <returns>Objeto JObject (JSON) con la información del alojamiento, arrendador, calificacion...</returns>
        // GET api/values/5
        [HttpGet]
        public JObject ConsultarInformacionAlojamiento(int id)
        {
            return control.RetornarInformacionAlojamiento(id);

        }
        
    }
}
