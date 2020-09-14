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
        ArrayList tokens;
        int contadorToken = 0;
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
            /*areaErrores.Clear();
            String[] tokens;
            Automata analizador = new Automata();
            analizador.analizadorAutomata(areaTexto.Text);
            tokens = new string[analizador.getTokenValido().Length];
            tokens = analizador.getTokenValido();

            for(int i =0; i<tokens.Length; i++)
            {
                areaErrores.AppendText(tokens[i]);
            }*/

            /* generarTokens(areaTexto.Text);
             mostrarTokens();*/
            Automata analizador = new Automata();
            analizador.analizadorAutomata(areaTexto.Text);
            analizador.mostrarTokens();
            analizador.mostrarErrores();
        }



        private void generarTokens(String texto)
        {
            Boolean comillas = false;
            tokens = new ArrayList();
            texto = texto + " ";
            char caracter;
            string tempToken = "";
            contadorToken = 0;
            try
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    caracter = texto[i];
                    switch (caracter)
                    {
                        case '\r':
                        case '\t':     
                        case '\b':
                        case '\f':
                            if (!tempToken.Equals("")&&!comillas)
                            {
                                guardarTokens(tempToken);
                                tempToken = "";
                            }
                            else
                            {
                                tempToken = tempToken + caracter;
                            }
                          
                            break;
                        case '\n':
                            if (!tempToken.Equals("")&&!comillas)
                            {
                                guardarTokens(tempToken);
                                tempToken = "";
                                guardarTokens("ENTER");
                            }
                            else
                            {
                                tempToken = tempToken + caracter;
                            }
                            break;
                        case ' ':
                            if (!tempToken.Equals("")&&!comillas)
                            {
                                guardarTokens(tempToken);
                                tempToken = "";
                                guardarTokens("ESPACIO");
                            }
                            else
                            {
                                tempToken = tempToken + caracter;
                            }
                            break;
                        case '+':       
                        case '-':
                        case '*':
                        case '<':
                        case '>':
                        case '=':
                        case '(':
                        case ')':
                        case ';':
                        case '!':
                           if (!tempToken.Equals(""))
                            {
                                guardarTokens(tempToken);
                                tempToken = "";
                            }
                            guardarTokens(caracter.ToString());
                            break;
                        case '"':
                            
                            if (!comillas)
                            {
                                if (!tempToken.Equals(""))
                                {
                                    guardarTokens(tempToken);
                                    tempToken = "";
                                }
                                
                                 tempToken = tempToken + caracter;
                                 comillas = true;              
                                
                            }
                            else if(!tempToken.Equals(""))
                            {
                                tempToken = tempToken + caracter;
                                guardarTokens(tempToken);
                                tempToken = "";
                                comillas = false;

                            }
                            
                            break;
                        case '/':

                        default:
                            tempToken = tempToken + caracter;
                            break;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

    private void guardarTokens(String token)
        {
            tokens.Add(token);
           
        }

    private void mostrarTokens()
        {
            foreach(string cadena in tokens)
                MessageBox.Show(cadena);
        }
    
    private void validarTokens(String [] tokens)
        {

        }

    }
}
