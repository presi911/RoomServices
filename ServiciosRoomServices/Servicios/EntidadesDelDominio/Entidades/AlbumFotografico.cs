using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class AlbumFotografico
    {
        int IdArchivo { get; }
        string NombreArchivo { get; set; }
        string Formato { get; set; }
        string RutaGuardado { get; set; }

        /// <summary>
        /// Permite instanciar la información correspondiente a una imagen de un alojamiento
        /// </summary>
        /// <param name="nombreArchivo">Nombre que asignado a la fotografía cargada en la plataforma</param>
        /// <param name="formato">formato de el archivo 'imagen' almacenado</param>
        /// <param name="rutaGuardado">Ubicación en la cual estará almacenado el archivo</param>
        public AlbumFotografico(string nombreArchivo, string formato, string rutaGuardado)
        {
            NombreArchivo = nombreArchivo;
            Formato = formato;
            RutaGuardado = rutaGuardado;
        }
    }
}
