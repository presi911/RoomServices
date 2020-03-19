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
        public EntidadesDelDominio.Entidades.CuentaUsuario Login(string email, string contrasena)
        {

            var user = obtenerIngresoUsuario.logueDatos(email, contrasena);
            return user;
        }


    }



    }