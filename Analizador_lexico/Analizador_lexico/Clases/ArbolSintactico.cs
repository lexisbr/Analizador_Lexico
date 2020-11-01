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
                for (int j = 0; j < nodoPadre.getHijos().Count; j++)
                {
                    nodoPadre.setNivel(i);
                    nodoNuevo = new Nodo(nodoPadre.getHijos()[j].ToString(), nodoPadre, (i + 1));
                    nodos_ordenados.Add(nodoNuevo);
                }
            }
            arreglarNiveles();
        }

        public void arreglarNiveles()
        {
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodoNuevo = (Nodo)nodos_ordenados[i];
                int nivel_nuevo = obtenerNivel(nodoNuevo.getPadre());
                if (nivel_nuevo != 0)
                {
                    nodoNuevo.getPadre().setNivel(nivel_nuevo);
                }
            }
        }

        public int obtenerNivel(Nodo nodo)
        {
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodo_aux = (Nodo)nodos_ordenados[i];
                if (nodo.getNivel() != nodo_aux.getNivel() && nodo.getNombre().Equals(nodo_aux.getNombre()) && !tieneHijos(nodo_aux) && !noEsRaiz(nodo))
                {
                    return nodo_aux.getNivel();
                }
            }
            return 0;
        }

        public Boolean tieneHijos(Nodo nodo)
        {
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodo_aux = (Nodo)nodos_ordenados[i];
                if (nodo.getNombre().Equals(nodo_aux.getPadre().getNombre()) && nodo.getNivel().Equals(nodo_aux.getPadre().getNivel()))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean noEsRaiz(Nodo nodo)
        {
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodo_aux = (Nodo)nodos_ordenados[i];
                if (nodo.getNombre().Equals(nodo_aux.getNombre()) && nodo.getNivel().Equals(nodo_aux.getNivel()))
                {
                    return true;
                }
            }
            return false;
        }

        public void generarDot()
        {
            try
            {
                ordenarArbol();
                string codigoDot = "";
                for (int i = 0; i < nodos_ordenados.Count; i++)
                {
                    Nodo nodo = (Nodo)nodos_ordenados[i];
                    codigoDot += "\"" + nodo.getPadre().getNombre() + "_" + nodo.getPadre().getNivel() + "\" " +
                        "-> \"" + nodo.getNombre() + "_" + nodo.getNivel() + "\";\n";
                }
                generarArbol(codigoDot);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al generar dot");
            }
            
        }

        public void generarArbol(string codigoDot)
        {
            try
            {
                string path = @"..\..\Arboles";
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
                Bitmap bm = new Bitmap(Graphviz.RenderImage(graphVizString, "jpeg"));
                var imagen = new Bitmap(bm);
                bm.Dispose();
                Image image = (Image)imagen;
                imagen.Save(path + @"\tempArbol.jpeg", ImageFormat.Jpeg);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al generar arbol");
            }
           
        }
    }
}
