using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class Nodo
    {
        private Nodo nodo_padre;
        private string nombre;
        private int nivel;
        private ArrayList hijos = new ArrayList();

        public Nodo(string nombre)
        {
            this.nombre = nombre;
        }

        public Nodo(string nombre, Nodo nodo_padre, int nivel)
        {
            this.nombre = nombre;
            this.nodo_padre = nodo_padre;
            this.nivel = nivel;
        }

        public void agregarHijos(string hijo)
        {
            hijos.Add(hijo);
        }

        public string getNombre()
        {
            return nombre;
        }

        public ArrayList getHijos()
        {
            return hijos;
        }

        public Nodo getPadre()
        {
            return nodo_padre;
        }

        public int getNivel()
        {
            return nivel;
        }

        public void setNivel(int nivel)
        {
            this.nivel = nivel;
        }
    }
}
