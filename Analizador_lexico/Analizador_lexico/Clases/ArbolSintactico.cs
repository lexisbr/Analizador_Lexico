using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_lexico.Clases
{

    class ArbolSintactico
    {
        const string GENERAR_ARBOL = "dot.exe -Tjpg -O ";
        ArrayList nodos = new ArrayList();
        ArrayList nodos_ordenados = new ArrayList();
        public ArbolSintactico(ArrayList nodos)
        {
            this.nodos = (ArrayList)nodos.Clone();
        }



        public void ordenarArbol()
        {
            Nodo nodoNuevo;
            for (int i = 0; i < nodos.Count; i++)
            {
                Nodo nodoPadre = (Nodo)nodos[i];
                //System.Windows.Forms.MessageBox.Show("Padre: " + nodoPadre.getNombre());
                for (int j = 0; j < nodoPadre.getHijos().Count; j++)
                {
                   // System.Windows.Forms.MessageBox.Show("Nodo hijo: " + nodoPadre.getHijos()[j]);
                    nodoNuevo = new Nodo(nodoPadre.getHijos()[j].ToString(), nodoPadre.getNombre(),i);
                    nodos_ordenados.Add(nodoNuevo);
                }
            }
        }

        public ArrayList obtenerNodosSinHijos()
        {
            ArrayList nodosSinHijos = new ArrayList();
            for (int i = 0; i < nodos.Count; i++)
            {
                Nodo nodoPadre = (Nodo)nodos[i];
                MessageBox.Show("entra 1"+nodoPadre.getNombre());
                if (nodoPadre.getHijos().Count == 0)
                {
                    MessageBox.Show("entra 2");
                    nodosSinHijos.Add(nodoPadre);
                }
            }
            return nodosSinHijos;
        }

        public void generarDot()
        {
           

            ordenarArbol();
            for (int i = 0; i < obtenerNodosSinHijos().Count; i++)
            {
                Nodo nodosSinHijios = (Nodo)obtenerNodosSinHijos()[i];
                System.Windows.Forms.MessageBox.Show("SIN HIJOS: " + nodosSinHijios.getNombre());
            }
            string codigoDot = "";
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodo = (Nodo)nodos_ordenados[i];
                codigoDot += "\"" + nodo.getPadre()+"_"+nodo.getNivel()+ "\" -> \"" + nodo.getNombre()+"_"+(nodo.getNivel()+1)+ "\";\n";
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
            imagen.Save(@"..\Arboles\prueba1.jpeg", ImageFormat.Jpeg);

        }


    }
}
