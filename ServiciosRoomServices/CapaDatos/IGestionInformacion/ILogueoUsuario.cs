using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.IGestionInformacion
{
    public interface ILogueoUsuario
    {
        bool logueoDatos(string email, string contrasena);
        bool verificarArrendador(string cedula);
        bool verificarArrendatario(string cedula);
        bool verificarAdministrador(string cedula);

        Usuarios mostrarDatosPerfil(String cedula);
    }
}
