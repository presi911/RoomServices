using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.IGestionInformacion
{
    public interface ILogueoUsuario
    {
        CuentasUsuarios logueoDatos(string email, string contrasena);
        Arrendatarios verificarArrendador(string cedula);
        Arrendadores verificarArrendatario(string cedula);
        Administradores verificarAdministrador(string cedula);
        Usuarios mostrarPerfil(String cedula);
    }
}
