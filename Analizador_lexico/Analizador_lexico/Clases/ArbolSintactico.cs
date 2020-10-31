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
                //System.Windows.Forms.MessageBox.Show("Padre: " + nodoPadre.getNombre());
                for (int j = 0; j < nodoPadre.getHijos().Count; j++)
                {
                    nodoPadre.setNivel(i);
                    //System.Windows.Forms.MessageBox.Show("Nodo hijo: " + nodoPadre.getHijos()[j]);
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
                // Console.WriteLine("Padre: " + nodoNuevo.getPadre().getNombre() + " Nivel: " + nodoNuevo.getPadre().getNivel() + " Obtener nivel: " + obtenerNivel(nodoNuevo.getPadre()) + " || Hijo: " + nodoNuevo.getNombre()+" Nivel: "+nodoNuevo.getNivel());

                int nivel_nuevo = obtenerNivel(nodoNuevo.getPadre());
                if (nivel_nuevo != 0)
                {
                    Console.WriteLine("Nivel nuevo " + nivel_nuevo + " para " + nodoNuevo.getPadre().getNombre() + " nivel anterior " + nodoNuevo.getPadre().getNivel());
                    nodoNuevo.getPadre().setNivel(nivel_nuevo);
                }
            }
        }

        public int obtenerNivel(Nodo nodo)
        {
            for (int i = 0; i < nodos_ordenados.Count; i++)
            {
                Nodo nodo_aux = (Nodo)nodos_ordenados[i];
                // Console.WriteLine("Obteniendo nivel de: " + nodo.getNombre());
                Console.WriteLine("\n=>Padre: " + nodo.getNombre() + " Nivel: " + nodo.getNivel());
                Console.WriteLine("=>Nodo aux: " + nodo_aux.getNombre() + " Nivel: " + nodo_aux.getNivel());
                if (nodo.getNivel() != nodo_aux.getNivel() && nodo.getNombre().Equals(nodo_aux.getNombre()) && !tieneHijos(nodo_aux) && !noEsRaiz(nodo))
                {
                    Console.WriteLine("Entra " + nodo_aux.getNivel());
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
        Console.WriteLine("No tiene hijos");
        return false;
    }

    public Boolean noEsRaiz(Nodo nodo)
    {
        for (int i = 0; i < nodos_ordenados.Count; i++)
        {
            Nodo nodo_aux = (Nodo)nodos_ordenados[i];
            if (nodo.getNombre().Equals(nodo_aux.getNombre()) && nodo.getNivel().Equals(nodo_aux.getNivel()))
            {
                Console.WriteLine("No es raiz");
                return true;
            }

        }
        Console.WriteLine("Es un raiz");
        return false;
    }


    public void generarDot()
    {


        ordenarArbol();
        for (int i = 0; i < nodos.Count; i++)
        {
            Nodo nodosPadre = (Nodo)nodos[i];
            Console.WriteLine("Nodos padre: " + nodosPadre.getNombre());
        }

        for (int i = 0; i < nodos_ordenados.Count; i++)
        {
            Nodo nodosHijo = (Nodo)nodos_ordenados[i];
            Console.WriteLine("Nodo padre: " + nodosHijo.getPadre().getNombre() + " Nivel padre: " + nodosHijo.getPadre().getNivel() + " Nodo hijo: " + nodosHijo.getNombre() + " Nivel hijo: " + nodosHijo.getNivel());
        }


        string codigoDot = "";
        for (int i = 0; i < nodos_ordenados.Count; i++)
        {
            Nodo nodo = (Nodo)nodos_ordenados[i];
            codigoDot += "\"" + nodo.getPadre().getNombre() + "_" + nodo.getPadre().getNivel() + "\" -> \"" + nodo.getNombre() + "_" + nodo.getNivel() + "\";\n";
        }
        Console.WriteLine(codigoDot);
        generarArbol(codigoDot);
    }

    public static void generarArbol(string codigoDot)
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
        Console.WriteLine(graphVizString);
        Bitmap bm = new Bitmap(Graphviz.RenderImage(graphVizString, "jpeg"));
        var imagen = new Bitmap(bm);
        bm.Dispose();
        Image image = (Image)imagen;
        imagen.Save(path + @"\prueba1.jpeg", ImageFormat.Jpeg);

    }


}
}
