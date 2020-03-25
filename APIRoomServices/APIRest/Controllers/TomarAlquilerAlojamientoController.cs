using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Negocio.ControlRepository;
using Dominio;
using Datos;
using APIRest.IServices;
using APIRest.APIRestService;
using Newtonsoft.Json.Linq;
namespace APIRest.Controllers
{
    public class TomarAlquilerAlojamientoController : ApiController
    {
        readonly IControlTomarAlquilerAlojamiento control;
        public TomarAlquilerAlojamientoController()
        {
            control = new APIRestService.ControlTomarAlquilerAlojamiento();
        }
        // GET: api/TomarAlquilerAlojamiento
        public JObject GET(int idAlojamiento, String cedulaArrendador, String cedulaArrendatario)
        {
            return control.InformacionAlojamientoGeneral(idAlojamiento, cedulaArrendador, cedulaArrendatario);
        }

        // POST: api/TomarAlquilerAlojamiento
        public Boolean Post(int numeroContrato, int numeroMeses, decimal pagoMensual, string fechaAlquiler, int idAlojamiento)
        {
            return control.ingresarDatosFaltantes(numeroContrato,numeroMeses,pagoMensual,fechaAlquiler,idAlojamiento);
        }

    }
}
