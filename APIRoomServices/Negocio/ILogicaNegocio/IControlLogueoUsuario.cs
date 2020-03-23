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

        Arrendador mostrarDatosArrendador(String cedula);
        Arrendatario mostrarDatosArrendatario (String cedula);
        Administrador mostrarDatosAdministrador(String cedula);
    }
}
