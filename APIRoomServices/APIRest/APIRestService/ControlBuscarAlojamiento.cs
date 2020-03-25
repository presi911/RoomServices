using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ControlRepository;

using APIRest.ExcepcionesAPIRestService;


using APIRest.IServices;
using Newtonsoft.Json.Linq;

namespace APIRest.APIRestService
{
    public class ControlBuscarAlojamiento : IControlBuscarAlojamiento
    {
        readonly Negocio.ILogicaNegocio.IControlBuscarAlojamiento control;

        public ControlBuscarAlojamiento()
        {
            control = new Negocio.ControlRepository.ControlBuscarAlojamiento();

        }


        
        /// <summary>
        /// Consulta y retorna un objeto tipo alojamiento proporcionando como criterio de consulta su ID.
        /// </summary>
        /// <param name="idAlojamiento">Entero, identificador de alojamiento en la base de datos.</param>
        /// <returns>Objeto tipo alojamiento con todo sus atributos, titulo, precio, descripción...</returns>
        public Alojamiento ConsultarAlojamiento(int idAlojamiento)
        {
            return control.ConsultarAlojamiento(idAlojamiento);
        }



        /// <summary>
        /// Consulta y retorna un objeto tipo Arrendador, proporcionando como parámetro el su cédula
        /// </summary>
        /// <param name="cedulaArrendador">Cadena, cédula del arrendador a consultar</param>
        /// <returns>Objeto tipo arrendador con todos sus atributos: cédula,nombre,apellidos,edad...</returns>
        public Arrendador ConsultarInformacionArrendador(string cedulaArrendador)
        {

            string cedula = cedulaArrendador.Trim();
            return control.ConsultarInformacionArrendador(cedula);

        }



        /// <summary>
        /// Calcula y retorna el promedio de las calificaciones que se han realizado a una habitación proporcionando
        /// como parámetro el id de la habitación a la cual se desea consultar el promedio.
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns>Número decimal con el promedio de calificaciones</returns>
        public double ConsultarPromedioCalificaciones(int idHabitacion)
        {
            return control.PromedioCalificaciones(idHabitacion);
        }



        /// <summary>
        /// Consulta y retorna una colección de alojamientos en formato JSON (JOBJECT) especificando como parámetro
        /// un criterio de consulta
        /// </summary>
        /// <param name="filtro">Cadena, criterio o palabras clave de consulta espefíficado por el usuario</param>
        /// <returns>Colección de objetos JObject (JSON) con las habitaciones que cumplen el criterio de consulta</returns>
        public IList<JObject> ListarAlojamientos(string filtro)
        {

            filtro = filtro.Trim();
            IList<JObject> alojamientosJSON = new List<JObject>();

            var alojamientos = control.ListarAlojamientos(filtro);
            if (alojamientos.Count > 0) {
                foreach (var item in alojamientos)
                {
                    alojamientosJSON.Add(JObject.FromObject(new
                    {
                        estatus = 200,
                        result = new
                        {
                            idHabitacion = item.IdAlojamiento,
                            titulo = item.Titulo,
                            tipoAlojamiento = item.TipoAlojamiento,
                            estado = item.Estado,
                            precio = item.Precio
                        }
                    }));
                }
                return alojamientosJSON;
            }
            else
            {
                alojamientosJSON.Add(BuscarAlojamientoException.ArmarJSONInformacionException("sin resultados"));
                return alojamientosJSON;
            }
            
        }



        /// <summary>
        /// Consulta un objeto tipo Arrendador con todos sus atributos, proporcionando como criterio de consulta el id
        /// de la habitación que tiene en arriendo
        /// </summary>
        /// <param name="IdAlojamiento">Entero, identificador de la habitación que tiene en arriendo</param>
        /// <returns>Objeto tipo Arrendador con todos sus atributos, nombre,apellidos,edad,género</returns>
        public Arrendador ConsultarInformacionArrendadorHabitacion(int IdAlojamiento)
        {
            return control.ConsultarInformacionArrendadorHabitacion(IdAlojamiento);
        }

        

        /// <summary>
        /// Consulta y retorna la información completa  en formato JSON (JSONObject)de un Alojamiento específicando 
        /// como parámetro su id De Alojamiento,Especificando como parámetro el id de alojamiento
        /// </summary>
        /// <param name="idAlojamiento">Entero, identificador de alojamiento al cual deseo consultar la información</param>
        /// <returns>Objeto JSON(JObject) con los datos de alojamiento, arrendador y promedio de calificaciones</returns>
        public JObject RetornarInformacionAlojamiento(int idAlojamiento)
        {
            double promedio = this.ConsultarPromedioCalificaciones(idAlojamiento);
            Alojamiento alojamiento = this.ConsultarAlojamiento(idAlojamiento);

            if (alojamiento!=null)
            {
                var arrendador = this.ConsultarInformacionArrendadorHabitacion(alojamiento.IdAlojamiento);
                return ArmarJSONInformacion(promedio, alojamiento, arrendador);
            }
            else
            {
                return BuscarAlojamientoException.ArmarJSONInformacionException("El alojamiento consultado no se encuentra registrado en la base de datos");
            }
            
        }


        /// <summary>
        /// Construye un objeto JSON con la información proporcionada y lo retorna, la información recibida es null retorna un JSON informando
        /// la excepción ocurrida.
        /// </summary>
        /// <param name="promedioCalificacion"></param>
        /// <param name="alojamiento"></param>
        /// <param name="arrendador"></param>
        /// <returns></returns>
        public JObject ArmarJSONInformacion(double promedioCalificacion, Alojamiento alojamiento,Arrendador arrendador)
        {       
                return JObject.FromObject(new
                {
                    estatus = 200,
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

        }

    }
}