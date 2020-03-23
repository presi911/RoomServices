using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDelDominio.Entidades;

namespace Dominio.EntidadesDelDominio.Abstractas
{
    public abstract class Usuario
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? Fecha { get; set; }
        public string Nacionalidad { get; set; }
        public string Genero { get; set; }

        CuentaBancaria cuentaBancaria;
        CuentaUsuario cuentaUsuario;

        protected Usuario(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, string genero)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Fecha = fecha;
            Nacionalidad = nacionalidad;
            Genero = genero;
        }

        public Usuario()
        {

        }
    }
}
