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
    public class LogueoUsuarioController : ControllerBase
    {

        ILogueUsuario obtenerIngresoUsuario;

        public LogueoUsuarioController()
        {

            obtenerIngresoUsuario = new ControlLogueoUsuario();
        }

            // GET: api/Login
        [HttpGet]
        public bool Login(string email, string contrasena)
        {
            var user = obtenerIngresoUsuario.logueoDatosUser(email, contrasena);
            return user;
        }

        // GET: api/DatosUsuario
        [HttpGet]
        public string mostrarDatosPerfil(string cedula)
        {
            var user = obtenerIngresoUsuario.mostrarDatosPerfil(cedula);
            return user;
        }

        // GET: api/VerificarAdministrador
        [HttpGet]
        public bool verificarAdministrador(string cedula)
        {
            var user = obtenerIngresoUsuario.verificarAdministrador(cedula);
            return user;
        }

        // GET: api/VerificarArrendatario
        [HttpGet]
        public bool verificarArrendatario(string cedula)
        {
            var user = obtenerIngresoUsuario.verificarArrendatario(cedula);
            return user;
        }

        // GET: api/VerificarArrendador
        [HttpGet]
        public bool verificarArrendador(string cedula)
        {
            var user = obtenerIngresoUsuario.verificarArrendador(cedula);
            return user;
        }




    }



    }