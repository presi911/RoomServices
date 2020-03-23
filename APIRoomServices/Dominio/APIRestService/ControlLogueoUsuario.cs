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

        public CuentaUsuario logueDatos(string email, string contrasena)
        {
            var logueoBD = datos.logueoDatos(email, contrasena);
            CuentaUsuario user = new CuentaUsuario(logueoBD.email, logueoBD.contrasena);

            return user;
        }

        public Administrador verificarAdministrador(string cedula)
        {
            throw new NotImplementedException();
        }

        public Arrendador verificarArrendador(string cedula)
        {
            throw new NotImplementedException();
        }

        public Arrendatario verificarArrendatario(string cedula)
        {
            throw new NotImplementedException();
        }
    }
}
