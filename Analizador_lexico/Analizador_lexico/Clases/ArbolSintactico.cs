using System;
using System.Collections;
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
        ArrayList nodos = new ArrayList();

        public ArbolSintactico(ArrayList nodos)
        {
            this.nodos = (ArrayList)nodos.Clone();
        }


        public void generarDot()
        {
            int nivel = 0;
            string codigoDot="";
            for (int i = 0; i < nodos.Count; i++)
            {
                Nodo nodo = (Nodo)nodos[i];
                for (int j = 0; j < nodo.getHijos().Count; j++)
                {
                    Nodo hijo = (Nodo)nodo.getHijos()[j];


                    codigoDot += "\"" + nodo.getNombre() + "_" + nivel + "\" -> \"" + nodo.getHijos()[j] + "_" + (nivel + 1) + "\";\n";
                }
                nivel++;
            }
            Console.WriteLine(codigoDot);
            generarArbol(codigoDot);
        }

        public static void generarArbol(string codigoDot)
        {
            string path = @"..\Arboles";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            String inicia = "digraph G {\n";
            string contenido1 = "{\n" +
               "node[shape=box, width=2];\n";
            string contenido2 = codigoDot;
            String final = "}\n" +
                "}";
            string graphVizString = inicia + contenido1 + contenido2 + final;
            Console.WriteLine(graphVizString);
            Bitmap bm = new Bitmap(Graphviz.RenderImage(graphVizString, "jpeg"));
            var imagen = new Bitmap(bm);
            bm.Dispose();
            Image image = (Image)imagen;
            imagen.Save(@"..\Arboles\prueba1.jpeg",ImageFormat.Jpeg);

        }

        
    }
}
