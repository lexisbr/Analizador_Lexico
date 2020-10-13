using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class Lexema
    {

        //Atributo de texto de token
        private string lexema;
        //Color del token
        private string color;
        //Tipo de token
        private string tipo;
        //Atributo para columna
        private int columna;
        //Atributo para fila
        private int fila;

        /*Metodo constructor*/
        public Lexema(string lexema, string color, string tipo){
            this.lexema = lexema;
            this.color = color;
            this.tipo = tipo;
        }

        /*Metodo constructor*/
        public Lexema(string lexema, string color, string tipo, int fila, int columna)
        {
            this.lexema = lexema;
            this.color = color;
            this.tipo = tipo;
            this.columna = columna;
            this.fila = fila;
        }


        /*Regresa el lexema*/
        public string getLexema()
        {
            return lexema;
        }

        /*Regresa el color*/
        public string getColor()
        {
            return color;
        }

        /*Regresa el tipo*/
        public string getTipo()
        {
            return tipo;
        }

        /*Regresa la fila*/
        public int getFila()
        {
            return fila;
        }

        /*Regresa la columna*/
        public int getColumna()
        {
            return columna;
        }
    }
}
