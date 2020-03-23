using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace LogicaNegocio.ControlRepository
{
    class ControlBuscarAlojamiento
    {

        public void ListarAlojamientos()
        {
            try
            {
                using (RoomServicesEntities entidades = new RoomServicesEntities())
                {
                    var consulta = (from item in entidades.Alojamientos select item).ToList();
                    Console.WriteLine(consulta);
                }

                
            }catch (Exception)
            {

            }
        }
    }
}
