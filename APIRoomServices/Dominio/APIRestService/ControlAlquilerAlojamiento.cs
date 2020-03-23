using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;
using Servicios.ILogicaNegocio;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;



namespace Servicios.APIRestService
{
    public class ControlAlquilarAlojamiento : Servicios.ILogicaNegocio.IAlquilarAlojamiento
    {
        CapaDatos.IGestionInformacion.IAlquilarAlojamiento lista;

        public ControlAlquilarAlojamiento()
        {
            lista = new CapaDatos.ControlRepository.ControlAlqulilarAlojamiento();
        }

        public Arrendatario ingresarDatosArredatario(string cedulaArrendatario)
        {
            throw new NotImplementedException();
        }

        public List<Alojamiento> listarAlojamiento(int idAlojamiento)
        {
            var listaAlojamiento = lista.listarAlojamiento(idAlojamiento);
            List<Alojamiento> alojamientos = new List<Alojamiento>();
            foreach (var alojamiento in listaAlojamiento)
            {
                alojamientos.Add(new Alojamiento()
                {
                    IdAlojamiento = (int)alojamiento.idAlojamiento,
                    Titulo = alojamiento.titulo,
                    Precio = (double)alojamiento.precio,
                    //Se debe organizar
                    UbicacionAlojamiento = new Ubicacion()
                });
            }
            return alojamientos;
        }

        public Alojamiento mostrarInformacionAlojamiento(string cedulaArrendador, string cedulaArrendatario, int idAlojamiento)
        {
            throw new NotImplementedException();
        }

        public Alojamiento verificarDisponiblidad(int idAlojamiento)
        {
            throw new NotImplementedException();
        }
    }
}