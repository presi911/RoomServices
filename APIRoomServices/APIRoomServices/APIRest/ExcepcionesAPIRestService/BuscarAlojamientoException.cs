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