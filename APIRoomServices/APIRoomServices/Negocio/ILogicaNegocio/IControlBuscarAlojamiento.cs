using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.EntidadesDelDominio.Entidades;

namespace Negocio.ILogicaNegocio
{
    public interface IControlBuscarAlojamiento
    {

        IList<Alojamiento> ListarAlojamientos(string filtro);

        Alojamiento ConsultarAlojamiento(int idAlojamiento);

        Arrendador ConsultarInformacionArrendador(string cedulaArrendador);

        double PromedioCalificaciones(int idHabitacion);

        List<Calificacion> RetornarCalificacionesAlojamiento(int idAlojamiento);

        Arrendador ConsultarInformacionArrendadorHabitacion(int idAlojamiento);

    }
}
