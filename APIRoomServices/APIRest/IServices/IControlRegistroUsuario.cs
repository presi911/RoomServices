using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRest.IServices
{
    public interface IControlRegistroUsuario
    {

        Boolean RegistrarUsuario(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero, string email, string contrasena);
        Boolean ConsultarUsuario(string cedulaUsuario);
    }
}