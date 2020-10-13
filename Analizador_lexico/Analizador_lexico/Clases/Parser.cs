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
        private ArrayList tokens;

        public Parser(ArrayList tokens)
        {
            this.tokens = (ArrayList)tokens.Clone();
            this.pila = new Stack();
        }

        public void imprimirLista()
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Lexema lexema = (Lexema)tokens[i];
                System.Windows.Forms.MessageBox.Show("Lexema " + lexema.getTipo());
            }
        }

        public void automataPila()
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

        }

    }

}


