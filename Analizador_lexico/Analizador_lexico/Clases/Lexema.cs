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

        /*Metodo constructor*/
        public Lexema(string lexema, string color, string tipo){
            this.lexema = lexema;
            this.color = color;
            this.tipo = tipo;
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
    }
}
