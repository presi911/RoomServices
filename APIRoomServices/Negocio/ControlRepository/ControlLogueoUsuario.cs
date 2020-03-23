using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ILogicaNegocio;

namespace Negocio.ControlRepository
{
    public class ControlLogueoUsuario : IControlLogueoUsuario
    {
        //Verificamos que el usuario se encuentre registrado
        public bool logueoDatosAcceso(string email, string contrasena)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities()) {

                var usuarioBD = (from item in entidades.CuentasUsuarios
                                 where (item.email.Equals(email) && item.contrasena.Equals(contrasena))
                                 select item);

                if (usuarioBD.ToList().Count==0) {

                    return false;
                }

                return true;

              }
             
        }

        /// <summary>
        /// Obtenemos la cedula del usuario registrado para poder cargar el perfil con el cual se registrò
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public String obtenerCedulaUsuario(string email, string contrasena)
        {

            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                bool ingreso = logueoDatosAcceso( email, contrasena);

                if (ingreso)
                {

                    var usuarioBD = (from item in entidades.CuentasUsuarios
                                     where (item.email.Equals(email) && item.contrasena.Equals(contrasena))
                                     select item);

                    return usuarioBD.First().cedulaUsuario;
                }
                else
                {
                    return "NaN";
                }
            }
        }


        /// <summary>
        /// Obtenemos datos de ingreso como administador
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public Administrador mostrarDatosAdministrador(string email, string contrasena)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                String cedulaAdm = obtenerCedulaUsuario(email, contrasena);

                if (!cedulaAdm.Equals("Nan")) {

                    bool esAdm = verificarAdministrador(cedulaAdm);

                    if (esAdm) {

                        var usuarioBD = (from item in entidades.Administradores
                                         where (item.cedula.Equals(cedulaAdm))
                                         select item);
                        var admin = usuarioBD.First();
                        return new Administrador(Int32.Parse(admin.cedula), admin.nombre + " " + admin.apellido);
                    
                    }
                
                }

                return null;


            }
        }
        /// <summary>
        /// Obtenemos datos de ingreso como arrendador
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public Arrendador mostrarDatosArrendador(string email, string contrasena)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {


                String cedula = obtenerCedulaUsuario(email, contrasena);

                if (!cedula.Equals("Nan"))
                {

                    bool esArrendador = verificarArrendador(cedula);

                    if (esArrendador)
                    {

                        var usuarioBD = (from item in entidades.Usuarios
                                         where (item.cedula.Equals(cedula))
                                         select item);

                        var user = usuarioBD.First();

                        return new Arrendador(user.cedula, user.nombre, user.apellido, user.fechaNacimiento,user.nacionalidad, user.genero[0]);

                    }

                }

                return null;
            }
        }

        /// <summary>
        /// Obtenemos datos de ingreso como arrendatario
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public Arrendatario mostrarDatosArrendatario(string email, string contrasena)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {


                String cedula = obtenerCedulaUsuario(email, contrasena);

                if (!cedula.Equals("Nan"))
                {
                    
                    bool esArrendatario = verificarArrendatario(cedula);

                    if (esArrendatario)
                    {

                        var usuarioBD = (from item in entidades.Usuarios
                                         where (item.cedula.Equals(cedula))
                                         select item);

                        var user = usuarioBD.First();

                        var arrend = (from item in entidades.Arrendatarios
                                         where (item.cedulaArrendatario.Equals(cedula))
                                         select item);

                        var infoArred = arrend.First();
                        return new Arrendatario(user.cedula, user.nombre, user.apellido, user.fechaNacimiento, user.nacionalidad, user.genero[0], infoArred.tipoArrendador);

                    }

                }

                return null;

            }
        }

        /// <summary>
        /// Verificamos si se encuentra registrado como administrador
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool verificarAdministrador(string cedula)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                var usuarioBD = (from item in entidades.Administradores
                                 where (item.cedula.Equals(cedula))
                                 select item);

                if (usuarioBD.ToList().Count == 0)
                {

                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Verificamos si se encuentra registrado como arrendador
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool verificarArrendador(string cedula)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                var usuarioBD = (from item in entidades.Arrendadores
                                 where (item.cedula.Equals(cedula))
                                 select item);

                if (usuarioBD.ToList().Count == 0)
                {

                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Verificamos si se encuentra registrado como arrendatario
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool verificarArrendatario(string cedula)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var usuarioBD = (from item in entidades.Arrendatarios
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
}
