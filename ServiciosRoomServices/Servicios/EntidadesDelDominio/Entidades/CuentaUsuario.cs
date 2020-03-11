using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class CuentaUsuario
    {

        private string email; 
        string Contrasena { get; set; }

        public CuentaUsuario(string email, string contrasena)
        {
            this.email = email;
            Contrasena = contrasena;
        }
    }
}
