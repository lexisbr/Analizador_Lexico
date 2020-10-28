using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico
{
    class Simbolo
    {
        private string tipo;
        private string identificador;
        private string valor;

        public Simbolo(string tipo, string identificador, string valor)
        {
            this.tipo = tipo;
            this.identificador = identificador;
            this.valor = valor;
        }

        public void setValor(string valor)
        {
            this.valor = valor;
        }

        public string getTipo()
        {
            return tipo;
        }
    }
}
