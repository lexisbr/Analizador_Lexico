using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class ArbolSintactico
    {
         public static void generarArbol()
        {
            String inicia = "digraph G{";
            string contenido1 = "one -> two;";
            string contenido2 = "two -> tree;";
            String final = "}";

            string graphVizString = inicia + contenido1 + contenido2 + final;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Bitmap bm = new Bitmap(Graphviz.RenderImage(graphVizString, "jpg"));

            bm.Save(path);

        }
    }
}
