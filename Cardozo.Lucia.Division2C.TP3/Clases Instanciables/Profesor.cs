using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
        }
        /// <summary>
        /// Constructor estatico, solo de ejecuta una vez y inicializa el random
        /// </summary>
        static Profesor() 
        {
            Profesor.random = new Random();        
        }
        /// <summary>
        /// Construsctor donde inicializo el id, nombre, apellido,dni y nacionalidad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }
        #endregion

        #region Operadores de comparacion
        /// <summary>
        /// Compara si la clase del profesor es igual a la clase
        /// </summary>
        /// <param name="i">i es el profesor con las clases</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si coincide con la clase o caso contrario retorna false</returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            foreach(Universidad.EClases aux in i.claseDelDia)
            {
                if(aux == clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si la clase del profesor es distinto a la clase 
        /// </summary>
        /// <param name="i">i es el profesor con las clases</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si no coincide con la clase o caso contrario retorna false</returns>
        public static bool operator !=(Profesor i,Universidad.EClases clase)
        {
            return (!(i == clase));
        }
        #endregion

        #region Metodo ParticiparEnClase y RandomClases
        /// <summary>
        /// devuelve un numero random y lo guarda en Enqueue
        /// </summary>
        private void _randomClases()
        {
            int aux = random.Next(0,3);
            this.claseDelDia.Enqueue((Universidad.EClases)aux);
        }
        /// <summary>
        /// Devuelve todas las clases que tiene un profesor
        /// </summary>
        /// <returns>retorna los datos</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASES DEL DIA: ");
            foreach(Universidad.EClases aux in this.claseDelDia)
            {
                sb.AppendLine(aux.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra todos los datos de profesor
        /// </summary>
        /// <returns>retorna los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Llama al metodo MostrarDatos de profesor
        /// </summary>
        /// <returns>retorna los datos con la accesibilidad publica</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
