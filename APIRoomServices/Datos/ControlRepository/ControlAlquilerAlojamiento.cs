using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.IGestionInformacion;


namespace CapaDatos.ControlRepository
{
    public class ControlAlqulilarAlojamiento : IAlquilarAlojamiento
    {
        RoomServicesEntities modeloBD;

        public ControlAlqulilarAlojamiento()
        {
            modeloBD = new RoomServicesEntities();
        }

        public Arrendatarios ingresarDatosArrendatarios(string cedulaArrendatario)
        {
            throw new NotImplementedException();
        }

        public List<Alojamientos> listarAlojamiento(int idAlojamiento)
        {

            var listarAlojamiento = (from item in modeloBD.Alojamientos
                                     where (item.idAlojamiento.Equals(idAlojamiento))
                                     select item);
            return listarAlojamiento.ToList();


        }


        public Alojamientos mostrarInformacionAlojamiento(string cedulaArrendador, string cedulaArrendatario, int idAlojamiento)
        {
            throw new NotImplementedException();
        }

        public Alojamientos verificarDisponiblidad(int idAlojamiento)
        {
            throw new NotImplementedException();
        }
    }
}