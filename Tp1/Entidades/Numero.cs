using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setea y valida valor, caso contrario se setea en 0;
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor por defecto, inicializa con el valor 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Inicializa con el valor pasado por parametro.
        /// </summary>
        /// <param name="numero">numero valor del parametro</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa con el valor pasado por parametro.
        /// valida, caso contrario lo seteo en 0.
        /// </summary>
        /// <param name="strNumero">strNumero valor del parametro</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Suma de dos numeros
        /// </summary>
        /// <param name="numeroUno">numeroUno valor para la suma</param>
        /// <param name="numeroDos">numeroDos valor para la suma</param>
        /// <returns>Retorna el numero resultante</returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return (numeroUno.numero + numeroDos.numero);
        }

        /// <summary>
        /// Resta de dos numeros
        /// </summary>
        /// <param name="numeroUno">numeroUno valor para la resta</param>
        /// <param name="numeroDos">numeroDos valor para la resta</param>
        /// <returns>Retorna el numero resultante</returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }

        /// <summary>
        /// Multiplicacion de dos numeros
        /// </summary>
        /// <param name="numeroUno">numeroUno valor para la multiplicacion</param>
        /// <param name="numeroDos">numeroDos valor para la multiplicacion</param>
        /// <returns>Retorna el numero resultante</returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }

        /// <summary>
        /// Division de dos numeros y valida que numeroDos sea distinto de 0.
        /// </summary>
        /// <param name="numeroUno">numeroUno valor para la division</param>
        /// <param name="numeroDos">numeroDos valor para la division</param>
        /// <returns>Retorna el numero resultante</returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if (numeroDos.numero != 0)
            {
                return numeroUno.numero / numeroDos.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Valida el valor pasado por parametro de tipo string a entero
        /// </summary>
        /// <param name="strNumero">strNumero valor para validar</param>
        /// <returns>Retorna el valor validado o 0 en caso de no poder convertirlo</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;
            if (!(strNumero is null))
            {
                if (double.TryParse(strNumero, out numero))
                {
                    return numero;
                }
            }
            return numero;
        }

        /// <summary>
        /// Valido que el valor pasado por parametro de tipo string sea
        /// un binario y lo convierto a decimal.
        /// </summary>
        /// <param name="binario">binario valor del parametro</param>
        /// <returns>Retorno un numero decimal o "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            int posicion = 0;
            double retornoEntero = 0;
            int numero;
            Stack<char> pila = new Stack<char>();
            foreach (char letra in binario)
            {
                pila.Push(letra);
            }
            foreach (char letra in pila)
            {
                Int32.TryParse(letra.ToString(), out numero);
                if (numero != 0 && numero != 1)
                {
                    return "Valor invalido";
                }
                retornoEntero += numero * (Math.Pow(2, posicion));
                posicion++;
            }
            return retornoEntero.ToString();
        }

        /// <summary>
        /// Valido que numero pasado por parametro sea mayor o igual a 0 
        /// y convierto el numero a binario.
        /// </summary>
        /// <param name="numero">numero valor para convertir</param>
        /// <returns>Retorna un numero en binario o "valor invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            if (numero >= 0)
            {
                return Convert.ToString(Convert.ToInt32(numero), 2);
            }
            return "Valor Invalido";
        }

        /// <summary>
        /// Valido que numero pasado por parametro de tipo string sea entero 
        /// y reutilizo codigo
        /// </summary>
        /// <param name="numero">numero valor para convertir</param>
        /// <returns>Retorna un numero en binario o "valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            double numValue;
            if (Double.TryParse(numero, out numValue))
            {
                return DecimalBinario(numValue);
            }
            return "Valor Invalido";
        }
    }
}
