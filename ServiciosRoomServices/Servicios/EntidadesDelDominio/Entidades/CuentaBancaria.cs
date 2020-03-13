using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class CuentaBancaria
    {
        int NúmeroCuenta { get; }
        double SaldoCuenta { get; set; }

        /// <summary>
        /// Permite instanciar la cuenta bancaria de un cliente arrendatario o arrendador
        /// </summary>
        /// <param name="saldoCuenta">Saldo disponible en la cuenta bancaria</param>
        public CuentaBancaria(double saldoCuenta)
        {
            SaldoCuenta = saldoCuenta;
        }
    }
}
