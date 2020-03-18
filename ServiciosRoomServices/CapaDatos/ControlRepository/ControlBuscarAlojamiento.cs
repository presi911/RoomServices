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

    public Alojamientos ConsultarDescripcionAlojamiento()
    {
        throw new NotImplementedException();
    }

    public Arrendadores ConsultarInformacionArrendador()
    {
        throw new NotImplementedException();
    }

    public List<Alojamientos> ListarAlojamientos(string info)
    {

        var consulta = from item in modeloBD.Alojamientos
                        where ((item.titulo.Contains(info)) || item.descripcionAlojamiento.Contains(info))
                        select item;

        return consulta.ToList();
    }

    public Calificaciones MostrarInfoCalificacion()
    {
        throw new NotImplementedException();
    }
}
}
