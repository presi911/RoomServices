using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Abstractas;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class Arrendador : Usuario
    {
        int IdArrendador { get;}
        List<Alojamiento> listAlojamiento;
        /// <summary>
        /// Permite realizar la instanciación de un Arrendador en la plataforma
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fecha"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="genero"></param>
        public Arrendador(string cedula, string nombre, string apellido, DateTime fecha, string nacionalidad, char genero) : 
            base(cedula, nombre, apellido, fecha, nacionalidad, genero)
        {

        }

    }
}
