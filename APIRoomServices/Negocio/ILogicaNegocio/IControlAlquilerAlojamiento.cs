using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ILogicaNegocio
{
<<<<<<< HEAD:ServiciosRoomServices/CapaDatos/IGestionInformacion/IAlquilarAlojamiento.cs
    public interface IAlquilarAlojamiento
=======
    interface IControlAlquilerAlojamiento
>>>>>>> aeae7213c1db04e69c003ee40a392639831bc9ba:APIRoomServices/Negocio/ILogicaNegocio/IControlAlquilerAlojamiento.cs
    {
        List<Alojamientos> listarAlojamiento(int idAlojamiento);

        Alojamientos verificarDisponiblidad(int idAlojamiento);

        Alojamientos mostrarInformacionAlojamiento(String cedulaArrendador, String cedulaArrendatario, int idAlojamiento);

        Arrendatarios ingresarDatosArrendatarios(String cedulaArrendatario);



    }
}