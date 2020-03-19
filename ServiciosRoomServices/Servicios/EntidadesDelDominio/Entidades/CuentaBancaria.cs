using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.EntidadesDelDominio.Entidades
{
    public class CuentaBancaria
    {
        int NúmeroCuenta { get; }
        private double saldoCuenta;

        public double SaldoCuenta 
        {
            get => this.saldoCuenta;
            set => this.saldoCuenta = this.SetSaldoCuenta(value);
        
        }

        /// <summary>
        /// Permite instanciar la cuenta bancaria de un cliente arrendatario o arrendador
        /// </summary>
        /// <param name="saldoCuenta">Saldo disponible en la cuenta bancaria</param>
        /// 
        public CuentaBancaria(double saldoCuenta)
        {
            saldoCuenta = saldoCuenta;
        }

        public double SetSaldoCuenta(double saldo)
        {
            return saldo >= 0 ? saldo: 0;
        }
    }
}
