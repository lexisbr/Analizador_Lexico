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
        //Atributo para saber si se ha cambiado el texto
        private Boolean textoCambiado = false;

        public Archivo()
        {
            textoCambiado = false;
            direccionActual = "";
        }

        public String getDireccionActual()
        {
            return direccionActual;
        }
        public void setDireccionActual(String direccionActual)
        {
            this.direccionActual = direccionActual;
        }

        public void setTextoCambiado(Boolean textoCambiado)
        {
            this.textoCambiado = textoCambiado;
        }
        public Boolean getTextoCambiado()
        {
            return textoCambiado;
        }


        /* Metodo para guardar archivo ingresando direccion y nombre*/
        public void guardarArchivoComo(String direccion, String texto)
        {
            try
            {
                setDireccionActual(direccion);
                StreamWriter guardar = File.CreateText(direccion);
                guardar.Write(texto);
                guardar.Close();
                System.Windows.Forms.MessageBox.Show("Archivo guardado exitosamente.");
                setTextoCambiado(false);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }

        }

         /*Metodo para exportar errores*/
        public void guardarErrorComo(String direccion, String texto, String nombreProyecto)
        {
            try
            {
                setDireccionActual(direccion);
                StreamWriter guardar = File.CreateText(direccion);
                guardar.WriteLine("Errores lexicos");
                guardar.WriteLine("Proyecto: "+nombreProyecto);
                guardar.Write(texto);
                guardar.Close();
                System.Windows.Forms.MessageBox.Show("Archivo guardado exitosamente.");
                setTextoCambiado(false);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }

        }

        /* Metodo para guardar archivo en la direccion actual*/
        public void guardarArchivo(String texto)
        {
            TextWriter guardar = new StreamWriter(@getDireccionActual()) ;
            try
            {
                guardar.WriteLine(texto);
                System.Windows.Forms.MessageBox.Show("Se ha guardado correctamente.");
                setTextoCambiado(false);
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
                setDireccionActual(direccion);
                abrir.Close();
                setTextoCambiado(true);
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
