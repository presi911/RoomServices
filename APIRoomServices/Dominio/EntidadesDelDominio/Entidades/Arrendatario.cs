using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDelDominio.Abstractas;

namespace Dominio.EntidadesDelDominio.Entidades
{
    public class Arrendatario : Usuario
    {
        public int IdArrendatario { get; }
        public  string TipoArrendador { get; set; }
        List<Calificacion> listCalificacion;

        /// <summary>
        /// Permite generar una nueva instancia de tipo Arrendatario 
        /// </summary>
        /// <param name="cedula">string con la cédula del usuario arrendatario</param>
        /// <param name="nombre">string con el nombre del arrendatario</param>
        /// <param name="apellido">string con el apellido a establecer del arrendatario</param>
        /// <param name="fecha"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="genero"></param>
        /// <param name="tipoArrendador"><a</param>
        public Arrendatario(string cedula, string nombre, string apellido, DateTime ?fecha, string nacionalidad, char genero, string tipoArrendador) : base(cedula, nombre, apellido, fecha, nacionalidad, genero)
        {
            TipoArrendador = tipoArrendador;
        }
    }
}
