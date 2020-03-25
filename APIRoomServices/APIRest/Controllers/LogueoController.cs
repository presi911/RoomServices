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
    public class LogueoController : ApiController
    {
        readonly IControlLogueoUsuario control;

        public LogueoController()
        {
            control = new APIRestService.ControlLogueoUsuario();
        }
        /// <summary>
        /// Se obtiene información de logueo
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>

        // GET: api/Logue
        public JObject Get(string email, string contrasena)
        {
            return control.informacionLogueUsuario(email, contrasena);
        }

        /// <summary>
        /// Veridicar si tiene permiso el usuario para ingresar al sistema por medio del logueo
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>

        // GET: api/Logue/5
        public string GetPermisoIngreso(string correoUsuario,string contrasenaUsuario)
        {
            return control.permisoIngreso(correoUsuario, contrasenaUsuario).ToString();
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
