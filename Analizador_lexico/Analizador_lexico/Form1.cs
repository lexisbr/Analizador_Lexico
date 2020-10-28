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
        /*Instancio objeto para manejo de archivos*/
        Archivo archivo = new Archivo();
        /*Lista para los tokens generados para automatas*/
        private ArrayList tokens = new ArrayList();

        public static ArrayList simbolos = new ArrayList();
        
        public Form1()
        {
            InitializeComponent();
            lblProyectoActual.Text = "Proyecto actual: "+"SinTitulo";
        
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
            /*Muestra el dialog para abrir archivo*/
            setOpenFile();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String nombre = openFileDialog1.FileName;
                /* Si el texto ha sido modificado pregunta si desea guardar antes abrir otro proyecto*/
                if (archivo.getTextoCambiado()){
                    verificarGuardar();
                    areaTexto.Clear();
                    areaTexto.SelectionColor = Color.Black;
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
            if (archivo.getTextoCambiado())
            {
                verificarGuardar();
            }
            else
            {
                vaciar();
            }
        }

        /*Metodo para guardar archivo como*/
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

        /*Metodo para guardar*/
        public void guardar()
        {
            String texto = areaTexto.Text;
            archivo.guardarArchivo(texto);
            cargarTitulo();
          
        }
         /*Metodo para vaciar richtextbox y borrar direccion actual*/
        public void vaciar()
        {
            areaTexto.Clear();
            areaErrores.Clear();
            lblProyectoActual.Text = "Proyecto actual: " + "SinTitulo";
            archivo.setDireccionActual("");
            archivo.setTextoCambiado(false);
        }

        /*Para openFileDialog y que solo muestre archivos con extension .gt */
        public void setOpenFile()
        {
            openFileDialog1.Filter = "gt files (*.gt)|*.gt";
            openFileDialog1.Title = "Busca tu archivo";
            openFileDialog1.FileName = "";
        }

        /*Para saveFileDialog y que solo guardar con extension .gt*/
        public void setSaveFile()
        {
            saveFileDialog1.Filter = "gt files (*.gt)|*.gt";
            saveFileDialog1.Title = "Guarda tu archivo";
            saveFileDialog1.FileName = "";
        }
        /*Para saveFileDialog y que solo guardar errores con extension .gtE*/
        public void setSaveErrores()
        {
            saveFileDialog1.Filter = "gtE files (*.gtE)|*.gtE";
            saveFileDialog1.Title = "Guarda tu archivo";
            saveFileDialog1.FileName = "";
        }

        /*Carga el titulo del proyecto actual*/
        public void cargarTitulo()
        {
            lblProyectoActual.Text = "Proyecto actual: " + Path.GetFileName(archivo.getDireccionActual());
        }


        /*El titulo cambia cuando ha sido modificado el archivo actual*/
        private void areaTexto_TextChanged(object sender, EventArgs e)
        {
            getColumnaFila();
            areaTexto.SelectionColor = Color.Black;
            if (archivo.getDireccionActual().Equals(""))
            {
                lblProyectoActual.Text = "Proyecto actual: " + "SinTitulo"+"*";            
            }
            else {
                lblProyectoActual.Text = "Proyecto actual: " + Path.GetFileName(archivo.getDireccionActual()) + "*"; 
            }
            archivo.setTextoCambiado(true);

        }

        /*Verifica si el archivo actual ha sido guardado*/
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


        /*Verificar antes de eliminar*/
        public void verificarEliminar()
        {
            if (archivo.getDireccionActual().Equals(""))
            {
                MessageBox.Show("Este proyecto aun no ha sido guardado");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Desea eliminar el archivo actual?", "Advertencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    eliminarArchivo();
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
            
        }

        /*Metodo para eliminar archivo*/
        public void eliminarArchivo()
        {
            try
            {
                File.Delete(archivo.getDireccionActual());
                if (File.Exists(archivo.getDireccionActual()))
                {
                    Console.WriteLine("El archivo sigue existiendo.");
                }
                else
                {
                    MessageBox.Show("Se ha borrado exitosamente");
                    vaciar();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        /*Cuando se presiona compilar*/
        private void button1_Click(object sender, EventArgs e)
        {
            //Instancio objeto de la clase automata
            Automata analizador = new Automata();
            //Se envia el texto a analizar
            analizador.analizadorAutomata(areaTexto.Text);
            //Clono el arraylist generado
            tokens =(ArrayList)analizador.getListaLexema().Clone();
            //Metodo para mostrar tokes
            mostrarTokens();

            //Verifica si existen errores
            if (verificarErrores())
            {
                MessageBox.Show("Compilacion correcta.");
            }
            else
            {
                MessageBox.Show("Error al compilar, revise su codigo.");
            }

            for (int i = 0; i < simbolos.Count; i++)
            {
                Simbolo linea = (Simbolo)simbolos[i];

                MessageBox.Show("Tipo: "+linea.getTipo()+" ID: "+linea.getIdentificador()+" Valor: "+linea.getValor());
            }

        }
        
        /* Muestra y pinta los tokens */
      public void mostrarTokens()
        {
            //Contador de errores
            int contErrores = 1;
            //Se limpia dos areas de texto
            areaTexto.Clear();
            areaErrores.Clear();

            //Analiza el arraylist y clasifica los tokens
            for (int i = 0; i < tokens.Count; i++)
            {
                Lexema lexema = (Lexema)tokens[i];
                //Si es entero lo pinta de morado
                if (lexema.getTipo().Equals("Entero"))
                {
                    areaTexto.SelectionColor = Color.Purple;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es decimal lo pinta de celeste
                else if (lexema.getTipo().Equals("Decimal"))
                {
                    areaTexto.SelectionColor = Color.LightSkyBlue;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es cadena lo pinta de gris
                else if (lexema.getTipo().Equals("Cadena"))
                {
                    areaTexto.SelectionColor = Color.Gray;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es booleano lo pinta de naranja
                else if (lexema.getTipo().Equals("Booleano"))
                {
                    areaTexto.SelectionColor = Color.Orange;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es caracter lo pinta de caracter
                else if (lexema.getTipo().Equals("Caracter"))
                {
                    areaTexto.SelectionColor = Color.Peru;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es un operador lo pinta de azul
                else if (lexema.getTipo().Equals("Operador"))
                {
                    areaTexto.SelectionColor = Color.Blue;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es una asignacion lo pinta de rosado
                else if (lexema.getTipo().Equals("Asignacion"))
                {
                    areaTexto.SelectionColor = Color.DeepPink;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es un comentario lo pinta de roja
                else if (lexema.getTipo().Equals("Comentario"))
                {
                    areaTexto.SelectionColor = Color.Red;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es una palabra reservada lo pinta de verde
                else if (lexema.getTipo().Equals("Reservada"))
                {
                    areaTexto.SelectionColor = Color.DarkGreen;
                    areaTexto.AppendText(lexema.getLexema());
                }
                // Si es un tipo de dato lo pinta de verde
                else if (lexema.getTipo().Equals("Variable"))
                {
                    areaTexto.SelectionColor = Color.DarkGreen;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es in ID lo deja en negro
                else if (lexema.getTipo().Equals("ID")|| lexema.getTipo().Equals("Coma"))
                {
                    areaTexto.SelectionColor = Color.Black;
                    areaTexto.AppendText(lexema.getLexema());
                }
                else if (lexema.getTipo().Equals("Funcionalidad"))
                {
                    areaTexto.SelectionColor = Color.DarkGreen;
                    areaTexto.AppendText(lexema.getLexema());
                }
                //Si es un error pero no es una de las palabras reservadas de los tipos de datos los pinta de amarillo y los agrega a area de errores
                else if (lexema.getTipo().Equals("Error"))
                {
                    //areaTexto.SelectionFont = new Font (areaTexto.SelectionFont, FontStyle.Underline);
                    areaTexto.SelectionColor = Color.Firebrick;
                    areaTexto.AppendText(lexema.getLexema());
                    areaErrores.AppendText(contErrores+") "+lexema.getLexema()+"   >>> Linea:"+lexema.getFila()+" Columna:"+lexema.getColumna()+" <<<");
                    contErrores++;
                    areaErrores.AppendText("\n");
                }
              
                //Inserta enters o espacios
                if (lexema.getTipo().Equals("Enter"))
                {
                    areaTexto.AppendText("\n");
                }
                else
                {
                    areaTexto.AppendText(" ");
                }
                //Regresa a color original
                areaTexto.SelectionColor = Color.Black;
                areaTexto.SelectionFont = new Font(areaTexto.SelectionFont, FontStyle.Regular);




            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (archivo.getTextoCambiado())
            {
                verificarGuardar();
            }
        }

        private void eliminarProyectoActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verificarEliminar();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exportarButton_Click(object sender, EventArgs e)
        {
            exportarArchivo();
        }


        /*Exportar archivo con errores*/
        public void exportarArchivo()
        {
            setSaveErrores();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String proyectoActual = Path.GetFileName(archivo.getDireccionActual());
                String path = saveFileDialog1.FileName;
                String texto = areaErrores.Text;
                archivo.guardarErrorComo(path, texto, proyectoActual);
                cargarTitulo();
            }
        }

        private void areaTexto_MouseClick(object sender, MouseEventArgs e)
        {
            getColumnaFila();
            areaTexto.SelectionColor = Color.Black;
        }


        /*Obtiene la fila y columna actual*/
        public void getColumnaFila()
        {
            int index = areaTexto.SelectionStart;
            int line = areaTexto.GetLineFromCharIndex(index);

            int firstChar = areaTexto.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            lblLinea.Text = Convert.ToString("Linea: " + (line + 1));
            lblColumna.Text = Convert.ToString("Columna: " + column);
        }


        /*Regresa si encuentra errores*/
        public Boolean verificarErrores()
        {
            if (areaErrores.Text.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void areaTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            getColumnaFila();
            areaTexto.SelectionColor = Color.Black;
        }

        private void areaTexto_KeyUp(object sender, KeyEventArgs e)
        {
            getColumnaFila();
            areaTexto.SelectionColor = Color.Black;
        }

        private void areaTexto_KeyDown(object sender, KeyEventArgs e)
        {
            getColumnaFila();
            areaTexto.SelectionColor = Color.Black;
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            areaTexto.SelectionColor = Color.Black;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

