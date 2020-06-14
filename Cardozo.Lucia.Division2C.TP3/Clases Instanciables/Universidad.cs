using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerado Clases
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto. Inicializo las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
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
        /// Propiedad de Instructores, obtengo la lista de profesores o guardo la lista
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de Jornadas, obtengo la lista de jornadas o guardo la lista
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad de Jornadas por posicion, obtengo una jornada con la posicion o guardo la jornada
        /// </summary>
        /// <param name="i">posicion</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Operadores de Comparacion y Agregar de Universidad/Alumno
        /// <summary>
        /// Compara si el alumno de la universidad es igual al alumno
        /// </summary>
        /// <param name="gestion">gestion es la universidad que tiene alumnos</param>
        /// <param name="alumno">alumno a comparar</param>
        /// <returns>retorna true si son iguales o caso contrario retorna false</returns>
        public static bool operator ==(Universidad gestion,Alumno alumno)
        {
            foreach(Alumno aux in gestion.alumnos)
            {
                if(aux == alumno)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si el alumno de la universidad es distinto al alumno
        /// </summary>
        /// <param name="gestion">gestion es la universidad que tiene alumnos</param>
        /// <param name="alumno">alumno a comparar</param>
        /// <returns>retorna true si son distinto</returns>
        public static bool operator !=(Universidad gestion, Alumno alumno)
        {
            return (!(gestion == alumno));
        }
        /// <summary>
        /// Agrega un alumno si no existe en la lista de alumnos de Universidad
        /// </summary>
        /// <param name="universidad">universidad en donde se agregara el alumno</param>
        /// <param name="alumno">alumno a agregar</param>
        /// <returns>retorna la universidad si se agrego el alumno o caso contrario lanza un excepcion</returns>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if(universidad == alumno)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                universidad.alumnos.Add(alumno);
                return universidad;
            }
        }
        #endregion

        #region Operadores de Comparacion y Agregar de Univesidad/Profesor
        /// <summary>
        /// Compara si el profesor de la universidad es igual al profesor
        /// </summary>
        /// <param name="gestion">gestion es la universidad que tiene los profesores</param>
        /// <param name="instructor">instructor es el profesor a comparar</param>
        /// <returns>retorna true si son iguales o caso contrario retorna false</returns>
        public static bool operator ==(Universidad gestion,Profesor instructor)
        {
            foreach(Profesor aux in gestion.profesores)
            {
                if(aux == instructor)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si el profesor de la universidad es distinto al profesor
        /// </summary>
        /// <param name="gestion">gestion es la universidad que tiene los profesores</param>
        /// <param name="instructor">instructor es el profesor a comparar</param>
        /// <returns>retorna true si son distintos o caso contrario retorna false</returns>
        public static bool operator !=(Universidad gestion,Profesor instructor)
        {
            return (!(gestion == instructor));
        }
        /// <summary>
        /// Agrega un profesor si no existe en la lista de profesores de Universidad
        /// </summary>
        /// <param name="universidad">universidad en donde se agregara el profesor</param>
        /// <param name="instructor">instructor es el profesor a agregar</param>
        /// <returns>retorna la universidad</returns>
        public static Universidad operator +(Universidad universidad,Profesor instructor)
        {
            if(universidad == instructor)
            {
                return universidad;
            }
            else
            {
                universidad.profesores.Add(instructor);
                return universidad;
            }
        }
        #endregion

        #region Operadores de Comparacion y Agregar de Univerdad/Clase
        /// <summary>
        /// Compara si el profesor de la universidad es igual a la clase
        /// </summary>
        /// <param name="universidad">Universidad que tiene los profesores</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna el profesor si es igual o caso contrario lanza una excepcion</returns>
        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach(Profesor aux in universidad.profesores)
            {
                if(aux == clase)
                {
                    return aux;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Compara si el profesor de la universidad es distinto a la clase
        /// </summary>
        /// <param name="universidad">Universidad que tiene los profesores</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna el profesor si es distinto o caso contrario lanza una excepcion</returns>
        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach(Profesor aux in universidad.profesores)
            {
                if(aux != clase)
                {
                    return aux;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega a una jornada nueva alumnos que exista en la clase de Universidad y agraga esa jornada a la universidad
        /// </summary>
        /// <param name="gestion">gestion es la universidad con los alumnos</param>
        /// <param name="clase">clase a comparar para agregar alumnos</param>
        /// <returns>retorna la universidad con la nueva jornada</returns>
        public static Universidad operator +(Universidad gestion, EClases clase)
        {
            Jornada jornada = new Jornada(clase,(gestion == clase));
            foreach(Alumno aux in gestion.alumnos)
            {
                if(aux == clase)
                {
                    jornada.Alumnos.Add(aux);
                }
            }
            gestion.jornada.Add(jornada);
            return gestion;
        }
        #endregion

        #region Metodos Guardar y Leer
        /// <summary>
        /// Guarda una Universidad en formato xml
        /// </summary>
        /// <param name="universidad">universidad a guardar</param>
        /// <returns>retorna true si puedo guardar la universidad o caso contrario retorna false</returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> xmlUniversidad = new Xml<Universidad>();
            if(xmlUniversidad.Guardar("Universidad.xml",universidad))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lee una Universidad en formato xml
        /// </summary>
        /// <returns>retorna la universidad si puedo leerlo</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xmlUniversidad = new Xml<Universidad>();
            xmlUniversidad.Leer("Universidad.xml",out Universidad universidad);
            return universidad;
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra todo los datos 
        /// </summary>
        /// <param name="uni">uni es la universidad en donde se encuentran las jornadas</param>
        /// <returns>retorna los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada auxJornada in uni.jornada)
            {
                sb.AppendLine(auxJornada.ToString());
                sb.AppendLine("<-------------------------------------------------->");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Llama al metodo MostrarDatos de Universidad
        /// </summary>
        /// <returns>retorna los datos con la accesibilidad publica</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion
    }
}
