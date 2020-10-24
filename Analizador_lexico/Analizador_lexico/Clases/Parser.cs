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
            string peek;
            while (true)
            {
                peek = (string)pila.Peek();
                Console.WriteLine("Token: " + token.getLexema() + " Tipo: " + token.getTipo() + " Peek: " + peek);
                switch (peek)
                {
                    /*Caso para principal*/
                    case "A":
                        {
                            if (token.getLexema().Equals("principal"))
                            {
                                pila.Pop();
                                pila.Push("B");
                                pila.Push("{");
                                pila.Push("principal");
                            }
                            else
                            {
                                pila.Push("B");
                                pila.Push("{");
                                return false;
                            }
                            break;
                        }
                    /*Caso para bloque de codigo*/
                    case "B":
                        {
                            if (token.getTipo().Equals("Variable") || token.getLexema().Equals("SI") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("DESDE") || token.getTipo().Equals("ID") || token.getLexema().Equals("leer") || token.getLexema().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                pila.Push("L");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    /*Caso para lineas de codigo*/
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
                            else if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("Z");
                            }
                            else if (token.getLexema().Equals("}"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    /*Caso para la asignacion de valores a ID*/
                    case "Z":
                        {
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push("J");
                                pila.Push("ID");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    /*Caso para operadores en ID*/
                    case "J":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Z'");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals("++"))
                            {
                                pila.Pop();
                                pila.Push("++");
                            }
                            else if (token.getLexema().Equals("--"))
                            {
                                pila.Pop();
                                pila.Push("--");
                            }
                            else
                            {
                                pila.Pop();
                                return false;
                            }
                            break;
                        }
                    /*Caso para asignar valor a ID*/
                    case "Z'":
                        {
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("O");
                            }
                            else if (token.getTipo().Equals("Booleano") || token.getTipo().Equals("Caracter"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                            }
                            else if (token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    /*Caso para realizar operaciones matematicas*/
                    case "O":
                        {
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("ID");
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("Entero");
                            }
                            else if (token.getTipo().Equals("Decimal"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("Decimal");
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push(")");
                                pila.Push("O");
                                pila.Push("(");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("N");
                                return false;
                            }
                            break;
                        }
                    case "N":
                        {
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("+");
                            }
                            else if (token.getLexema().Equals("-"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("-");
                            }
                            else if (token.getLexema().Equals("*"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("*");
                            }
                            else if (token.getLexema().Equals("/"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("/");
                            }
                            else if (token.getLexema().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else if (token.getTipo().Equals("Entero")||token.getTipo().Equals("Decimal"))
                            {
                                pila.Pop();
                                pila.Push("O");
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("O");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("O");
                                return false;
                            }
                            break;
                        }
                    case "O'":
                        {
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("N'");
                                pila.Push("+");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "N'":
                        {
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("ID");
                            }
                            else if (token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("O'");
                                return false;
                            }
                            break;
                        }
                    case "D":
                        {
                            if (token.getTipo().Equals("Variable"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push("D'");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "D'":
                        {
                            if (token.getLexema().Equals("decimal"))
                            {
                                pila.Pop();
                                pila.Push("P");
                                pila.Push("ID");
                                pila.Push("decimal");
                            }
                            else if (token.getLexema().Equals("entero"))
                            {
                                pila.Pop();
                                pila.Push("Q");
                                pila.Push("ID");
                                pila.Push("entero");
                            }
                            else if (token.getLexema().Equals("booleano"))
                            {
                                pila.Pop();
                                pila.Push("R");
                                pila.Push("ID");
                                pila.Push("booleano");
                            }
                            else if (token.getLexema().Equals("cadena"))
                            {
                                pila.Pop();
                                pila.Push("S");
                                pila.Push("ID");
                                pila.Push("cadena");
                            }
                            else if (token.getLexema().Equals("caracter"))
                            {
                                pila.Pop();
                                pila.Push("T");
                                pila.Push("ID");
                                pila.Push("caracter");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "P":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "Q":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "Q'":
                        {
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("+");
                            }
                            else if (token.getLexema().Equals("-"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("-");
                            }
                            else if (token.getLexema().Equals("*"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("*");
                            }
                            else if (token.getLexema().Equals("/"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("/");
                            }
                            else if (token.getLexema().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                return false;
                            }
                            break;
                        }
                    case "Q''":
                        {
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push("ID");
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push("Entero");
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push(")");
                                pila.Push("Q''");
                                pila.Push("(");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                return false;
                            }
                            break;
                        }
                    case "R":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Booleano");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "S":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "T":
                        {
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Caracter");
                                pila.Push("=");
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "I":
                        {
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("I'");
                                pila.Push("ID");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "I'":
                        {
                            if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "G":
                        {
                            if (token.getLexema().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("C");
                                pila.Push("(");
                                pila.Push("imprimir");
                            }
                            else if (token.getLexema().Equals("leer"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push(")");
                                pila.Push("ID");
                                pila.Push("(");
                                pila.Push("leer");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "C":
                        {
                            if (token.getTipo().Equals("ID")|| token.getTipo().Equals("Entero")|| token.getTipo().Equals("Decimal")|| token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push(")");
                                pila.Push("M");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "M":
                        {
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("M'");
                                pila.Push(token.getTipo());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "M'":
                        {
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("M");
                                pila.Push("+");
                            }
                            else if (token.getLexema().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "F":
                        {
                            if (token.getLexema().Equals("SI"))
                            {
                                pila.Pop();
                                pila.Push("E'");
                                pila.Push("E");
                                pila.Push("S'");
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("SI");
                            }
                            else if (token.getLexema().Equals("MIENTRAS"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("MIENTRAS");
                            }
                            else if(token.getLexema().Equals("HACER"))
                            {
                                pila.Pop();
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("MIENTRAS");
                                pila.Push("S'");
                                pila.Push("HACER");
                            }
                            else if (token.getLexema().Equals("DESDE"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                pila.Push("Entero");
                                pila.Push("INCREMENTO");
                                pila.Push("Entero");
                                pila.Push("S''");
                                pila.Push("ID");
                                pila.Push("HASTA");
                                pila.Push("Entero");
                                pila.Push("=");
                                pila.Push("ID");
                                pila.Push("DESDE");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "V":
                        {
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push("V'");
                                pila.Push("X");
                                pila.Push("V'");
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("Q'''");
                                pila.Push(")");
                                pila.Push("V'");
                                pila.Push("X");
                                pila.Push("V'");
                                pila.Push("(");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "V'":
                        {
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "X":
                        {
                            if (token.getLexema().Equals(">")|| token.getLexema().Equals("<")|| token.getLexema().Equals("==")|| token.getLexema().Equals("<=")|| token.getLexema().Equals(">=")|| token.getLexema().Equals("!="))
                            {
                                pila.Pop();
                                pila.Push(token.getLexema());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "Q'''":
                        {
                            if (token.getLexema().Equals("&&") || token.getLexema().Equals("||"))
                            {
                                pila.Pop();
                                pila.Push("V");
                                pila.Push(token.getLexema());
                            }
                            else if (token.getLexema().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "S'":
                        {
                            if (token.getLexema().Equals("{"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                pila.Push("L");
                                pila.Push("{");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "S''":
                        {
                            if (token.getLexema().Equals("=") || token.getLexema().Equals(">") || token.getLexema().Equals("<") || token.getLexema().Equals("<=") || token.getLexema().Equals(">="))
                            {
                                pila.Pop();
                                pila.Push(token.getLexema());
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "E":
                        {
                            if (token.getTipo().Equals("Variable") || token.getTipo().Equals("Funcionalidad") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("SI") || token.getLexema().Equals("SINO") || token.getLexema().Equals("DESDE") || token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals("SINO_SI"))
                            {
                                pila.Pop();
                                pila.Push("E");
                                pila.Push("S'");
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("SINO_SI");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "E'":
                        {
                            if (token.getTipo().Equals("Variable") || token.getTipo().Equals("Funcionalidad") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("SI") || token.getLexema().Equals("DESDE") || token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals("SINO"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                pila.Push("SINO");
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "WC":
                        {
                            if (token.getLexema().Equals("+"))
                            {

                            }
                            break;
                        }
                    default:
                        {
                            if (peek.Equals(token.getLexema()) || peek.Equals(token.getTipo()))
                            {
                                Console.WriteLine("Sale>>> " + peek + "\n");
                                pila.Pop();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }


                }
            }
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


