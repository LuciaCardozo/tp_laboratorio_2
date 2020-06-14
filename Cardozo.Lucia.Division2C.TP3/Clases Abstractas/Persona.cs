using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Enumerado de Nacionalidad
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de Apellido, obtengo el apellido o guardo el apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de Nombre, obtengo el nombre o guardo el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de Nacionalidad, obtengo la nacionalidad o guardo la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad de Dni, obtengo el dni o guardo el dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(value,nacionalidad);
            }
        }
        /// <summary>
        /// Propiedad de StringToDni, obtengo el dni como un string o guardo el dni como un string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.ValidarDni(this.nacionalidad,value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        { }
        /// <summary>
        /// Construsctor donde inicializo el nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Construsctor donde inicializo el nombre, apellido,dni y nacionalidad
        /// Reutilizo codigo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.dni = dni;
        }
        /// <summary>
        /// Construsctor donde inicializo el nombre, apellido,dni y nacionalidad
        /// Reutilizo codigo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida si el dni corresponde a un Argentino o un Extranjero
        /// Caso contrario lanzo una excepcion
        /// </summary>
        /// <param name="nacionalidad">nacionalidad a validar</param>
        /// <param name="dato">dato a validar</param>
        /// <returns></returns>
        private int ValidarDni(int dato,ENacionalidad nacionalidad)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                this.dni = dato;
                this.nacionalidad = nacionalidad;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                this.dni = dato;
                this.nacionalidad = nacionalidad;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el dni");
            }

            return dato;
        }
        /// <summary>
        /// Convierte un dato de tipo string a int y valida que el dni sea solo numero y no contenga otros caracteres
        /// Caso contrario lanzo una excepcion. Reutilizo codigo
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dato a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int numero;
            if(Regex.IsMatch(dato,@"^[1-9]{1}[0-9]{1,7}$") && Int32.TryParse(dato, out numero))
            {
                this.ValidarDni(numero,nacionalidad);
            } 
            else
            {
                throw new DniInvalidoException();
            }
            return numero;
        }
        /// <summary>
        /// Valida si el dato es solo letras.
        /// </summary>
        /// <param name="dato">dato a validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-ZñÑ]{3-30}$"))
            {
                return dato;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Mostrar Datos
        /// <summary>
        /// Muestra todo los datos que contiene una persona
        /// </summary>
        /// <returns>retorna los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido} {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            //sb.AppendLine($"DNI: {this.dni}");
            return sb.ToString();
        }
        #endregion
    }
}
