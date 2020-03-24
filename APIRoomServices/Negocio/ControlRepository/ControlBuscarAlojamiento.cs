using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ILogicaNegocio;

using Negocio.ControlExcepciones;

namespace Negocio.ControlRepository
{
    public class ControlBuscarAlojamiento : IControlBuscarAlojamiento
    {
        /// <summary>
        /// Consulta y obtiene un objeto tipo Alojamientos con todos sus atributos, a partir de su id
        /// </summary>
        /// <param name="idAlojamiento">Parámetro númerico con el id de la habitación a consultar en la base de datos</param>
        /// <returns>Objeto tipo Alojamientos que corresponde al id</returns>
        public Alojamiento ConsultarAlojamiento(int idAlojamiento)
        {
            //Mediante una consulta de Linq obtengo el alojamiento que corresponde con su id
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var consulta = (from item in entidades.Alojamientos
                                where (item.idAlojamiento == idAlojamiento)
                                select new Alojamiento()
                                {
                                    IdAlojamiento = item.idAlojamiento,
                                    Titulo = item.titulo,
                                    DescripcionAlojamiento = item.descripcionAlojamiento,
                                    Precio = (double)item.precio,
                                    TipoAlojamiento = item.tipoAlojamiento,
                                    CedulaArrendador= item.cedulaArrendador,

                                });

                if (consulta.Count() > 0)
                {
                    var alojamiento = consulta.First();
                    alojamiento.CalificacionesAlojamiento = this.RetornarCalificacionesAlojamiento(idAlojamiento);


                    //Retorno el alojamiento
                    return alojamiento;
                }
                else
                {
                    return null;
                }

            }
        }


        /// <summary>
        /// Realiza una consulta en la base de datos y retorna una coleccion de calificaciones que se ha realizado al alojamiento
        /// </summary>
        /// <param name="idHabitacion">dato númerico que corresponde al id de la habitación consultada</param>
        /// <returns>Colección de objetos tipo calificación que pertenecen a la habitación consultada</returns>
        public List<Calificacion> RetornarCalificacionesAlojamiento(int idAlojamiento)
        {
            List<Calificacion> lista = new List<Calificacion>();
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                
                var query = (from item in entidades.Alojamientos
                                    where (item.idAlojamiento == idAlojamiento)
                                    select item.CalificacionesAlojamiento);

                if (query.Count() > 0) {     
                        var calificaiones  = query.First();
                        foreach (var item in calificaiones)
                        {
                            var calificacion = this.RetornarCalificacion(item.idCalificacion);
                            lista.Add(new Calificacion()
                            {
                                IdCalificacion = item.idCalificacion,
                                CalificacionHabitacion = (byte)calificacion.calificacionAlojamiento,
                                ComentarioCalificacion = calificacion.comentarioAlojamiento

                            });

                        }
                        return lista;
                }
                else
                {
                    return null;
                }
                
                

            }
        }

        /// <summary>
        /// Permite realizar una consulta a una Calificación específica proporcionando como criterio el id de calificacíón
        /// </summary>
        /// <param name="idCalificacion">identificador de calificación</param>
        /// <returns>Objeto tipo Calificaciones con su información, id,comentario,calificación</returns>
        public Calificaciones RetornarCalificacion(int idCalificacion)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var consulta = (from item in entidades.Calificaciones
                                where (item.idCalificacion == idCalificacion)
                                select item).First();
                return consulta;
            }

        }

        /// <summary>
        /// Permite retornar la información de un Arrendador propocionando como parametro el su cédula
        /// </summary>
        /// <param name="cedulaArrendador">cadena, cédula del usuario arrendador</param>
        /// <returns>objeto tipo Arrendador con la persona que ha publicado el anuncio</returns>
        /// 
        public Arrendador ConsultarInformacionArrendador(string cedulaArrendador)
        {

            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var consulta = (from arrend in entidades.Arrendadores join usu in entidades.Usuarios
                                on arrend.cedula equals usu.cedula
                                where (arrend.cedula == cedulaArrendador)

                                select new Arrendador()
                                {
                                    Cedula= usu.cedula,
                                    Nombre= usu.nombre,
                                    Apellido= usu.apellido,
                                    Fecha = usu.fechaNacimiento,
                                    Nacionalidad= usu.nacionalidad,
                                    Genero= usu.genero,
                                    IdArrendador = arrend.idArrendador

                                }).First();

                return consulta;
            }

        }


        /// <summary>
        /// Permite retornar la información de un Arrendador de una habitación proporcionando como parámetro el id de habitación
        /// </summary>
        /// <param name="cedulaArrendador">entero, identificador de habitación</param>
        /// <returns>objeto tipo Arrendador con la persona que ha publicado el anuncio</returns>
        /// 
        public Arrendador ConsultarInformacionArrendadorHabitacion(int idAlojamiento)
        {

            var alojamiento = this.ConsultarAlojamiento(idAlojamiento);

            return this.ConsultarInformacionArrendador(alojamiento.CedulaArrendador);


        }



        /// <summary>
        /// Permite obtener un usuario de la base de datos, esto es debido a que arrendatario tiene una relación directa con
        /// Usuario con llave foránea en cédula, y por tanto si quiero consultar todos los datos del arrendatario, necesito por 
        /// ende también consultar el usuario que es la clase padre.
        /// </summary>
        /// <param name="cedulaUsuario">cédula del usuario a consultar</param>
        /// <returns>objeto tipo Usuarios</returns>
        public Usuarios ConsultarUsuario(string cedulaUsuario)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var consulta = (from item in entidades.Usuarios
                                where (item.cedula == cedulaUsuario)
                                select item).First();
                return consulta;
            }
        }

        /// <summary>
        /// Consulta y retorna la información de un alojamiento proporcionando un fitro compuesto de palabras clave
        /// </summary>
        /// <param name="filtro">cadena, palabras clave o criterio ingresado por el usuario</param>
        /// <returns>Lista con los alojamientos que cumplen el criterio de búsqueda especificado por el usuario</returns>
        public IList<Alojamiento> ListarAlojamientos(string filtro)
        {

            List<string> objetos = new List<string>();


            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var consulta = (from item in entidades.Alojamientos
                                where ((item.titulo.Contains(filtro)) || item.descripcionAlojamiento.Contains(filtro))
                                select new Alojamiento()
                                {
                                    Titulo = item.titulo,
                                    TipoAlojamiento = item.tipoAlojamiento,

                                    Estado = (int)item.estado,

                                    IdAlojamiento = item.idAlojamiento,
                                    Precio = (double)item.precio
                                }).ToList();

                return consulta;

            }

        }


        /// <summary>
        /// Permite retornar el promedio de todas las calificaciones realizadas a al alojamiento
        /// </summary>
        /// <param name="idHabitacion">identificador de habitación</param>
        /// <returns>dato númerico con el cálculo del promedio de la calificaciones realizadas</returns>
        public double PromedioCalificaciones(int idHabitacion)
        {
            var calificaciones = this.RetornarCalificacionesAlojamiento(idHabitacion);

            if (calificaciones != null)
            {
                double suma = 0;

                foreach (var item in calificaciones)
                {
                    suma += item.CalificacionHabitacion;
                }

                return suma / calificaciones.Count();
            }
            else {

                return 0;
            }

        }
    }
}
