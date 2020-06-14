using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml <T>: IArchivo <T>
    {
        #region Metodos Guardar y Leer
        /// <summary>
        /// Guarda un archivo xml con el dato que le pase
        /// </summary>
        /// <param name="archivo">archivo en donde se guarda</param>
        /// <param name="dato">dato a guardar</param>
        /// <returns>retorna true si el archivo se guardo o caso contrario lanza una excepcion</returns>
        public bool Guardar(string archivo,T dato)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer,dato);
                }               
                return true;
            }
            catch(ArchivosException error)
            {
                throw new ArchivosException(error);
            }
        }
        /// <summary>
        /// Lee un archivo xml 
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="dato">dato que contiene</param>
        /// <returns>retorna true si pudo leer el archivo o caso contrario lanza una excepcion</returns>
        public bool Leer(string archivo, out T dato)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer des = new XmlSerializer(typeof(T));
                    dato = (T)des.Deserialize(reader);
                }
                return true;
            }
            catch(ArchivosException error)
            {
                throw new ArchivosException(error);
            }
        }
        #endregion
    }
}
