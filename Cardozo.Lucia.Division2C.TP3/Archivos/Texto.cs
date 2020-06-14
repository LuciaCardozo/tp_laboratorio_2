using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        #region Metodos Guardar y Leer
        /// <summary>
        /// Guarda un archivo de texto con el dato que le pase
        /// </summary>
        /// <param name="archivo">archivo en donde se guarda</param>
        /// <param name="dato">dato a guardar</param>
        /// <returns>retorna true si el archivo se guardo o caso contrario lanza una excepcion</returns>
        public bool Guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(dato);
                }
                return true;
            }
            catch(ArchivosException error)
            {
                throw new ArchivosException(error);
            }            
        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="dato">dato que contiene</param>
        /// <returns>retorna true si pudo leer el archivo o caso contrario lanza una excepcion</returns>
        public bool Leer(string archivo, out string dato)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    dato = reader.ReadToEnd();
                }
                return true;
            }
            catch (ArchivosException error)
            {
                throw new ArchivosException(error);
            }
        }
        #endregion
    }
}
