using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza un calculo segun los numeros y el operador que se le pasan por parametro
        /// </summary>
        /// <param name="numUno">numeroUno valor para el calculo</param>
        /// <param name="numDos">numeroDos valor para el calculo</param>
        /// <param name="operador">operador valor para la operacion</param>
        /// <returns>Retorna el resultado de la operacion, caso contrario 0</returns>
        public static double Operar(Numero numUno, Numero numDos, string operador)
        {
            double resultado = 0;
            string operadorValidado = Calculadora.ValidarOperador(operador);
            switch (operadorValidado)
            {
                case "+":
                    resultado = numUno + numDos;
                    break;
                case "-":
                    resultado = numUno - numDos;
                    break;
                case "*":
                    resultado = numUno * numDos;
                    break;
                case "/":
                    resultado = numUno / numDos;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que valor ingresado se un operador
        /// </summary>
        /// <param name="operador">operador valor para validar</param>
        /// <returns>Retorna el operador caso contrario retorna en suma</returns>
        private static string ValidarOperador(string operador)
        {
            string resultado = "+";
            if (!(operador is null))
            {
                if (operador == "-" || operador == "/" || operador == "*")
                {
                    resultado = operador;
                }
            }
            return resultado;
        }
    }
}
