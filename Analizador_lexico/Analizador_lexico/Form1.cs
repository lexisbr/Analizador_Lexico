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


namespace Analizador_lexico
{
    public partial class Form1 : Form
    {
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
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        string direccion = saveFileDialog1.FileName;
                        StreamWriter guardar = File.CreateText(direccion);
                        guardar.Write(areaTexto.Text);
                        guardar.Close();
                        MessageBox.Show("Se ha guardado correctamente.");


                    }
                    else
                    {
                        string direccion = saveFileDialog1.FileName;
                        StreamWriter guardar = File.CreateText(direccion);
                        guardar.Write(areaTexto.Text);
                        guardar.Close();
                        MessageBox.Show("Se ha guardado correctamente.");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error");
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
            try
            {
                openFileDialog1.Title = "Busca tu archivo";
                openFileDialog1.ShowDialog();

                if (File.Exists(openFileDialog1.FileName))
                {
                    String direccion = openFileDialog1.FileName;
                    TextReader abrir = new StreamReader(direccion);
                    String texto;
                    texto = abrir.ReadToEnd();
                    areaTexto.Text = texto;
                    abrir.Close();
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error ");
            }
           
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            areaTexto.Clear();
        }
    }
}
