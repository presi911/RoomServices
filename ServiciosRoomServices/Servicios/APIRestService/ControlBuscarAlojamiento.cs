using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;

using Servicios.ILogicaNegocio;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;
using Servicios.EntidadesDelDominio.Entidades;

namespace Servicios.APIRestService

{
    public class ControlBuscarAlojamiento : Servicios.ILogicaNegocio.IBuscarAlojamiento
    {

        CapaDatos.IGestionInformacion.IBuscarAlojamiento acciones;

        public ControlBuscarAlojamiento()
        {
            acciones = new CapaDatos.ControlRepository.ControlBuscarAlojamiento();
        }

        public Alojamiento ConsultarDescripcionAlojamiento()
        {
            throw new NotImplementedException();
        }

        public Arrendador ConsultarInformacionArrendador()
        {
            throw new NotImplementedException();
        }

        public List<Alojamiento> ListarAlojamientos(string filtro)
        {

            var alojamientosList= acciones.ListarAlojamientos(filtro);

            List<Alojamiento> alojamientos= new List<Alojamiento>();
            foreach (var alojamiento in alojamientosList)
            {
                alojamientos.Add(new Alojamiento()
                {
                    IdAlojamiento = (int)alojamiento.idAlojamiento,
                    Titulo = alojamiento.titulo,
                    Precio = (double)alojamiento.precio,
                    //Se debe organizar
                    UbicacionAlojamiento = new Ubicacion()
                }) ;
            }

            return alojamientos;

        }

        public Calificacion MostrarInfoCalificacion()
        {
            throw new NotImplementedException();
        }
    }
}
