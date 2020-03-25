using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ILogicaNegocio;
using Negocio;
using Datos;


namespace Negocio.ControlRepository
{
   public class ControlTomarAlquilerAlojamiento : IControlAlquilerAlojamiento
   {

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

        public Alojamiento listaAlojamiento(int idAlojamoiento)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaAlojamiento = (from alojamiento in entidades.Alojamientos
                                        where ((alojamiento.idAlojamiento == idAlojamoiento))
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public int verAlojamiento(int estado)
        {
            if(estado==0)
            {
                return 0;
            }
           
            return 1;
            
        }

    }
}
