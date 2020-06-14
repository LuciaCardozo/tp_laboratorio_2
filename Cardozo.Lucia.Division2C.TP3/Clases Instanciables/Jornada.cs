using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de Alumnos, obtengo la lista de alumnos o guardo la lista
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de Clase, obtengo la clase o guardo la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de Instructor, obtengo el profesor o guardo el profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase,Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Operadores de Comparacion y Agregar
        /// <summary>
        /// Compara si el alumno de la jornada es igual al alumno
        /// </summary>
        /// <param name="jornada">jornada con los alumnos</param>
        /// <param name="alumno">alumno a comparar</param>
        /// <returns>retorna true si son iguales o caso contrario retorna false</returns>
        public static bool operator ==(Jornada jornada,Alumno alumno)
        {
            foreach(Alumno aux in jornada.alumnos)
            {
                if(aux == alumno)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si el alumno de la jornada es distinto al alumno
        /// </summary>
        /// <param name="jornada">jornada con los alumnos</param>
        /// <param name="alumno">alumno a comparar</param>
        /// <returns>retorna true si son distintos</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return (!(jornada == alumno));
        }
        /// <summary>
        /// Agrega un alumno si no existe en la lista de alumnos de jornada
        /// </summary>
        /// <param name="jornada">jornada con los alumnos</param>
        /// <param name="alumno">alumno a agregar</param>
        /// <returns>retorna true si se agrego el alumno o caso contrario lanza un excepcion</returns>
        public static bool operator +(Jornada jornada, Alumno alumno)
        {
            if(jornada == alumno)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                jornada.alumnos.Add(alumno);
                return true;
            }
        }
        #endregion

        #region Metodos Guardar y Leer 
        /// <summary>
        /// Guarda una jornada en formato texto
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>retorna true si puedo guardar el texto de jornada o caso contrario retorna false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto textoJornada = new Texto();
            if(textoJornada.Guardar("TextoJornada.txt",jornada.ToString()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Leer una jornada en formato texto
        /// </summary>
        /// <returns>retorna el texto de la jornada si puedo leer o caso contrario retorna vacio</returns>
        public static string Leer()
        {
            Texto textoJornada = new Texto();
            if(textoJornada.Leer("TextoJornada.txt",out string jornada))
            {
                return jornada;
            }
            return "";
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>retorna los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.clase.ToString()} POR {this.instructor.ToString()}");
            sb.AppendLine($"ALUMNOS: ");
            foreach(Alumno aux in this.alumnos)
            {
                sb.AppendLine(aux.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
