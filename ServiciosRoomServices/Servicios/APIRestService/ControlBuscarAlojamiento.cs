using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;

using Servicios.ILogicaNegocio;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace Servicios.APIRestService

{
    public class ControlBuscarAlojamiento : Servicios.ILogicaNegocio.IBuscarAlojamiento
    {

        CapaDatos.IGestionInformacion.IBuscarAlojamiento acciones;

        public ControlBuscarAlojamiento()
        {
            acciones = new CapaDatos.ControlRepository.ControlBuscarAlojamiento();
        }

        /// <summary>
        /// Obtiene el alojamiento traído desde la capa de datos, lo instancia en el modelo de entidades para la clase
        /// Alojamiento y lo retorna
        /// </summary>
        /// <param name="idAlojamiento">dato númerico con el id de la habitación a consultar</param>
        /// <returns>objeto tipo Alojamiento con información reelevante como id,titulo,precio..</returns>
        public Alojamiento ConsultarAlojamiento(int idAlojamiento)
        {
            var alojamientoDatos=acciones.ConsultarAlojamiento(idAlojamiento);

            return alojamientoDatos == null ? null : new Alojamiento()
            {
                IdAlojamiento = (int)alojamientoDatos.idAlojamiento,
                Titulo = alojamientoDatos.titulo,
                Precio = (double)alojamientoDatos.precio,
                Estado = alojamientoDatos.estado,
                //Se debe organizar
                UbicacionAlojamiento = new Ubicacion()
            };
        }

        public Alojamiento ConsultarDescripcionAlojamiento()
        {
            throw new NotImplementedException();
        }

        public Arrendador ConsultarInformacionArrendador(string cedulaArrendador)
        {
            //consulto los datos básicos del arrendador:
            var arrendadorDatos = acciones.ConsultarInformacionArrendador(cedulaArrendador);
            //consulto los datos completos de la clase padre Usuario en la base de datos:
            var usuarioDatos = acciones.ConsultarUsuario(cedulaArrendador);

            //asigno los datos obtenidos de la capa de datos a variables:
            string cedula = usuarioDatos.cedula;
            string nombre = usuarioDatos.cedula;
            string apellido = usuarioDatos.apellido;
            DateTime fecha = (DateTime) usuarioDatos.fechaNacimiento;
            string nacionalidad = usuarioDatos.nacionalidad;
            char genero = usuarioDatos.genero.ToCharArray()[0];

            //retorno el objeto de tipo arrendador con los datos que requiere el controlador
            return new Arrendador(cedula, nombre, apellido, fecha, nacionalidad, genero)
            {
                IdArrendador = arrendadorDatos.idArrendador

            };
        }

        /// <summary>
        /// Permite obtener un listado con los Alojamientos que cumplen con el filtro específicado por el usuario
        /// </summary>
        /// <param name="filtro">cadena de texto con el filtro específicado por el usuario</param>
        /// <returns></returns>
        public List<Alojamiento> ListarAlojamientos(string filtro)
        {

            var alojamientosList= acciones.ListarAlojamientos(filtro);

            List<Alojamiento> alojamientos= new List<Alojamiento>();
            foreach (var alojamiento in alojamientosList)
            {
                alojamientos.Add(new Alojamiento()
                {
                    IdAlojamiento = (int)alojamiento.idAlojamiento,
                    Titulo = alojamiento.titulo,
                    Precio = (double)alojamiento.precio,
                    Estado= alojamiento.estado,
                    //Se debe organizar
                    UbicacionAlojamiento = new Ubicacion()
                }) ;
            }

            return alojamientos;

        }

        public Arrendador ConsultarArrendadorHabitacion(int idAlojamiento) {
            
            //A partir de el id de un alojamiento consulta el arrendatario que publicó dicho alojamiento:
            var arrendatario = acciones.ConsultarArrendadorHabitacion(idAlojamiento);
            //Retorna una Entidad tipo Arrendatario con TODOS los atributos necesarios para extraer su información:
            return ConsultarInformacionArrendador(arrendatario.cedula);
        }

        /// <summary>
        /// Obtiene el promedio de todas las calificaciones realizadas a una habitación específico desde la capa de datos y lo retorna
        /// </summary>
        /// <param name="idHabitacion">dato númerico con el id de la habitación de la cual se desea obtener el promedio</param>
        /// <returns>double con el promedio de calificaciones de la habitación</returns>
        public double PromedioCalificaciones(int idHabitacion)
        {
            return acciones.PromedioCalificaciones(idHabitacion);
        }


        /// <summary>
        /// A partir de un ID de habitación, busca y retorna todos los datos reelevantes de la misma, puntuaciones realizadas,
        /// información de la habitación y datos del arrendador
        /// </summary>
        /// <param name="idHabitacion">id de la habitación consultada</param>
        /// <returns>Objeto tipo JSON con la información del alojamiento solicitado</returns>
        public JObject RetornarInformacionAlojamiento(int idHabitacion)
        {
            //Obtengo el promedio de calificaciones realizadas a la habitación:
            var promedioCalificacion = this.PromedioCalificaciones(idHabitacion);
            //Obtengo algunos datos básicos del alojamiento que estoy consultando
            var alojamiento = this.ConsultarAlojamiento(idHabitacion);
            //A partir  del id del alojamiento, obtengo el arrendatario que me va a proporcionar la información que se necesita enviar
            
           
            return ArmarJSONInformacion(promedioCalificacion, alojamiento);
              
        }

        /// <summary>
        /// Arma un objeto JSON con la información proporcionada y lo retorna, la información recibida es null retorna un JSON informando
        /// la excepción ocurrida.
        /// </summary>
        /// <param name="promedioCalificacion"></param>
        /// <param name="alojamiento"></param>
        /// <param name="arrendador"></param>
        /// <returns></returns>
        public JObject ArmarJSONInformacion(double promedioCalificacion,Alojamiento alojamiento)
        {
            if (alojamiento != null)
            {
                var arrendador = this.ConsultarArrendadorHabitacion(alojamiento.IdAlojamiento);
                return JObject.FromObject(new
                {
                    alojamiento = new
                    {
                        idAlojamiento = alojamiento.IdAlojamiento,
                        titulo = alojamiento.Titulo,
                        precio = alojamiento.Precio,
                        estado = alojamiento.Estado
                    },
                    arrendador = new
                    {
                        id = arrendador.IdArrendador,
                        nombre = arrendador.Nombre,
                        apellido = arrendador.Apellido,
                    },
                    calificacion = promedioCalificacion

                });
            }else
            {
                return JObject.FromObject(new
                {
                    error = new
                    {
                        tipoError = 404,
                        descripcion = "El alojamiento solicitado no existe o ya no se encuentra disponible :("
                    }
                });

            }
        }


    }
}
