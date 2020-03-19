//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CalificacionesAlojamiento
    {
        [Key, Column(Order = 1)]
        public int idCalificacion { get; set; }
        [Key, Column(Order = 2)]
        public string cedulaArrendatario { get; set; }
        [Key, Column(Order = 3)]
        public int idAlojamiento { get; set; }
        [Key, Column(Order = 4)]
        public System.DateTime fechaCalificacion { get; set; }
    
        public virtual Alojamientos Alojamientos { get; set; }
        public virtual Arrendatarios Arrendatarios { get; set; }
        public virtual Calificaciones Calificaciones { get; set; }
    }
}
