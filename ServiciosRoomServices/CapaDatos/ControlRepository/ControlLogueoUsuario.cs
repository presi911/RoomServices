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

        public Usuarios mostrarDatosPerfil(string cedula)
        {
            var usuarioBD = (from item in modeloBD.Usuarios
                                     where (item.cedula.Equals(cedula))
                                     select item);
            return usuarioBD.ToList()[0];
        } 

        public bool logueoDatos(string email, string contrasena)
        {
            var usuarioBD = (from item in modeloBD.CuentasUsuarios
                             where (item.email.Equals(email) && item.contrasena.Equals(contrasena))
                             select item);
            

            if (usuarioBD.ToList().Count==0) {

                return false;
            }
            return true;
        }


        public bool verificarAdministrador(string cedula)
        {
            var usuarioBD = (from item in modeloBD.Administradores
                             where (item.cedula.Equals(cedula))
                             select item);

            if (usuarioBD.ToList().Count == 0)
            {

                return false;
            }
            return true;

        }

        public bool verificarArrendador(string cedula)
        {
            var usuarioBD = (from item in modeloBD.Arrendadores
                             where (item.cedula.Equals(cedula))
                             select item);

            if (usuarioBD.ToList().Count == 0)
            {

                return false;
            }
            return true;
        }

        public bool verificarArrendatario(string cedula)
        {
            var usuarioBD = (from item in modeloBD.Arrendatarios
                             where (item.cedulaArrendatario.Equals(cedula))
                             select item);

            if (usuarioBD.ToList().Count == 0)
            {

                return false;
            }
            return true;

        }
    }
}
