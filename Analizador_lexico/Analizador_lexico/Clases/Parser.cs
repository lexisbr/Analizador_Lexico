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
        private string[] lineaTabla = new string[3];
        Simbolo simbolo;
        int control = 0;
        Nodo nodo;
        ArrayList nodos = new ArrayList();

        public Parser()
        {
            this.pila = new Stack();
            this.pila.Push("A");
           
        }


        public Boolean analizador(Lexema token)
        {
            string peek;
            while (pila.Count != 0)
            {
                peek = (string)pila.Peek();
                Console.WriteLine("Token: " + token.getLexema() + " Tipo: " + token.getTipo() + " Peek: " + peek);
                switch (peek)
                {
                    /*Caso para principal*/
                    case "A":
                        {
                            nodo = new Nodo("A");
                            if (token.getLexema().Equals("principal"))
                            {
                                pila.Pop();
                                pila.Push("B");
                                pila.Push("{");
                                pila.Push("principal");
                                nodo.agregarHijos(new Nodo("principal"));
                                nodo.agregarHijos("{");
                                nodo.agregarHijos("B");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("B");
                                pila.Push("{");
                                return false;
                            }
                            break;
                        }
                    /*Caso para bloque de codigo*/
                    case "B":
                        {
                            nodo = new Nodo("B");
                            if (token.getTipo().Equals("Variable") || token.getLexema().Equals("SI") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("DESDE") || token.getTipo().Equals("ID") || token.getLexema().Equals("leer") || token.getLexema().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                pila.Push("L");
                                nodo.agregarHijos("L");
                                nodo.agregarHijos("}");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("}");
                                pila.Push("L");
                                return false;
                            }
                            break;
                        }
                    /*Caso para lineas de codigo*/
                    case "L":
                        {
                            nodo = new Nodo("L");
                            if (token.getTipo().Equals("Variable"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("D");
                                nodo.agregarHijos("D");
                                nodo.agregarHijos("L");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Funcionalidad"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("G");
                                nodo.agregarHijos("G");
                                nodo.agregarHijos("L");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("SI") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("DESDE"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("F");
                                nodo.agregarHijos("F");
                                nodo.agregarHijos("L");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("Z");
                                nodo.agregarHijos("Z");
                                nodo.agregarHijos("L");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("}") && control==0)
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals("}") && control != 0)
                            {
                                pila.Pop();
                                pila.Push("L");
                                pila.Push("}");
                                control--;
                            }
                            else
                            {
                                if (token.getLexema().Equals("{"))
                                {
                                    pila.Push("}");
                                    pila.Push("L");
                                    pila.Push("{");
                                }
                                else
                                {
                                    pila.Pop();
                                    pila.Push("L");
                                    return false;
                                }
                            }
                            break;
                        }
                    /*Caso para la asignacion de valores a ID*/
                    case "Z":
                        {
                            nodo = new Nodo("Z");
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push("J");
                                pila.Push("ID");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("J");
                                nodo.agregarHijos(";");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("J");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Z'");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Z'");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("++"))
                            {
                                pila.Pop();
                                pila.Push("++");
                                nodo.agregarHijos("++");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("--"))
                            {
                                pila.Pop();
                                pila.Push("--");
                                nodo.agregarHijos("--");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("Z'");
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Booleano") || token.getTipo().Equals("Caracter"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                                nodo.agregarHijos(token.getTipo());
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                                nodo.agregarHijos("Cadena");
                                nodo.agregarHijos("O'");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("O");
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("ID");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("N");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("Entero");
                                nodo.agregarHijos("Entero");
                                nodo.agregarHijos("N");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Decimal"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push("Decimal");
                                nodo.agregarHijos("Decimal");
                                nodo.agregarHijos("N");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("N");
                                pila.Push(")");
                                pila.Push("O");
                                pila.Push("(");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("O");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("N");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("N");
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("+");
                                nodo.agregarHijos("+");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("-"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("-");
                                nodo.agregarHijos("-");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("*"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("*");
                                nodo.agregarHijos("*");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("/"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("/");
                                nodo.agregarHijos("/");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("O'");
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("N'");
                                pila.Push("+");
                                nodo.agregarHijos("+");
                                nodo.agregarHijos("N'");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("N'");
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("ID");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("O'");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                                nodo.agregarHijos("Cadena");
                                nodo.agregarHijos("O'");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("D");
                            if (token.getTipo().Equals("Variable"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push("D'");
                                nodo.agregarHijos("D'");
                                nodo.agregarHijos(";");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "D'":
                        {
                            nodo = new Nodo("D'");
                            if (token.getLexema().Equals("decimal"))
                            {
                                pila.Pop();
                                pila.Push("P");
                                pila.Push("ID");
                                pila.Push("decimal");
                                nodo.agregarHijos("decimal");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("P");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("entero"))
                            {
                                pila.Pop();
                                pila.Push("Q");
                                pila.Push("ID");
                                pila.Push("entero");
                                nodo.agregarHijos("entero");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("Q");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("booleano"))
                            {
                                pila.Pop();
                                pila.Push("R");
                                pila.Push("ID");
                                pila.Push("booleano");
                                nodo.agregarHijos("booleano");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("R");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("cadena"))
                            {
                                pila.Pop();
                                pila.Push("S");
                                pila.Push("ID");
                                pila.Push("cadena");
                                nodo.agregarHijos("cadena");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("S");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("caracter"))
                            {
                                pila.Pop();
                                pila.Push("T");
                                pila.Push("ID");
                                pila.Push("caracter");
                                nodo.agregarHijos("caracter");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("T");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "P":
                        {
                            nodo = new Nodo("P");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("O");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos(",");
                                nodo.agregarHijos("I");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("Q");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Q''");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos(",");
                                nodo.agregarHijos("I");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("Q'");
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("+");
                                nodo.agregarHijos("Q''");
                                nodo.agregarHijos("+");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("-"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("-");
                                nodo.agregarHijos("Q''");
                                nodo.agregarHijos("-");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("*"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("*");
                                nodo.agregarHijos("Q''");
                                nodo.agregarHijos("*");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("/"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                pila.Push("/");
                                nodo.agregarHijos("Q''");
                                nodo.agregarHijos("/");
                                nodos.Add(nodo);
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
                                nodo.agregarHijos("Q''");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                nodo.agregarHijos("Q''");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("Q''");
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push("ID");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("Q'");
                                nodos.Add(nodo);
                            }
                            else if (token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push("Entero");
                                nodo.agregarHijos("Entero");
                                nodo.agregarHijos("Q'");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                pila.Push(")");
                                pila.Push("Q''");
                                pila.Push("(");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("Q''");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("Q'");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("R");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Booleano");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Booleano");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos(",");
                                nodo.agregarHijos("I");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("S");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                pila.Push("Cadena");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Cadena");
                                nodo.agregarHijos("O'");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos(",");
                                nodo.agregarHijos("I");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("T");
                            if (token.getLexema().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Caracter");
                                pila.Push("=");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Caracter");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos(",");
                                nodo.agregarHijos("I");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("I");
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("I'");
                                pila.Push("ID");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("I'");
                                nodos.Add(nodo);

                            }
                            else if (token.getLexema().Equals(";"))
                            {
                                pila.Pop();
                                pila.Push("I'");
                                nodo.agregarHijos("I'");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("I'");
                                return false;
                            }
                            break;
                        }
                    case "I'":
                        {
                            nodo = new Nodo("I'");
                            if (token.getLexema().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                pila.Push(",");
                                nodo.agregarHijos("I");
                                nodo.agregarHijos(",");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("G");
                            if (token.getLexema().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("C");
                                pila.Push("(");
                                pila.Push("imprimir");
                                nodo.agregarHijos("imprimir");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("C");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("leer"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push(")");
                                pila.Push("ID");
                                pila.Push("(");
                                pila.Push("leer");
                                nodo.agregarHijos("leer");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos(";");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "C":
                        {
                            nodo = new Nodo("C");
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                pila.Push(")");
                                pila.Push("M");
                                nodo.agregarHijos("M");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos(";");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "M":
                        {
                            nodo = new Nodo("M");
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("M'");
                                pila.Push(token.getTipo());
                                nodo.agregarHijos(token.getTipo());
                                nodo.agregarHijos("M'");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("M'");
                                return false;
                            }
                            break;
                        }
                    case "M'":
                        {
                            nodo = new Nodo("M'");
                            if (token.getLexema().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("M");
                                pila.Push("+");
                                nodo.agregarHijos("+");
                                nodo.agregarHijos("M");
                                nodos.Add(nodo);
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
                    /*Estado para ciclos y condicional*/
                    case "F":
                        {
                            nodo = new Nodo("F");
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
                                nodo.agregarHijos("SI");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("V");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("S'");
                                nodo.agregarHijos("E");
                                nodo.agregarHijos("E'");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("MIENTRAS"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("MIENTRAS");
                                nodo.agregarHijos("MIENTRAS");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("V");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("S'");
                                nodos.Add(nodo);
                            }
                            else if (token.getLexema().Equals("HACER"))
                            {
                                pila.Pop();
                                pila.Push(")");
                                pila.Push("V");
                                pila.Push("(");
                                pila.Push("MIENTRAS");
                                pila.Push("S'");
                                pila.Push("HACER");
                                nodo.agregarHijos("HACER");
                                nodo.agregarHijos("S'");
                                nodo.agregarHijos("MIENTRAS");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("V");
                                nodo.agregarHijos(")");
                                nodos.Add(nodo);
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
                                nodo.agregarHijos("DESDE");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("=");
                                nodo.agregarHijos("Entero");
                                nodo.agregarHijos("HASTA");
                                nodo.agregarHijos("ID");
                                nodo.agregarHijos("S''");
                                nodo.agregarHijos("Entero");
                                nodo.agregarHijos("INCREMENTO");
                                nodo.agregarHijos("Entero");
                                nodo.agregarHijos("S'");
                                nodos.Add(nodo);

                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "V":
                        {
                            nodo = new Nodo("V");
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push("V'");
                                pila.Push("X");
                                pila.Push("V'");
                                nodo.agregarHijos("V'");
                                nodo.agregarHijos("X");
                                nodo.agregarHijos("V'");
                                nodos.Add(nodo);
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
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("V'");
                                nodo.agregarHijos("X");
                                nodo.agregarHijos("V'");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("Q'''");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "V'":
                        {
                            nodo = new Nodo("V'");
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                                nodo.agregarHijos(token.getTipo());
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "X":
                        {
                            nodo = new Nodo("X");
                            if (token.getLexema().Equals(">") || token.getLexema().Equals("<") || token.getLexema().Equals("==") || token.getLexema().Equals("<=") || token.getLexema().Equals(">=") || token.getLexema().Equals("!="))
                            {
                                pila.Pop();
                                pila.Push(token.getLexema());
                                nodo.agregarHijos(token.getLexema());
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "Q'''":
                        {
                            nodo = new Nodo("Q'''");
                            if (token.getLexema().Equals("&&") || token.getLexema().Equals("||"))
                            {
                                pila.Pop();
                                pila.Push("V");
                                pila.Push(token.getLexema());
                                nodo.agregarHijos(token.getLexema());
                                nodo.agregarHijos("V");
                                nodos.Add(nodo);
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
                            nodo = new Nodo("S'");
                            if (token.getLexema().Equals("{"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                pila.Push("L");
                                pila.Push("{");
                                nodo.agregarHijos("{");
                                nodo.agregarHijos("L");
                                nodo.agregarHijos("}");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "S''":
                        {
                            nodo = new Nodo("S''");
                            if (token.getLexema().Equals("=") || token.getLexema().Equals(">") || token.getLexema().Equals("<") || token.getLexema().Equals("<=") || token.getLexema().Equals(">="))
                            {
                                pila.Pop();
                                pila.Push(token.getLexema());
                                nodo.agregarHijos(token.getLexema());
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "E":
                        {
                            nodo = new Nodo("E");
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
                                nodo.agregarHijos("SINO_SI");
                                nodo.agregarHijos("(");
                                nodo.agregarHijos("V");
                                nodo.agregarHijos(")");
                                nodo.agregarHijos("S'");
                                nodo.agregarHijos("E");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    case "E'":
                        {
                            nodo = new Nodo("E'");
                            if (token.getTipo().Equals("Variable") || token.getTipo().Equals("Funcionalidad") || token.getLexema().Equals("MIENTRAS") || token.getLexema().Equals("HACER") || token.getLexema().Equals("SI") || token.getLexema().Equals("DESDE") || token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                            }
                            else if (token.getLexema().Equals("SINO"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                pila.Push("SINO");
                                nodo.agregarHijos("SINO");
                                nodo.agregarHijos("S'");
                                nodos.Add(nodo);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                    default:
                        {
                            if (peek.Equals(token.getLexema()) || peek.Equals(token.getTipo()))
                            {
                               // generarSimbolo(token);
                                Console.WriteLine("Sale>>> " + peek + "\n");
                                pila.Pop();
                                return true;
                            }
                            else
                            {
                                
                               
                                if (token.getLexema().Equals("{"))
                                {
                                    control++;
                                }
                                pila.Pop();
                                return false;
                            }
                        }


                }

            }
            return true;
        }

        public ArrayList getNodos()
        {
            return nodos;
        }

        public void generarSimbolo(Lexema token)
        {
            MessageBox.Show("0:  " + lineaTabla[2]+" token: "+token.getLexema());
            if (token.getTipo().Equals("Variable"))
            {
                MessageBox.Show("1: entra " + token.getLexema());
                lineaTabla[0] = token.getLexema();
            }
            else if (lineaTabla[0] != null && token.getTipo().Equals("ID"))
            {
                MessageBox.Show("2: entra " + token.getLexema());
                lineaTabla[1] = token.getLexema();
            }
            else if (lineaTabla[1] != null && !token.getLexema().Equals(";"))
            {
                MessageBox.Show("-> 3: entra " + lineaTabla[2]);
                switch (lineaTabla[0])
                {
                    case "entero":
                        if (token.getTipo().Equals("Entero"))
                        {
                            lineaTabla[2] = lineaTabla[2] + token.getLexema();
                            MessageBox.Show("3: entra " + lineaTabla[2]);
                        }
                        else
                        {
                            lineaTabla[2] = "error";
                        }
                        break;
                    case "decimal":
                        if (token.getTipo().Equals("Decimal"))
                        {
                            lineaTabla[2] = lineaTabla[2] + token.getLexema();
                            MessageBox.Show("3: entra " + lineaTabla[2]);
                        }
                        else
                        {
                            lineaTabla[2] = "error";
                        }
                        break;
                    case "cadena":
                        if (token.getTipo().Equals("Cadena"))
                        {
                            lineaTabla[2] = lineaTabla[2] + token.getLexema();
                            MessageBox.Show("3: entra " + lineaTabla[2]);
                        }
                        else
                        {
                            lineaTabla[2] = "error";
                        }
                        break;
                    case "caracter":
                        if (token.getTipo().Equals("Caracter"))
                        {
                            lineaTabla[2] = lineaTabla[2] + token.getLexema();
                            MessageBox.Show("3: entra " + lineaTabla[2]);
                        }
                        else
                        {
                            lineaTabla[2] = "error";
                        }
                        break;
                    case "booleano":
                        if (token.getTipo().Equals("Booleano"))
                        {
                            lineaTabla[2] = lineaTabla[2] + token.getLexema();
                            MessageBox.Show("3: entra " + lineaTabla[2]);
                        }
                        else
                        {
                            lineaTabla[2] = "error";
                        }
                        break;
                    default:
                        MessageBox.Show("3: entra " + lineaTabla[2]);
                        break;
                }

            }
            else if (lineaTabla[2] != null && token.getLexema().Equals(";"))
            {
                MessageBox.Show("4: entra " + token.getLexema());
                simbolo = new Simbolo(lineaTabla[0], lineaTabla[1], lineaTabla[2]);
                Form1.simbolos.Add(simbolo);
                lineaTabla[0] = "";
                lineaTabla[1] = "";
                lineaTabla[2] = "";

            }
            else if (lineaTabla[0]!=null && lineaTabla[1] != null && lineaTabla[2].Equals("error") && token.getLexema().Equals(";"))
            {
                simbolo = new Simbolo(lineaTabla[0], lineaTabla[1], "null");
                Form1.simbolos.Add(simbolo);
                lineaTabla[0] = "";
                lineaTabla[1] = "";
                lineaTabla[2] = "";
            }

        }
    }
}


