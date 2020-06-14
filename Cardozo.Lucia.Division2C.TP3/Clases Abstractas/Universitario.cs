using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Metodo Abstracto
        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns>retorna un string</returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        { }
        /// <summary>
        /// Construsctor donde inicializo el legajo, nombre, apellido,dni y nacionalidad
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Operadores de comparacion
        /// <summary>
        /// Compara que el tipo de dato sea el mismo
        /// </summary>
        /// <param name="obj">obj a comparar</param>
        /// <returns>retorna un universitario</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        /// <summary>
        /// Compara si son iguales los universitarios
        /// </summary>
        /// <param name="pg1">Universitario Uno</param>
        /// <param name="pg2">Universitario Dos</param>
        /// <returns>retorna true si son iguales o false si no lo son</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            if(pg1.Equals(pg2) && pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si son distinto los universitarios
        /// </summary>
        /// <param name="pg1">Universitario Uno</param>
        /// <param name="pg2">Universitario Dos</param>
        /// <returns>retorna true si es distinto</returns>
        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return (!(pg1 == pg2));
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra todo los datos del universitario
        /// </summary>
        /// <returns>retorna los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NúMERO: {this.legajo}");
            return sb.ToString();
        }
        #endregion
    }
}
