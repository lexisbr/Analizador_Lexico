using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{

    class ArbolSintactico
    {
        const string GENERAR_ARBOL = "dot.exe -Tjpg -O ";

        private string path;

        public ArbolSintactico(string path)
        {
            this.path = path;
        }

        public static void generarArbol()
        {
            string path1 = @"C:\Users\jalej\Documents\C# Projects\Analizador Lexico\Analizador_lexico\Analizador_lexico";
            String inicia = "digraph G{";
            string contenido1 = "1 -> 2;";
            string contenido2 = "2 -> 3;";
            string contenido3 = "2 -> 4;";
            String final = "}";
            string graphVizString = inicia + contenido1 + contenido2 + contenido3+ final;
            Bitmap bm = new Bitmap(Graphviz.RenderImage(graphVizString, "jpg"));
            var imagen = new Bitmap(bm);
            bm.Dispose();
            Image image = (Image)imagen;
            imagen.Save(path1+@"\prueba.jpeg",ImageFormat.Jpeg);
           


            //Path de la carpeta
            /*string path = @"..\Arboles";
            //Path del archivo
            string path2 = path + @"\Ejemplo.txt";
            //Crear carpeta
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            //Crear archivo
            if (!File.Exists(path2))
            {
                //Crea el archivo
                using (StreamWriter sw = File.CreateText(path2))
                {
                    sw.Close();
                }
                //Le agrega texto al archivo
                using (StreamWriter sw = File.AppendText(path2))
                {
                    sw.WriteLine("Hola mundo");
                    sw.Close();
                }
            }
            using (StreamWriter sw = File.AppendText(path2))
            {
                sw.WriteLine("Hola mundo");
                sw.Close();
            }*/

        }

        static void ExecuteCommand()
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + GENERAR_ARBOL);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
    }
}
