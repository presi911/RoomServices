using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaDatos.IGestionInformacion
{
    public interface IBuscarAlojamiento
    {
        List<Alojamientos> ListarAlojamientos(string filtro);

        Alojamientos ConsultarAlojamiento(int idAlojamiento);

        Arrendadores ConsultarInformacionArrendador(string cedulaArrendador);

        Usuarios ConsultarUsuario(string cedulaUsuario);

        double PromedioCalificaciones(int idHabitacion);

        Arrendadores ConsultarArrendadorHabitacion(int idAlojamiento);
    }
}
