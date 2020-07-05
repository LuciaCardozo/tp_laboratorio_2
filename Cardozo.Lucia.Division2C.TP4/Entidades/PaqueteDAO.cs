using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estatico que se inicializa una sola vez al correr el programa
        /// Se instancia la conexion con la base de datos e instacia el comando y se le pasa la conexion 
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source=LULITA;Database=correo-sp-2017;Trusted_Connection=true");
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
        }
        #endregion

        #region Metodo Insertar
        /// <summary>
        /// Inserta un paquete a la base de datos
        /// </summary>
        /// <param name="p">p es un paquete</param>
        /// <returns>retorna true si puedo insertar o lanza una exception</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion.Open();
                comando.CommandText = string.Format("INSERT INTO Paquetes VALUES ('{0}','{1}','LuciaCardozo')",p.DireccionEntrega,p.TrackingID);
                comando.Connection = conexion;               
                comando.ExecuteNonQuery();           
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return true;
        }
        #endregion
    }
}
