using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Estacionamiento(int espacioDisponible): this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="estacionamiento">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento estacionamiento, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", estacionamiento.vehiculos.Count, estacionamiento.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo vehiculo in estacionamiento.vehiculos)
            {                      
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (vehiculo is Camioneta)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (vehiculo is Moto)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                        }
                        break;                   
                    case ETipo.Automovil:
                        if (vehiculo is Automovil)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.Todos:
                        sb.AppendLine(vehiculo.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="estacionamiento">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            foreach (Vehiculo auxVehiculo in estacionamiento.vehiculos)
            {
                if (auxVehiculo == vehiculo)
                {
                    return estacionamiento;
                }                  
            }
            if(estacionamiento.espacioDisponible > estacionamiento.vehiculos.Count)
            {
                 estacionamiento.vehiculos.Add(vehiculo);
            }
            return estacionamiento;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="estacionamiento">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento estacionamiento, Vehiculo vehiculo)
        {
            foreach (Vehiculo auxVehiculo in estacionamiento.vehiculos)
            {
                if (auxVehiculo == vehiculo)
                {
                    estacionamiento.vehiculos.Remove(auxVehiculo);
                    break;
                }
            }
            return estacionamiento;
        }
        #endregion
    }
}
