using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.IGestionInformacion
{
    public interface IAlquilarAlojamiento
    {
        List<Alojamientos> listarAlojamiento(int idAlojamiento);

        Alojamientos verificarDisponiblidad(int idAlojamiento);

        Alojamientos mostrarInformacionAlojamiento(String cedulaArrendador, String cedulaArrendatario, int idAlojamiento);

        Arrendatarios ingresarDatosArrendatarios(String cedulaArrendatario);



    }
}