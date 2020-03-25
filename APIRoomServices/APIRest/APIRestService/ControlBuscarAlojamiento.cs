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
    public class ControlBuscarAlojamiento : IControlBuscarAlojamiento
    {
        readonly Negocio.ILogicaNegocio.IControlBuscarAlojamiento control;

        public ControlBuscarAlojamiento()
        {
            control = new Negocio.ControlRepository.ControlBuscarAlojamiento();

        }

        public Alojamiento ConsultarAlojamiento(int idAlojamiento)
        {
            return control.ConsultarAlojamiento(idAlojamiento);
        }

        public Arrendador ConsultarInformacionArrendador(string cedulaArrendador)
        {
            return control.ConsultarInformacionArrendador(cedulaArrendador);
        }

        public double ConsultarPromedioCalificaciones(int idHabitacion)
        {
            return control.PromedioCalificaciones(idHabitacion);
        }

        public IList<JObject> ListarAlojamientos(string filtro)
        {
            IList<JObject> alojamientosJSON = new List<JObject>();
            var alojamientos = control.ListarAlojamientos(filtro);

            foreach (var item in alojamientos)
            {
                alojamientosJSON.Add(JObject.FromObject(new
                {
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

        public Arrendador ConsultarInformacionArrendadorHabitacion(int IdAlojamiento)
        {
            return control.ConsultarInformacionArrendadorHabitacion(IdAlojamiento);
        }

        

        public JObject RetornarInformacionAlojamiento(int idAlojamiento)
        {
            double promedio = this.ConsultarPromedioCalificaciones(idAlojamiento);
            Alojamiento alojamiento = this.ConsultarAlojamiento(idAlojamiento);
            var arrendador = this.ConsultarInformacionArrendadorHabitacion(alojamiento.IdAlojamiento);

            return ArmarJSONInformacion(promedio, alojamiento, arrendador);
        }


        /// <summary>
        /// Arma un objeto JSON con la información proporcionada y lo retorna, la información recibida es null retorna un JSON informando
        /// la excepción ocurrida.
        /// </summary>
        /// <param name="promedioCalificacion"></param>
        /// <param name="alojamiento"></param>
        /// <param name="arrendador"></param>
        /// <returns></returns>
        public JObject ArmarJSONInformacion(double promedioCalificacion, Alojamiento alojamiento,Arrendador arrendador)
        {
            
            if (alojamiento != null)
            {
                
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
            }
            else
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