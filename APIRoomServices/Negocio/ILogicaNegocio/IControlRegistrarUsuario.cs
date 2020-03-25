using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ILogicaNegocio
{
    public interface IControlRegistrarUsuario
    {

        Boolean RegistrarUsuario(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero);
        Boolean ConsultarUsuario(string cedulaUsuario);

    }



}
