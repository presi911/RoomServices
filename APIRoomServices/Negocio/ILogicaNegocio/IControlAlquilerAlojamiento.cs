using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Dominio.EntidadesDelDominio.Entidades;
namespace Negocio.ILogicaNegocio
{
    public interface IControlAlquilerAlojamiento
    {
        int estadoAlojamiento(int idAlojamiento, int estado);
        Alojamiento listaAlojamiento(int idAlojamoiento);
        Arrendador listaArredandor(string cedula);
        Arrendatario listaArrendatario(string cedula);
        Boolean ingresarDatosFaltantes(int numeroContrato, int numeroMeses, Decimal pagoMensual, string fechaAlquiler, int idAlojamiento);

    }
}
