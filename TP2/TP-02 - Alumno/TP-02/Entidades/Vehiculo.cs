using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA: {this.marca.ToString()}");
            sb.AppendLine($"COLOR: {this.color.ToString()}");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        public static explicit operator string(Vehiculo vehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {vehiculo.chasis}\r\n");
            sb.AppendLine($"MARCA : {vehiculo.marca.ToString()}\r\n");
            sb.AppendLine($"COLOR : {vehiculo.color.ToString()}\r\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="vehiculoUno"></param>
        /// <param name="vehiculoDos"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {           
            return (vehiculoUno.chasis == vehiculoDos.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="vehiculoUno"></param>
        /// <param name="vehiculoDos"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return !(vehiculoUno == vehiculoDos);
        }
    }
}
