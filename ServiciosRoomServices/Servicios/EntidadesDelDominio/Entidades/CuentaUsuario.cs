using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{//Lider de calidad
    public class CuentaUsuario
    {

        string Email { get; } 
        string Contrasena { get; set; }

        public CuentaUsuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }

    }
}
