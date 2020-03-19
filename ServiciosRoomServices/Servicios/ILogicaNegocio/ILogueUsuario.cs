using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Servicios.EntidadesDelDominio.Entidades;

namespace Servicios.ILogicaNegocio
{
    public interface ILogueUsuario
    {
        bool logueoDatosUser(string email, string contrasena);
        bool verificarArrendador(string cedula);
        bool verificarArrendatario(string cedula);
        bool verificarAdministrador(string cedula);
        string mostrarDatosPerfil(String cedula);

    }
}
