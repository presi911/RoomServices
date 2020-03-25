using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ControlExcepciones
{
    class ControlTomarAlquilerAlojamientoException : Exception
    {
       public ControlTomarAlquilerAlojamientoException(string message): base(message)
        {

        }

        public static Boolean DatosFaltantes(string mensaje)
        {
            mensaje = "";
            Boolean a = Boolean.Parse(mensaje);
            return a;
        }
    }
}
