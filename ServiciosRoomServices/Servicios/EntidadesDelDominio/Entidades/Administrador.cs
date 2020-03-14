using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class Administrador
    {
        int CedulaAdministrador { get; set; }
        string NombreAdministrador { get; set; }


        public Administrador(int CedulaAdministrador, string NombreAdministrador)
        {

            CedulaAdministrador = CedulaAdministrador;
            NombreAdministrador = NombreAdministrador;
        
        }
    }
}



