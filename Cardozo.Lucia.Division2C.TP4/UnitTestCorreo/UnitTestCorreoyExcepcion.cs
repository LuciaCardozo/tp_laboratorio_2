using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestCorreo
{
    [TestClass]
    public class UnitTestCorreoYExcepcion
    {        
        /// <summary>
        /// Verifica que lista de paquetes que tiene correo este instanciada
        /// </summary>
        [TestMethod]
        public void TestMethodInstancia()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica que se lanze la excepcion si el trackingId es igual
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethodException()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("viamonte", "1414");
            Paquete paqueteDos = new Paquete("jujuy", "1414");

            correo += paqueteUno;
            correo += paqueteDos;
        }
    }
}
