using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerado Estado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de Direccion, obtengo la direccion o la guardo
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Propiedad de Estado, obtengo el Estado o lo guardo
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Propiedad de TrackingID, obtengo el TrackingID o lo guardo
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor donde incializo la direccion, trackingId y el estado en ingresado
        /// </summary>
        /// <param name="direccionEntrega">direccion a guardar</param>
        /// <param name="trackingID">trackingId a guardar</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Operadores de comparacion
        /// <summary>
        /// Compara si el paqueteUno es igual al paqueteDos
        /// </summary>
        /// <param name="paqueteUno">PaqueteUno a comparar</param>
        /// <param name="paqueteDos">PaqueteDos a comparar</param>
        /// <returns>retorna true si es igual, caso contrario retorna false</returns>
        public static bool operator ==(Paquete paqueteUno,Paquete paqueteDos)
        {
            if(paqueteUno.trackingID == paqueteDos.trackingID)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara si el paqueteUno es distinto al paqueteDos
        /// </summary>
        /// <param name="paqueteUno">PaqueteUno a comparar</param>
        /// <param name="paqueteDos">PaqueteDos a comparar</param>
        /// <returns>retorna true si es distinto, caso contrario retorna false</returns>
        public static bool operator !=(Paquete paqueteUno, Paquete paqueteDos)
        {
            return (!(paqueteUno == paqueteDos));
        }
        #endregion

        #region Delegado y Evento
        public delegate void DelegateEstado(object obj);
        public event DelegateEstado InformarEstado;
        #endregion

        #region Metodo MockCicloDeVida
        /// <summary>
        /// Si el estado es igual a entregado lo inserta a la base de datos.
        /// Si es distinto lo recorre pausandolo por 4 segundos, cambia el estado del paquete e informa el estado a través del evento.
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                InformarEstado(this);
            }
            PaqueteDAO.Insertar(this); 
        }
        #endregion

        #region Metodo MostrarDatos y ToString
        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>retorna la informacion</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {         
            return string.Format($"{((Paquete)elemento).TrackingID} para {((Paquete)elemento).DireccionEntrega}");
        }
        /// <summary>
        /// Muestra la informacion del paquete llamando al metodo this.MostrarDatos
        /// </summary>
        /// <returns>retorna un string con la informacion del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion
    }
}
