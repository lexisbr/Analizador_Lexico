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
            this.Text = "IDE - Lexees";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (archivo.getdireccionActual().Equals(""))
            {
                guardarComo();
            }
            else
            {
                String texto = areaTexto.Text;
                archivo.guardarArchivo(texto);

            }
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setOpenFile();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String nombre = openFileDialog1.FileName;
                vaciar();
                areaTexto.Text = archivo.abrirArchivo(nombre);
                this.Text = Path.GetFileName(nombre);
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vaciar();
        }


        public void guardarComo()
        {
            setSaveFile();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = saveFileDialog1.FileName;
                String texto = areaTexto.Text;
                archivo.guardarArchivoComo(path, texto);
            }
        }

        public void vaciar()
        {
            areaTexto.Clear();
            archivo.setdireccionActual("");
        }

        public void setOpenFile()
        {
            openFileDialog1.Filter = "gt files (*.gt)|*.gt";
            openFileDialog1.Title = "Busca tu archivo";
            openFileDialog1.FileName = "";
        }

        public void setSaveFile()
        {
            saveFileDialog1.Filter = "gt files (*.gt)|*.gt";
            saveFileDialog1.Title = "Guarda tu archivo";
            saveFileDialog1.FileName = "";
        }

    }
}
