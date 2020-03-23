using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.EntidadesDelDominio.Entidades;

namespace Negocio.ILogicaNegocio
{
    public interface IControlLogueoUsuario
    {
        bool logueoDatosAcceso(string email, string contrasena);
        bool verificarArrendador(string cedula);
        bool verificarArrendatario(string cedula);
        bool verificarAdministrador(string cedula);

        Arrendador mostrarDatosArrendador(string email, string contrasena);
        Arrendatario mostrarDatosArrendatario(string email, string contrasena);
        Administrador mostrarDatosAdministrador(string email, string contrasena);
    }
}
