using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ControlRepository;

using APIRest.IServices;

namespace APIRest.APIRestService
{
    public class ControlRegistrarUsuario : IControlRegistroUsuario

    {
        readonly Negocio.ILogicaNegocio.IControlRegistrarUsuario control;

        public ControlRegistrarUsuario()
        {
            control = new Negocio.ControlRepository.ControlRegistrarUsuario();

        }

       
        public bool ConsultarUsuario(string cedulaUsuario)
        {
            throw new NotImplementedException();
        }

        public Boolean RegistrarUsuario(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero, string email, string contrasena)
        {
            return control.RegistrarUsuario(cedula, nombre, apellido, fecha, nacionalidad, genero,email,contrasena);

        }
    }
}