using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.EntidadesDelDominio.Entidades;
using Servicios.ILogicaNegocio;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;
using IAlquilarAlojamiento = CapaDatos.IGestionInformacion.IAlquilarAlojamiento;

namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TomarAlquilerAlojamientoController : ControllerBase
    {
        IAlquilarAlojamiento Alquilar;
        public TomarAlquilerAlojamientoController()
        {
            Alquilar = new ControlAlqulilarAlojamiento();
        }

        // GET: api/AlquilerAlojamiento
        [HttpGet]
        public ICollection<EntidadesDelDominio.Entidades.Alquiler> AlquilarAlojamiento(int filtro)
        {
            //var alquiler = Alquilar.listarAlojamiento(filtro);


            return null;
        }

    }
}