using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.IGestionInformacion;

namespace CapaDatos.ControlRepository
{
    public class ControlLogueoUsuario : ILogueoUsuario
    {
        RoomServicesEntities modeloBD;


        public ControlLogueoUsuario() {
            modeloBD = new RoomServicesEntities();
        }

        public Usuarios cargarDatosPeril(string cedula)
        {
            var usuarioBD = (from item in modeloBD.Usuarios
                                     where (item.cedula.Equals(cedula))
                                     select item);
            return usuarioBD.ToList()[0];
        }

        public CuentasUsuarios logueoDatos(string email, string contrasena)
        {
            var usuarioBD = (from item in modeloBD.CuentasUsuarios
                             where (item.email.Equals(email) && item.contrasena.Equals(contrasena))
                             select item);

            return new CuentasUsuarios(usuarioBD);
        }

        public Usuarios mostrarPerfil(string cedula)
        {
            throw new NotImplementedException();
        }

        public Administradores verificarAdministrador(string cedula)
        {
            throw new NotImplementedException();
        }

        public Arrendatarios verificarArrendador(string cedula)
        {
            throw new NotImplementedException();
        }

        public Arrendadores verificarArrendatario(string cedula)
        {
            throw new NotImplementedException();
        }
    }
}
