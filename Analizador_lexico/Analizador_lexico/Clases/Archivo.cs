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
        //Atributo de la direccion actual del archivo
        private String direccionActual = "";

        public Archivo()
        {
           
        }

        public String getdireccionActual()
        {
            return direccionActual;
        }
        public void setdireccionActual(String direccionActual)
        {
            this.direccionActual = direccionActual;
        }


        /* Metodo para guardar archivo ingresando direccion y nombre*/
        public void guardarArchivoComo(String direccion, String texto)
        {
            try
            {
                setdireccionActual(direccion);
                StreamWriter guardar = File.CreateText(direccion+".gt");
                guardar.Write(texto);
                guardar.Close();
                System.Windows.Forms.MessageBox.Show("Archivo guardado exitosamente.");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }

        }

        /* Metodo para guardar archivo en la direccion actual*/
        public void guardarArchivo(String texto)
        {
            TextWriter guardar = new StreamWriter(@getdireccionActual()) ;
            try
            {
                guardar.WriteLine(texto);
                System.Windows.Forms.MessageBox.Show("Se ha guardado correctamente.");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
            guardar.Close();

        }

        /* Metodo para abrir un archivo */
        public String abrirArchivo(String direccion)
        {
            String texto;
            try
            {
                TextReader abrir = new StreamReader(direccion);
                texto = abrir.ReadToEnd();
                setdireccionActual(direccion);
                abrir.Close();
                return texto;
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show("Error ");
                return "";
            }
        }

        public void nuevoArchivo()
        {

        }

    }
}
