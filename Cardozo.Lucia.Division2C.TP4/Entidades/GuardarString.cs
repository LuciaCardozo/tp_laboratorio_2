using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        #region Metodo de Extesion
        /// <summary>
        /// Guarda los datos en un archivo de texto
        /// </summary>
        /// <param name="texto">texto a guardar</param>
        /// <param name="archivo">archivo es la ruta</param>
        /// <returns>retorna true si se puedo guardar caso contrario lanza una excepcion</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+archivo,true))
                {
                    writer.WriteLine(texto);
                    return true;
                }
            }
            catch
            {
                throw new Exception("Error en Metodo de Extension Guardar");
            }
        }
        #endregion
    }
}
