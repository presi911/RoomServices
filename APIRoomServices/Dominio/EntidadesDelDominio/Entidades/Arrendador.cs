using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDelDominio.Abstractas;

namespace Dominio.EntidadesDelDominio.Entidades
{
    public class Arrendador : Usuario
    {
        public int IdArrendador { get; set; }

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
        public Arrendador(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, string genero) :
            base(cedula, nombre, apellido, fecha, nacionalidad, genero)
        {

        }

        public Arrendador()
        {

        }
    }
}
