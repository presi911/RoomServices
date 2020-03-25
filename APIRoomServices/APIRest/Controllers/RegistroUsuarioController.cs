using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using APIRest.IServices;
using APIRest.APIRestService;

namespace APIRest.Controllers
{
    public class RegistroUsuarioController : ApiController
    {
        readonly IControlRegistroUsuario control;

        public RegistroUsuarioController()
        {
            control = new APIRestService.ControlRegistrarUsuario();
        }

      

        // PUT: api/RegistroUsuario/5
        public void Put(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero, string email, string contrasena)
        {
            control.RegistrarUsuario(cedula,nombre,apellido,fecha,nacionalidad,genero,email,contrasena);

        }


        // POST: api/RegistroUsuario
        public Boolean Post(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero, string email, string contrasena)
        {
            return control.RegistrarUsuario(cedula, nombre, apellido, fecha, nacionalidad, genero,email,contrasena);
        }

    }
}

