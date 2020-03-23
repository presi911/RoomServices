using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Servicios.EntidadesDelDominio.Entidades;

namespace Servicios.ILogicaNegocio
{
    public interface ILogueUsuario
    {
        CuentaUsuario logueDatos(string email, string contrasena);
        Arrendador verificarArrendador(string cedula);
        Arrendatario verificarArrendatario(string cedula);
        Administrador verificarAdministrador(string cedula);



    }
}
