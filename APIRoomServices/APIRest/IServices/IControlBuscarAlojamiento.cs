using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dominio.EntidadesDelDominio.Entidades;
using Newtonsoft.Json.Linq;

namespace APIRest.IServices
{
    public interface IControlBuscarAlojamiento
    {
        IList<JObject> ListarAlojamientos(string filtro);

        Arrendador ConsultarInformacionArrendador(string cedulaArrendador);

        Alojamiento ConsultarAlojamiento(int idAlojamiento);

        double ConsultarPromedioCalificaciones(int idHabitacion);

        JObject RetornarInformacionAlojamiento(int idHabitacion);

    }
}