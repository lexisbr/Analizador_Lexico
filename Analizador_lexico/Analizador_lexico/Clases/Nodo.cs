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
        private string nodo_padre;
        private string nombre;
        private ArrayList hijos = new ArrayList();

        public Nodo(string nombre)
        {
            this.nombre = nombre;
        }


        public Nodo(string nombre, string nodo_padre)
        {
            this.nombre = nombre;
            this.nodo_padre = nodo_padre;
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

        public string getPadre()
        {
            return nodo_padre;
        }
    }
}
