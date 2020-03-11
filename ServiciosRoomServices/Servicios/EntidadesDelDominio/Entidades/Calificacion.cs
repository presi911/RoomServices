using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class Calificacion
    {
        int IdCalificacion { get; set; }
        string ComentarioCalificacion { get; set; }
        
        private byte calificacionHabitacion;

        public Calificacion(int idCalificacion, string comentarioCalificacion, byte calificacionHabitacion)
        {
            IdCalificacion = idCalificacion;
            ComentarioCalificacion = comentarioCalificacion;
            CalificacionHabitacion = calificacionHabitacion;
        }

        public byte CalificacionHabitacion{
            get => this.calificacionHabitacion;
            set => this.calificacionHabitacion = this.SetCalificacionHabitacion(value);
        }

        /// <summary>
        /// Permite establecer una calificación para un alojamiento, siempre y cuando esta se encuentre en el rango de 0 a 5
        /// Si el valor establecido no se encuentra dentro del rango establecido debe lanzarse una excepción.
        /// </summary>
        /// <param name="calificacion">valor de la calificación de la habitación a establecer</param>
        /// <returns>valor tipo byte( 8 bits) con la calificación del alojamiento </returns>
        private byte SetCalificacionHabitacion(byte calificacion)
        {
            return calificacion >= 0 && calificacion <= 5 ? calificacion : (byte) 0;
        }
    }
}
