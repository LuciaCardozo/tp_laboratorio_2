using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado del Estado de Cuenta
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        { }
        /// <summary>
        /// Construsctor donde inicializo el id, nombre, apellido,dni, nacionalidad y claseQueToma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Construsctor donde inicializo el id, nombre, apellido,dni, nacionalidad, claseQueToma y estadoCuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Operadores de comparacion
        /// <summary>
        /// Compara si la clase del alumno es igual a la clase y si no es deudor
        /// </summary>
        /// <param name="a">a es el alumno con la clase a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si coincide con la clase y no es deudor o caso contrario retorna false</returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si la clase del alumno es distinto a la clase   
        /// </summary>
        /// <param name="a">a es el alumno con la clase a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si no coincide con la clase o caso contrario retorna false</returns>
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Metodo ParticiparEnClase
        /// <summary>
        /// Muestra la clase que toma
        /// </summary>
        /// <returns>retorna la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: "+this.claseQueToma.ToString();
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>retorna los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta.ToString()}");
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Llama al metodo MostrarDatos de alumno
        /// </summary>
        /// <returns>retorna los datos con la accesibilidad publica</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
