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
                                            Precio = (double)alojamiento.precio
                                        }).First();

                return listaAlojamiento;
                                                                                                
            }
        }

        public Arrendador listaArredandor(string cedula)
        {
            using(RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaArredador = (from arrendador in entidades.Arrendadores join user in entidades.Usuarios
                                      on arrendador.cedula equals user.cedula                                      
                                      where ((arrendador.cedula == cedula))
                                      select new Arrendador(user.cedula,user.nombre,user.apellido,user.fechaNacimiento,user.nacionalidad,user.genero)
                                      {
                                         IdArrendador=arrendador.idArrendador                       

                                      }).First();

                return listaArredador;
            }
        }

        public Arrendatario listaArrendatario(string cedula)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {
                var listaArrendatario = (from arrendatario in entidades.Arrendatarios join user in entidades.Usuarios
                                     on arrendatario.cedulaArrendatario equals user.cedula
                                         where ((arrendatario.cedulaArrendatario == cedula))
                                         select new Arrendatario(user.cedula, user.nombre, user.apellido, user.fechaNacimiento, user.nacionalidad, user.genero, arrendatario.tipoArrendador)
                                         {
                                             IdArrendatario = arrendatario.idArrendatario

                                         }).First();

                return listaArrendatario;
            }
        }

        public IList<Alojamiento> mostrarInformacionAlojamiento(int idAlojamiento, string cedulaArrendatario, string cedulaArrendador)
        {
            throw new NotImplementedException();
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
