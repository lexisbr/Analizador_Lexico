using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Analizador_lexico.Clases;

namespace Analizador_lexico
{
    public partial class Form1 : Form
    {

        Archivo archivo = new Archivo();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = saveFileDialog1.FileName;
                String texto = areaTexto.Text;
                archivo.guardarArchivoComo(path, texto);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
          
          


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
           openFileDialog1.Title = "Busca tu archivo";
           openFileDialog1.ShowDialog();
           String nombre = openFileDialog1.FileName; 
           areaTexto.Text = archivo.abrirArchivo(nombre);
            archivo.setdireccionActual(nombre);
            
           
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            areaTexto.Clear();
            archivo.setdireccionActual("");
        }
    }
}
