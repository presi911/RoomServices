using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class Alojamiento
    {
        string Titulo { get; set; }
        string DescripcionAlojamiento { get; set; }
        private double precio;
        string TipoAlojamiento { get; set; }
        int IdAlojamiento { get;  }
        Arrendatario arrendatario;
        List<AlbumFotografico> fotos;


        public Alojamiento(string titulo, string descripcionAlojamiento, double precio, string tipoAlojamiento, int idAlojamiento)
        {
            Titulo = titulo;
            DescripcionAlojamiento = descripcionAlojamiento;
            Precio= precio;
            TipoAlojamiento = tipoAlojamiento;
            IdAlojamiento = idAlojamiento;
        }

        /// <summary>
        /// Autopropiedad que permite obtener o modificar el valor del atributo 'precio'
        /// </summary>
        double Precio
        {
            get => this.precio;
            set => this.precio = this.SetPrecio(value);
        }

        /// <summary>
        /// Permite modificar el precio del alojamiento, si el valor ingresado es menor a cero, se dispara una excepción indicando
        /// el error ocurrido
        /// Si el valor establecido no se encuentra dentro del rango establecido debe lanzarse una excepción.

        /// </summary>
        /// <param name="precio" Valor númerico con el precio a establecer para la habitación></param>
        /// <returns>Valor númerico con el precio de la habitación</returns>
        public double SetPrecio(double precio)
        {
            return precio >= 0 ? precio : 0;
        }


    }

}