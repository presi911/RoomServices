using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ControlExcepciones
{
    class ControlBuscarAlojamientoException : Exception
    {

        public ControlBuscarAlojamientoException(string message): base(message)
        {

        }
    }
}
