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

        public Alojamiento ConsultarAlojamiento(int idAlojamiento)
        {
            return control.ConsultarAlojamiento(idAlojamiento);
        }

        public Arrendador ConsultarInformacionArrendador(string cedulaArrendador)
        {

            string cedula = cedulaArrendador.Trim();
            return control.ConsultarInformacionArrendador(cedula);

        }

        public double ConsultarPromedioCalificaciones(int idHabitacion)
        {
            return control.PromedioCalificaciones(idHabitacion);
        }

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

        public Arrendador ConsultarInformacionArrendadorHabitacion(int IdAlojamiento)
        {
            return control.ConsultarInformacionArrendadorHabitacion(IdAlojamiento);
        }

        

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
        /// Arma un objeto JSON con la información proporcionada y lo retorna, la información recibida es null retorna un JSON informando
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