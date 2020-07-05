using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto que inicializo las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de paquetes, obtengo la lista de paquetes o guardo la lista
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Metodo Mostrar Datos
        /// <summary>
        /// Muestra la informacion de los paquete que contiene el correo
        /// </summary>
        /// <param name="elementos">elementos es la lista de paquetes a recorrer</param>
        /// <returns>retorna la informacion</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Paquete auxPaquete in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n",auxPaquete.TrackingID,auxPaquete.DireccionEntrega,auxPaquete.Estado.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operador +
        /// <summary>
        /// Agrega un paquete al correo si no existe, crea un hilo nuevo pasandole el metodo  
        /// que esta en la clase paquete (MockCicloDeVida), agrega el hilo en la lista de hilos y lo inicializa
        /// </summary>
        /// <param name="correo">correo que contiene la lista de paquetes a recorrer</param>
        /// <param name="paquete">paquete a comparar no si existe para poder agregarlo al correo</param>
        /// <returns>retorna el correo caso, contrario lanza una excepcion</returns>
        public static Correo operator +(Correo correo,Paquete paquete)
        {
            foreach(Paquete auxPaquete in correo.paquetes)
            {
                if(auxPaquete == paquete)
                {
                    throw new TrackingIdRepetidoException($"El Tracking ID {paquete.TrackingID} ya figura en la lista de envios.");
                }
            }
            correo.paquetes.Add(paquete);
            Thread thread = new Thread(paquete.MockCicloDeVida);
            correo.mockPaquetes.Add(thread);
            thread.Start();
            return correo;
        }
        #endregion

        #region Metodo Fin de entregas
        /// <summary>
        /// Aborta todos los hilos que esten activos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread auxThread in this.mockPaquetes)
            {
                if(auxThread.IsAlive)
                {
                    auxThread.Abort();
                }
            }
        }
        #endregion
    }
}
