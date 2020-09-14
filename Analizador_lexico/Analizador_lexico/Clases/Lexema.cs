using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class Lexema
    {
        private string lexema;
        private string color;
        private string tipo;

        public Lexema(string lexema, string color, string tipo){
            this.lexema = lexema;
            this.color = color;
            this.tipo = tipo;
        }

       public string getLexema()
        {
            return lexema;
        }

        public string getColor()
        {
            return color;
        }

        public string getTipo()
        {
            return tipo;
        }
    }
}
