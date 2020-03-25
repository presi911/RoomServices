using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDelDominio.Entidades
{
    public class AlbumFotografico
    {
        public int IdArchivo { get; }
        public string NombreArchivo { get; set; }
        public string Formato { get; set; }
        public string RutaGuardado { get; set; }

        /// <summary>
        /// Permite instanciar la información correspondiente a una imagen de un alojamiento
        /// </summary>
        /// <param name="nombreArchivo">Nombre que asignado a la fotografía cargada en la plataforma</param>
        /// <param name="formato">formato de el archivo 'imagen' almacenado</param>
        /// <param name="rutaGuardado">Ubicación en la cual estará almacenado el archivo</param>
        public AlbumFotografico(string nombreArchivo, string formato, string rutaGuardado)
        {
            this.NombreArchivo = nombreArchivo;
            this.Formato = formato;
            this.RutaGuardado = rutaGuardado;
        }

        public AlbumFotografico()
        {

        }
    }
}
