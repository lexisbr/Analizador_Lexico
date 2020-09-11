using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class Archivo
    {
        private String direccionActual = "";

        public Archivo()
        {
           
        }

        public String getdireccionActual()
        {
            return direccionActual;
        }
        public void setdireccionActual(String direccion)
        {
            direccionActual = direccion;
        }

        public void guardarArchivoComo(String direccion, String texto)
        {
            try
            {
                    StreamWriter guardar = File.CreateText(direccion);
                    guardar.Write(texto);
                    guardar.Close();
                    System.Windows.Forms.MessageBox.Show("Archivo guardado exitosamente.");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }

        }

        public void guardarArchivo()
        {

        }

        public String abrirArchivo(String direccion)
        {
            try
            {
                TextReader abrir = new StreamReader(direccion);
                String texto;
                texto = abrir.ReadToEnd();
                abrir.Close();
                return texto;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error ");
                return "";
            }
        }

        public void nuevoArchivo()
        {

        }

    }
}
