﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Servicios.EntidadesDelDominio.Entidades;
using CapaDatos.ControlRepository;
using CapaDatos.IGestionInformacion;
namespace Servicios.ILogicaNegocio
{
    interface IBuscarAlojamiento
    {

        List<Alojamiento> ListarAlojamientos(string filtro);

        Alojamiento ConsultarDescripcionAlojamiento();

        Alojamiento ConsultarAlojamiento(int idAlojamiento);
        Arrendador ConsultarInformacionArrendador(string cedulaArrendador);

        double PromedioCalificaciones(int idHabitacion);

        Newtonsoft.Json.Linq.JObject RetornarInformacionAlojamiento(int idHabitacion);

    }
}
