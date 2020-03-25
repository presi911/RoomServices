using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDelDominio.Entidades
{
    public class Administrador
    {
        int CedulaAdministrador { get; set; }
        string NombreAdministrador { get; set; }


        public Administrador(int CedulaAdministrador, string NombreAdministrador)
        {

            this.CedulaAdministrador = CedulaAdministrador;
            this.NombreAdministrador = NombreAdministrador;

        }
    }
}
