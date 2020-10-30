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
        private string nombre;
        private ArrayList hijos = new ArrayList();

        public Nodo(string nombre)
        {
            this.nombre = nombre;
        }

        public void agregarHijos(Nodo hijo)
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
    }
}
