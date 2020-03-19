using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;

namespace Servicios.EntidadesDelDominio.Abstractas
{
    public abstract class Usuario
    {

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public string Nacionalidad { get; set; }
        public char Genero { get; set; }

        CuentaBancaria cuentaBancaria;
        CuentaUsuario cuentaUsuario;

        protected Usuario(string cedula, string nombre, string apellido, DateTime fecha, string nacionalidad, char genero)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Fecha = fecha;
            Nacionalidad = nacionalidad;
            Genero = genero;
        }


    }
}

