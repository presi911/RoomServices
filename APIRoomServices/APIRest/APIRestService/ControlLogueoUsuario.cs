using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ControlRepository;

using APIRest.IServices;
using Newtonsoft.Json.Linq;

namespace APIRest.APIRestService
{
    public class ControlLogueoUsuario : IControlLogueoUsuario
    {
        readonly Negocio.ILogicaNegocio.IControlLogueoUsuario control;
        public ControlLogueoUsuario() { 
            
            control = new Negocio.ControlRepository.ControlLogueoUsuario();

        }

        public JObject informacionLogueUsuario(string email, string contrasena)
        {

            Administrador adm = mostarAdministrador(email, contrasena);
            Arrendador arrendadorUser = mostarArrendador(email, contrasena);
            Arrendatario arrendatarioUser = mostarArrendatario(email, contrasena);

            if (adm != null) {

                return JObject.FromObject( new { 
                
                    administrador = new { 
                        mensaje="Inicio de Sesión ADMINISTRADOR :) Bienvenido "+ adm.NombreAdministrador,
                        cedula = adm.CedulaAdministrador,
                        nombre = adm.NombreAdministrador
                    }
                });

            }  
            
            if (arrendadorUser!= null) {

                return JObject.FromObject(new
                {
                    arrendador = new { 
                        mensaje="Inicio de Sesión ARRENDADOR :) Bienvenido "+ arrendadorUser.Nombre,
                        tipoUsuario="Arrendador",
                        cedula = arrendadorUser.Cedula,
                        nombre = arrendadorUser.Nombre,
                        apellido = arrendadorUser.Apellido,
                        fechaNacimiento = arrendadorUser.Fecha,
                        nacionalidad= arrendadorUser.Nacionalidad,
                        genero = arrendadorUser.Genero

                    }
                });

            }

            if (arrendatarioUser !=null) {


                return JObject.FromObject(new
                {
                    Arrendatario = new { 
                        mensaje="Inicio de Sesión ARRENDATARIO :) Bienvenido "+ arrendatarioUser.Nombre,
                        tipoUsuario = "Arrendatario",
                        tipoArredatario = arrendatarioUser.TipoArrendador,
                        cedula = arrendatarioUser.Cedula,
                        nombre = arrendatarioUser.Nombre,
                        apellido = arrendatarioUser.Apellido,
                        fechaNacimiento = arrendatarioUser.Fecha,
                        nacionalidad = arrendatarioUser.Nacionalidad,
                        genero = arrendatarioUser.Genero

                    }
                


                });
            }


            return JObject.FromObject(new
            {
                error = new
                {
                    tipoError = 404,
                    mensaje ="No se puede iniciar sesión",
                    descripcion = "El usuario no se encuentra registrado :("
                }
            }) ;

        }

        public Administrador mostarAdministrador(string email, string contrasena)
        {
            return control.mostrarDatosAdministrador(email, contrasena); 
        }

        public Arrendador mostarArrendador(string email, string contrasena)
        {
            return control.mostrarDatosArrendador(email, contrasena); 
        }

        public Arrendatario mostarArrendatario(string email, string contrasena)
        {
           return control.mostrarDatosArrendatario(email, contrasena); 
        }

        public bool permisoIngreso(string email, string contrasena)
        {
            return control.logueoDatosAcceso(email, contrasena);
        }
    }
}