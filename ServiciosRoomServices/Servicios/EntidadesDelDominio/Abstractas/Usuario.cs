using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.EntidadesDelDominio.Entidades;

namespace Servicios.EntidadesDelDominio.Abstractas
{
    public abstract class Usuario
    {

        string Cedula { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime Fecha { get; set; }
        string Nacionalidad { get; set; }
        char Genero { get; set; }

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

