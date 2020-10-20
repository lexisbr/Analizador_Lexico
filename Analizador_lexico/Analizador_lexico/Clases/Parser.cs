using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_lexico.Clases
{
    class Parser
    {
        private Stack pila;

        public Parser()
        {
            this.pila = new Stack();
            this.pila.Push("A");
        }


        public Boolean analizador(Lexema token)
        {
            string peek = (string)pila.Peek();

            switch (peek)
            {
                case "A":
                    {
                        if (token.getLexema().Equals("principal"))
                        {
                            pila.Pop();
                            pila.Push("B");
                            pila.Push("{");
                            pila.Push("principal");
                            return true;
                        }
                        break;
                    }
                case "B":
                    {
                        if (token.getTipo().Equals("Variable") || token.getLexema().Equals("SI") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER")|| token.getLexema().Equals("DESDE")||token.getLexema().Equals("ID") || token.getLexema().Equals("leer") || token.getLexema().Equals("imprimir"))
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                            return true;
                        }
                        break;
                    }
                case "L":
                    {
                        if (token.getTipo().Equals("Variable"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("D");
                        }
                        else if (token.getTipo().Equals("Funcionalidad"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("G");
                        }
                        else if (token.getLexema().Equals("SI") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("DESDE"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("F");
                        }
                        break;
                    }


            }
            return false;
        }








      /*  public void automataPila()
        {
            pila.Push("E");
            for (int i = 0; i < tokens.Count; i++)
            {
                Lexema lexema = (Lexema)tokens[i];
                string peek = (string)pila.Peek();
                MessageBox.Show(lexema.getLexema() + "<TIPO  PEEK>" + peek);

                switch (peek)
                {
                    case "$":

                        break;
                    case "E":
                        switch (lexema.getTipo())
                        {
                            case "Variable":
                                {
                                    pila.Pop();
                                    pila.Push(";");
                                    pila.Push("I");
                                    pila.Push("E'");
                                    i--;
                                    break;
                                }
                        }
                        break;
                    case "E'":
                        switch (lexema.getTipo())
                        {
                            case "Variable":
                                {
                                    pila.Pop();
                                    pila.Push("Variable");
                                    i--;
                                    break;
                                }
                        }
                        break;
                    case "I":
                       
                        if (lexema.getTipo().Equals("ID")|| lexema.getLexema().Equals(",")|| lexema.getLexema().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("I'");
                            pila.Push("ID");
                            i--;
                        }else if (lexema.getTipo().Equals(";"))
                        {
                            pila.Pop();
                            pila.Pop();
                        }
                        break;
                    case "I'":
                        if (lexema.getLexema().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("=");
                            i--;
                        }
                        else if (lexema.getLexema().Equals(";"))
                        {
                            pila.Pop();
                            pila.Pop();
                        }
                        else if (lexema.getLexema().Equals(","))
                        {
                            pila.Pop();
                            pila.Push(",");
                            pila.Push("I");
                            i--;
                        }
                        break;
                    case "L":
                        switch (lexema.getTipo())
                        {
                            case "Cadena":
                                {
                                    pila.Pop();
                                    pila.Push("Cadena");
                                    i--;
                                    break;
                                }

                        }
                        break;
                    default:
                        if (peek.Equals(lexema.getTipo()))
                        {
                            pila.Pop();
                        }
                        else if (peek.Equals(lexema.getLexema()))
                        {
                            pila.Pop();
                        }
                        break;
                }
            }

            if (pila.Count == 0)
            {
                MessageBox.Show("Cadena aceptada");
            }
            else
            {
                MessageBox.Show("Cadena rechazada");
            }

        }*/

    }

}


