using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Servicios.EntidadesDelDominio.Entidades

{
    public class Ubicacion
    {

        string NombreCiudad { get; set; }
        string NombreDepartamento { get; set; }
        string Direccion { get; set; }
        string Descripcion { get; set; }


        public Ubicacion()
        {

        }
        public Ubicacion(string nombreCiudad, string nombreDepartamento, string direccion, string descripcion)
        {
            NombreCiudad = nombreCiudad;
            NombreDepartamento = nombreDepartamento;
            Direccion = direccion;
            Descripcion = descripcion;
        }
    }
}
