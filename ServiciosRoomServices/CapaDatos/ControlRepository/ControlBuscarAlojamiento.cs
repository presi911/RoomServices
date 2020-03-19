using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.IGestionInformacion;

namespace CapaDatos.ControlRepository
{
    public class ControlBuscarAlojamiento : IBuscarAlojamiento
    {
         RoomServicesEntities modeloBD;

        public ControlBuscarAlojamiento()
        {
            modeloBD = new RoomServicesEntities();
        }


    /// <summary>
    /// Permite consultar la información de un arrendador a partir de su cédula.
    /// </summary>
    /// <param name="cedulaArrendador">cadena con la cédula del arrendador a consultar</param>
    /// <returns>Objeto tipo Arrendadores con la información del arrendador</returns>
    public Arrendadores ConsultarInformacionArrendador(string cedulaArrendador)
        {
            var consulta = (from item in modeloBD.Arrendadores
                            where (item.cedula == cedulaArrendador)
                            select item).ToList();

            return consulta.Count() != 0 ? consulta.First() : null;


        }
 
    

    /// <summary>
    /// Realiza una consulta en la base de datos y retorna una lista con los alojamientos que cumplen con el criterio
    /// ingresado en el filtro.
    /// </summary>
    /// <param name="info">cadena 'filtro' con la consulta ingresada por el usuario</param>
    /// <returns>Lista de alojamientos que cumplen con el criterio ingresado por el usuario</returns>
    public List<Alojamientos> ListarAlojamientos(string info)
    {
        //Consultando 
        var consulta = (from item in modeloBD.Alojamientos
                       where ((item.titulo.Contains(info)) || item.descripcionAlojamiento.Contains(info))
                       select item).ToList();

         //var m = ConsultarAlojamiento(2);


        return consulta;


        /*return (from p in modeloBD.Set<Alojamientos>()
            select new { titulo = p.titulo }).ToList()
           .Select(x => new Alojamientos { titulo = x.titulo }).ToList();*/
    }

    /// <summary>
    /// Consulta y obtiene un objeto tipo Alojamientos con todos sus atributos, a partir de su id
    /// </summary>
    /// <param name="idAlojamiento">Parámetro númerico con el id de la habitación a consultar en la base de datos</param>
    /// <returns>Objeto tipo Alojamientos que corresponde al id</returns>
    public Alojamientos ConsultarAlojamiento(int idAlojamiento)
        {
            //Mediante una consulta de Linq obtengo el alojamiento que corresponde con su id
            var consulta = (from item in modeloBD.Alojamientos
                            where (item.idAlojamiento==idAlojamiento)
                            select item).ToList();

            //Retorno el alojamiento
            return consulta.Count() != 0 ? consulta.First() : null;
        }

    /// <summary>
    /// Realiza una consulta en la base de datos y retorna una coleccion de calificaciones que se ha realizado al alojamiento
    /// </summary>
    /// <param name="idHabitacion">dato númerico que corresponde al id de la habitación consultada</param>
    /// <returns>Colección de objetos tipo calificación que pertenecen a la habitación consultada</returns>
    public List<CalificacionesAlojamiento> RetornarCalificaciones(int idHabitacion)
    {
            var alojamiento = this.ConsultarAlojamiento(idHabitacion);

            return alojamiento.CalificacionesAlojamiento.ToList();
    }

        /// <summary>
        /// Permite retornar el promedio de todas las calificacioes realizadas a al alojamiento
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns></returns>
        public double PromedioCalificaciones(int idHabitacion)
        {
            //Donde voy almacenando la suma de todas la calificaciones realizadas a la habitación:
            int suma = 0;
            //Obtengo la coleccion con todas las calificaciones realizadas a la habitación con su id
            var calificaciones = this.RetornarCalificaciones(idHabitacion);
            
            //Recorro la lista de calificaciones, consultando el valor asignado a esa calificación mediante una consulta linq
            //voy acumulando en una variable llamada suma:
            foreach (var calificacion in calificaciones)
            {
                var consulta = (from item in modeloBD.Calificaciones
                                where (item.idCalificacion==calificacion.idCalificacion)
                                select item.calificacionAlojamiento).ToList();

                if (consulta.Count() > 0 || consulta.First()!=null)
                {
                    suma += (int)consulta.First();
                }
            }
            //retorno el promedio de las calificaciones
            return suma / calificaciones.Count();
            
            
        }
    }
}
