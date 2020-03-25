using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace APIRest.ExcepcionesAPIRestService
{
    public static class BuscarAlojamientoException
    {
        public static readonly int codigoError=404;


        /// <summary>
        /// Crea y retorna una Excepción en formato JSON indicando el error que ha ocurrido
        /// </summary>
        /// <param name="mensaje">Cadena, proporciona información del error que se ha generado</param>
        /// <returns>Elemento JObject (JSON) con la informción de la excepción</returns>
        public static JObject ArmarJSONInformacionException(string mensaje)
        {
            return JObject.FromObject(new
            {
                error = new
                {
                    codigoError = "404",
                    tipoExcepcion = mensaje
                }
            });

        }

    }
}