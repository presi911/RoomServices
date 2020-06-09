using System;
using Dominio.EntidadesDelDominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.ControlRepository;


namespace APIRest.Tests.Controllers
{
    [TestClass]
    public class ListarAlquiler
    {
        /*
         * Probamos el método de listar alquiler actualmente
         * registrado. 
         * Parámetro de ingreso el # de contrato
         * Se espera como respuesta el # de contrato, # meses y pago mensual
         *
         * **/
        [TestMethod]
        public void TestListarAlquilerExistente()
        {
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();

            Alquiler exist = controlAlquiler.listaAlquiler(2);

            Alquiler test = new Alquiler()
            {
                NumeroContrato = 1,
                numeroMeses = 13,
                PagoMensual = 900000,
            };

            Assert.AreEqual(test.NumeroContrato, exist.NumeroContrato);
            Assert.AreEqual(test.NumeroMeses, exist.NumeroMeses);
            Assert.AreEqual(test.NumeroContrato, exist.NumeroContrato);

        }

        /*
         * Probamos el método de listar alquiler actualmente no registrado.
         * Parámetro de ingreso el # de contrato.
         * Se espera como respuesta un Null (Significa que no existe)
         * **/
        public void TestListarAlquilerNoExistente()
        {
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();
            Alquiler exist = controlAlquiler.listaAlquiler(-9999);
            Assert.IsNull(exist);

        }
    }
}
