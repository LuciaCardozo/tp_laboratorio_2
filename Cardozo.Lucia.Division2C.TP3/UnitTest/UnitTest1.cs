using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifico que se lanze la excepcion si el dni no es valido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Alumno alumno = new Alumno(1, "Lucia", "Cardozo", "sfsdf",
                Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }
        /// <summary>
        /// Verifico que se lanze la excepcion si el dni no coincide con la nacionalidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalida()
        {
            Alumno alumno = new Alumno(1, "Lucia", "Cardozo", "98659865",
                Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }
        /// <summary>
        /// Verifico que la lista de alumno que tiene jornada no sea null
        /// </summary>
        [TestMethod]
        public void TestInstancia()
        {
            Profesor profesor = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Assert.IsNotNull(jornada.Alumnos);
        }
    }
}
