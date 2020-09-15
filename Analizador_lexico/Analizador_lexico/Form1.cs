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
using System.Collections;

namespace Analizador_lexico
{
    public partial class Form1 : Form
    {

        Archivo archivo = new Archivo();
        ArrayList tokens = new ArrayList();
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Proyecto actual: "+"SinTitulo";
        
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
            if (archivo.getDireccionActual().Equals(""))
            {
                guardarComo();
            }
            else
            {
                guardar();
            }
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setOpenFile();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String nombre = openFileDialog1.FileName;
                if (archivo.getTextoCambiado()){
                    verificarGuardar();
                    areaTexto.Text = archivo.abrirArchivo(nombre);
                    cargarTitulo();
                }
                else
                {
                    areaTexto.Text = archivo.abrirArchivo(nombre);
                    cargarTitulo();
                }
               
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(archivo.getTextoCambiado());

            if (archivo.getTextoCambiado())
            {
                verificarGuardar();
            }
            else
            {
                vaciar();
            }
        }


        public void guardarComo()
        {
            setSaveFile();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = saveFileDialog1.FileName;
                String texto = areaTexto.Text;
                archivo.guardarArchivoComo(path, texto);
                cargarTitulo();
            }
        }

        public void guardar()
        {
            String texto = areaTexto.Text;
            archivo.guardarArchivo(texto);
            cargarTitulo();
          
        }

        public void vaciar()
        {
            areaTexto.Clear();
            label1.Text = "Proyecto actual: " + "SinTitulo";
            archivo.setDireccionActual("");
            archivo.setTextoCambiado(false);
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

        public void cargarTitulo()
        {
            label1.Text = "Proyecto actual: " + Path.GetFileName(archivo.getDireccionActual());
        }

        private void areaTexto_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(archivo.getTextoCambiado());
            if (archivo.getDireccionActual().Equals(""))
            {
                label1.Text = "Proyecto actual: " + "SinTitulo"+"*";            
            }
            else {
                label1.Text = "Proyecto actual: " + Path.GetFileName(archivo.getDireccionActual()) + "*"; 
            }
            archivo.setTextoCambiado(true);

        }

        public void verificarGuardar()
        {
            DialogResult dialogResult = MessageBox.Show("Desea guardar el archivo actual?", "Advertencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (archivo.getDireccionActual().Equals(""))
                {
                    guardarComo();
                }
                else
                {
                    guardar();
                }
                vaciar();
            }
            else if (dialogResult == DialogResult.No)
            {
                vaciar();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automata analizador = new Automata();
            analizador.analizadorAutomata(areaTexto.Text);
            analizador.mostrarTokens();

            tokens =(ArrayList)analizador.getListaLexema().Clone();
           

        }
        
      /* public void mostrarTokens()
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Lexema lexema = (Lexema)tokens[i];
                if (tokens[i].Equals("ESPACIO"))
                {
                    areaTexto.SelectionColor = Color.Red;
                    areaTexto.AppendText(" ");
                }
                else if (tokens[i].Equals("ENTER"))
                {
                    areaTexto.SelectionColor = Color.Red;
                    areaTexto.AppendText(Environment.NewLine + "");
                }
                else
                {
                    areaTexto.SelectionColor = Color.Red;
                    areaTexto.AppendText(tokens[i]);
                }
                MessageBox.Show(i + ") " + lexema.getLexema() + " " + lexema.getTipo());
            }
        }*/
    }
}
