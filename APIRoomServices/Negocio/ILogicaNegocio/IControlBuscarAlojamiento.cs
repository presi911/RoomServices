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
        /// <summary>
        /// Obtiene una colección de alojamientos a partir de un criterio de búsqueda
        /// </summary>
        /// <param name="filtro">Cadena: criterio de búsqueda proporcionado por el usuario</param>
        /// <returns>Colección IList de alojamientos que cumplen los criterios de la búsqueda</returns>
        IList<Alojamiento> ListarAlojamientos(string filtro);


        /// <summary>
        /// Obtiene un objeto tipo Alojamiento a partir de su identificador
        /// </summary>
        /// <param name="idAlojamiento">Entero id de alojamiento a consultar</param>
        /// <returns>Alojamiento, objeto tipo alojamiento con todos sus atributos</returns>
        Alojamiento ConsultarAlojamiento(int idAlojamiento);


        /// <summary>
        /// Obtiene un objeto tipo Arrendador, a partir de su documento (cédula)
        /// </summary>
        /// <param name="cedulaArrendador">Cadena, documento de identificación del usuario arrendador</param>
        /// <returns>Objeto tipo arredador con todos sus atributos</returns>
        Arrendador ConsultarInformacionArrendador(string cedulaArrendador);

        /// <summary>
        /// Obtiene el promedio de calificaciones de un alojamiento
        /// </summary>
        /// <param name="idHabitacion">entero, identificador de alojamiento</param>
        /// <returns>Dato númerico, promedio de calificaciones realizadas a el alojamiento</returns>
        double PromedioCalificaciones(int idHabitacion);


        /// <summary>
        /// Obtiene una colección de Calificaciones realizadas a un alojamiento, especificando como filtro el id de alojamiento
        /// </summary>
        /// <param name="idAlojamiento">Entero, identificador de alojamiento</param>
        /// <returns>Colección de Calificaciones realizadas a un alojamiento</returns>
        List<Calificacion> RetornarCalificacionesAlojamiento(int idAlojamiento);


        /// <summary>
        /// Obtiene la información de un Arrendador, proporcionando como parámetro la habitación que ha puesto en arriendo
        /// </summary>
        /// <param name="idAlojamiento">entero, identificador de alojamiento</param>
        /// <returns>Objeto tipo arredador con todos sus atributos</returns>
        Arrendador ConsultarInformacionArrendadorHabitacion(int idAlojamiento);

    }
}
