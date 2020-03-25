using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDelDominio.Entidades
{
    class CuentaUsuario
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
