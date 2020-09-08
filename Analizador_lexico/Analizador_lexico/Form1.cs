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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            TextWriter guardar = new StreamWriter(@"C:\Users\jalej\Documents\C# Projects\Analizador Lexico\Archivos\prueba.txt",true);
            try
            {
                guardar.WriteLine("Archivo de prueba");
                guardar.WriteLine(areaTexto.Text);
                MessageBox.Show("Se ha guardado correctamente.");
            }
            catch
            {
                MessageBox.Show("Error");
            }
            guardar.Close();


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader abrir = new StreamReader(@"C:\Users\jalej\Documents\C# Projects\Analizador Lexico\Archivos\prueba.txt");
            String linea;
            try
            {
                linea = abrir.ReadLine();
                while (linea!=null)
                {
                    areaTexto.AppendText(linea+"\n");
                    linea = abrir.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            abrir.Close();
        }
    }
}
