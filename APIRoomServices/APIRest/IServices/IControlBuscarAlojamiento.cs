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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        IList<JObject> ListarAlojamientos(string filtro);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cedulaArrendador"></param>
        /// <returns></returns>
        Arrendador ConsultarInformacionArrendador(string cedulaArrendador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlojamiento"></param>
        /// <returns></returns>
        Alojamiento ConsultarAlojamiento(int idAlojamiento);

        double ConsultarPromedioCalificaciones(int idHabitacion);

        JObject RetornarInformacionAlojamiento(int idHabitacion);

        JObject RetornarFotografiasAlojamiento(int idAlojamiento);

    }
}