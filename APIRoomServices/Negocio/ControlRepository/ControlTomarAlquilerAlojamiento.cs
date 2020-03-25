using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ILogicaNegocio;
using Negocio.ControlExcepciones;
using Negocio;
using Datos;


namespace Negocio.ControlRepository
{
   public class ControlTomarAlquilerAlojamiento : IControlAlquilerAlojamiento
   {
        /// <summary>
        /// Consulta y obtiene un obtiene  el estado del alojamiento
        /// </summary>
        /// <param name="idAlojamiento">Parámetro númerico con el id de la habitación a consultar en la base de datos</param>
        /// <param name="estado">Parámetro númerico del estado del alojamiento a consultar en la base de datos</param>
        /// <returns>Un valor numerico si 1 esta Disponible y 0 Ocupada</returns>

        public int estadoAlojamiento(int idAlojamiento, int estado)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var disponible = (from item in entidades.Alojamientos
                                  where ((item.idAlojamiento == idAlojamiento))
                                  select item.estado).First();

                return verAlojamiento(disponible.Value);
            }
        }

        /// <summary>
        /// Consulta y obtiene un objeto tipo Alojamientos con todos sus atributos, a partir de su id
        /// </summary>
        /// <param name="idAlojamiento">Parámetro númerico con el id de la habitación a consultar en la base de datos</param>
        /// <returns>Objeto tipo Alojamientos que corresponde al id</returns>
        public Alojamiento listaAlojamiento(int idAlojamiento)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaAlojamiento = (from alojamiento in entidades.Alojamientos
                                        where ((alojamiento.idAlojamiento == idAlojamiento))
                                        select new Alojamiento()
                                        {
                                            IdAlojamiento = alojamiento.idAlojamiento,
                                            Titulo = alojamiento.titulo,
                                            Precio = (double)alojamiento.precio,
                                            TipoAlojamiento = alojamiento.tipoAlojamiento,
                                            CedulaArrendador = alojamiento.cedulaArrendador,
                                            Estado = (int)alojamiento.estado
                                        });

                return listaAlojamiento.First();
                                                                                                
            }
        }

        /// <summary>
        /// Permite retornar la información de un Arrendador propocionando como parametro el su cédula
        /// </summary>
        /// <param name="cedula">cadena, cédula del usuario arrendador</param>
        /// <returns>objeto tipo Arrendador con la persona que ha publicado el anuncio</returns>
        /// 
        public Arrendador listaArredandor(string cedula)
        {
            using(RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaArredador = (from arrendador in entidades.Arrendadores join user in entidades.Usuarios
                                      on arrendador.cedula equals user.cedula                                      
                                      where ((arrendador.cedula.Equals( cedula)))
                                      select new Arrendador()
                                      {
                                          Cedula = user.cedula,
                                          Nombre = user.nombre,
                                          Apellido = user.apellido,
                                          Fecha = user.fechaNacimiento,
                                          Nacionalidad = user.nacionalidad,
                                          Genero = user.genero,
                                          IdArrendador = arrendador.idArrendador

                                      });

                return listaArredador.First();
            }
        }

        /// <summary>
        /// Permite retornar la información de un Arrendadorio propocionando como parametro el su cédula
        /// </summary>
        /// <param name="cedula">cadena, cédula del usuario arrendadorio</param>
        /// <returns>objeto tipo Arrendadorrio con la persona que va a tomar el alojamiento en el anuncio</returns>
        /// 
        public Arrendatario listaArrendatario(string cedula)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaArrendatario = (from arrendatario in entidades.Arrendatarios join user in entidades.Usuarios
                                     on arrendatario.cedulaArrendatario equals user.cedula
                                         where ((arrendatario.cedulaArrendatario.Equals( cedula)))
                                         select new Arrendatario()
                                         {
                                             Cedula=arrendatario.cedulaArrendatario,
                                             Nombre=arrendatario.Usuarios.nombre,
                                             Apellido=arrendatario.Usuarios.apellido,
                                             Fecha = arrendatario.Usuarios.fechaNacimiento,
                                             Genero =arrendatario.Usuarios.genero,
                                             Nacionalidad = arrendatario.Usuarios.nacionalidad,
                                             TipoArrendador=arrendatario.tipoArrendador,
                                             IdArrendatario = arrendatario.idArrendatario

                                         });

                return listaArrendatario.First();
            }
        }

        /// <summary>
        /// Permite ingresar información con los datos faltantes en alquileAlojamiento como requisito
        /// </summary>
        /// <param name="numeroContrato">entero, datos faltantes en alquiler</param>
        /// <param name="numeroMeses">entero, datos faltantes en alquiler</param>
        /// <param name="pagoMensual">decimal, datos faltantes en alquiler</param>
        /// <param name="fechaAlquiler">DateTime, datos faltantes en alquiler</param>
        ///<param name="idAlojamiento">entero, datos faltantes en alquiler</param>
        /// <returns>Se obtiene un TRUE diciendo que los datos se ingresaron o False que alojamiento no esta disponible</returns>
        ///
        public Boolean ingresarDatosFaltantes(int numeroContrato, int numeroMeses, Decimal pagoMensual, string fechaAlquiler, int idAlojamiento)
        {
            var alojamiento = this.listaAlojamiento(idAlojamiento);

            if (this.estadoAlojamiento(alojamiento.IdAlojamiento, alojamiento.Estado) == 1)
            {
                using (RoomServicesEntities entidades = new RoomServicesEntities())
                {
                    AlquilersAlojamientos alquila = new AlquilersAlojamientos()
                    {
                        numeroContrato = numeroContrato,
                        numeroMeses = numeroMeses,
                        pagoMensual = pagoMensual,
                        fechaAlquiler = fechaAlquiler,
                        idAlojamiento = alojamiento.IdAlojamiento

                    };
                    entidades.AlquilersAlojamientos.Add(alquila);
                    entidades.SaveChanges();

                }
                return ControlTomarAlquilerAlojamientoException.DatosFaltantes("Datos ingresados Correctamente");
            }
            else
            {
                return ControlTomarAlquilerAlojamientoException.DatosFaltantes("Alojamiento NO Disponible") ;
            }
        }


        /// <summary>
        /// Permite ver el estado de un alojamiento
        /// </summary>
        /// <param name="estado">entero, identificador de alojamiento</param>
        /// <returns>Se obtiene un 1 Disponible y 0 Ocupado el alojamiento</returns>
        /// 
        public int verAlojamiento(int estado)
        {
            if(estado==0)
            {
                return 0;
            }
           
            return 1;
            
        }

        /// <summary>
        /// Permite retornar la información del alquiler propocionando como parametro el idAlojamiento
        /// </summary>
        /// <param name="idAlojamiento">cadena, idAlojamiento del alojamiento </param>
        /// <returns>objeto tipo alquiler con sus respectivos datos mediante en idAlojamiento</returns>
        ///
        public Alquiler listaAlquiler(int idAlojamiento)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var alojamiento = this.listaAlojamiento(idAlojamiento);
                var alquiler = (from alqui in entidades.AlquilersAlojamientos
                                where ((alqui.idAlojamiento == alojamiento.IdAlojamiento))
                               select new Alquiler()
                               {
                                  NumeroContrato = alqui.numeroContrato,
                                  numeroMeses = (byte)alqui.numeroMeses,
                                  PagoMensual = (double)alqui.pagoMensual,
                               //   FechaAlquiler = Convert.ToDateTime(alqui.fechaAlquiler),

                               });
                    return alquiler.First();
                               
            }
        }
        public CalificacionesAlojamiento calificacionAlojamiento(int idAlojamiento)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var alojamiento = this.listaAlojamiento(idAlojamiento);
                var calificacion= (from cali in entidades.CalificacionesAlojamiento
                                where ((cali.idAlojamiento == alojamiento.IdAlojamiento))
                                select new CalificacionesAlojamiento()
                                {
                                     idCalificacion= cali.idCalificacion,
                                    cedulaArrendatario = cali.cedulaArrendatario,
                                    idAlojamiento= cali.idAlojamiento,
                                    fechaCalificacion = cali.fechaCalificacion

                                });
                return calificacion.First();

            }
        }
    }
}
