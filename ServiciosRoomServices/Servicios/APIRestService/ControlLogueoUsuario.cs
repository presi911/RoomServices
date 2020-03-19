using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;
using Servicios.ILogicaNegocio;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;

namespace Servicios.APIRestService
{
    public class ControlLogueoUsuario : Servicios.ILogicaNegocio.ILogueUsuario
    {
        CapaDatos.IGestionInformacion.ILogueoUsuario datos;

        public ControlLogueoUsuario() {
            datos = new CapaDatos.ControlRepository.ControlLogueoUsuario();
        }

        public bool logueoDatosUser(string email, string contrasena)
        {
            return datos.logueoDatos(email, contrasena);
        }

        public string mostrarDatosPerfil(string cedula)
        {
            return datos.mostrarDatosPerfil(cedula).ToString();
        }

        public bool verificarAdministrador(string cedula)
        {
            return datos.verificarAdministrador(cedula);
        }

        public bool verificarArrendador(string cedula)
        {
            return datos.verificarArrendador(cedula);
        }

        public bool verificarArrendatario(string cedula)
        {
            return datos.verificarArrendatario(cedula);
        }
    }
}
