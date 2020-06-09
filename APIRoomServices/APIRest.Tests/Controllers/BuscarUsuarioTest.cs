using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.ControlRepository;
using Dominio.EntidadesDelDominio;
using Dominio.EntidadesDelDominio.Entidades;

namespace APIRest.Tests.Controllers
{
    [TestClass]
    public class BuscarUsuarioTest
    {

        /// <summary>
        /// Probar ingresar la cédula de un usuario existente.
        /// Para un usuario inexistente, intentar obtener información a partir de la  cédula 5434266,
        /// deberia retornar un objeto nulo
        /// </summary>
        [TestMethod]
        public void TestListaArrendador()
        {
            //Instanciación de los Objetos necesarios para la prueba:
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();

            string cedulaArrendador = "1118237090";
            var resultado = controlAlquiler.listaArredandor(cedulaArrendador);
            Assert.AreEqual(null,resultado);
        }


        /// <summary>
        /// Probar consultar la información de un usuario arrendador, a partir de su cédula.
        /// Para un usuario registrado previamente en la plataforma, con cédula 1118237090
        /// Se espera que el método retorne un objeto tipo alojamiento con su información:
        /// cédula: 1098310693
        /// nombre: Cristian
        /// apellido: Duran Londoño
        /// fecha: 1995-08-21
        /// nacionalidad: Colombiana
        /// genero: M
        /// </summary>
        [TestMethod]
        public void TestListaArrendador2()
        {
            //Instanciación de los Objetos necesarios para la prueba:
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();

            Arrendador arrendarorTest = new Arrendador()
            {
                Cedula = "1098310693",
                Nombre = "Cristian",
                Apellido = "Duran Londoño",
                Fecha = new DateTime(1995, 08, 21),
                Nacionalidad = "Colombiana",
                Genero = "M"
            };

            string cedulaArrendador = "1098310693";
            var resultado = controlAlquiler.listaArredandor(cedulaArrendador);
            Assert.AreEqual(arrendarorTest.Cedula, resultado.Cedula);
            Assert.AreEqual(arrendarorTest.Nombre, resultado.Nombre);
            Assert.AreEqual(arrendarorTest.Apellido, resultado.Apellido);
            Assert.AreEqual(arrendarorTest.Genero, resultado.Genero);
            Assert.AreEqual(arrendarorTest.Nacionalidad, resultado.Nacionalidad);
            Assert.AreEqual(arrendarorTest.Fecha, resultado.Fecha);
        }


        /// <summary>
        /// Probar consultar un usuario arrendatario inexistente
        /// Para un usuario arrendador inexistente, intentar obtener información a partir de la  cédula 5434266,
        /// se espera el retorno de un objeto nulo
        /// </summary>
        [TestMethod]
        public void TestListaArrendatario()
        {
            //Instanciación de los Objetos necesarios para la prueba:
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();

            string cedulaArrendador = "5434266";
            var resultado = controlAlquiler.listaArrendatario(cedulaArrendador);
            Assert.AreEqual(null, resultado);
            
        }
    }
}
