
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Servicios.EntidadesDelDominio.Entidades;
using CapaDatos.IGestionInformacion;
using CapaDatos.ControlRepository;

namespace Servicios.ILogicaNegocio
{
    public interface IAlquilarAlojamiento
    {
        List<Alojamiento> listarAlojamiento(int idAlojamiento);

        Alojamiento verificarDisponiblidad(int idAlojamiento);

        Alojamiento mostrarInformacionAlojamiento(String cedulaArrendador, String cedulaArrendatario, int idAlojamiento);

        Arrendatario ingresarDatosArredatario(String cedulaArrendatario);
    }
}