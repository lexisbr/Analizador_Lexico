using System;
using System.Collections;
using System.Windows.Forms;

namespace Analizador_lexico.Clases
{
    class Automata
    {
        private int estadoInicial = 0;
        private int estadoActual = 0;
        private String token = "";
        private char caracter;
        private ArrayList listaLexemas = new ArrayList();
        private Boolean enterComillas = false;
        public Automata()
        {
            estadoInicial = 0;
            estadoActual = 0;
            token = "";
        }
        public void analizadorAutomata(String cadena)
        {
            String tempToken = "";
            cadena = cadena + " ";
            for(estadoInicial=0; estadoInicial < cadena.Length; estadoInicial++)
            {
                caracter = cadena[estadoInicial];
                Console.WriteLine("estado actual "+estadoActual +" caracter "+caracter);
                
                switch (estadoActual)
                {
                    /* Estado inicial */
                    case 0:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\n':
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    tempToken += caracter;
                                    setEstadoActual(1);
                                    break;
                                case '-':
                                    tempToken += caracter;
                                    setEstadoActual(18);
                                    break;
                                case '+':
                                    tempToken += caracter;
                                    setEstadoActual(19);
                                    break;
                                case '/':
                                case '*':
                                    tempToken += caracter;
                                    setEstadoActual(20);
                                    break;
                                case '"':
                                    tempToken += caracter;
                                    setEstadoActual(4);
                                    break;
                                case 'v':
                                    tempToken += caracter;
                                    setEstadoActual(5);
                                    break;
                                case 'f':
                                    tempToken += caracter;
                                    setEstadoActual(13);
                                    break;
                                case '>':                             
                                case '<':
                                case '=':
                                case '!':
                                    tempToken += caracter;
                                    setEstadoActual(23);
                                    break;

                                default:
                                    tempToken += caracter;
                                    setEstadoActual(16);
                                    break;
                            }
                            break;
                            
                        }
                        /*Estado para numeros*/
                    case 1:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken,getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    tempToken += caracter;
                                    setEstadoActual(1);
                                    break;
                                case '.':
                                    tempToken += caracter;
                                    setEstadoActual(2);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                case 'f':
                                case 'v':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;

                            }
                            break;
                        }
                        /*Estado para transicion cuando viene un punto"*/
                    case 2:
                        {
                            switch (caracter)
                            {
                                case '\n':                   
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    tempToken += caracter;
                                    setEstadoActual(3);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }             
                            break;
                        }
                        /*Estado para numeros decimales*/
                    case 3:
                        {
                            switch (caracter)
                            {
                                case '\n':                     
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    tempToken += caracter;
                                    setEstadoActual(3);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                case 'f':
                                case 'v':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /*Estado para cadena con comillas*/
                    case 4:
                        {
                            switch (caracter)
                            {
                                case '"':
                                    tempToken += caracter;
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '\n':
                                    tempToken += caracter;
                                    setEstadoActual(4);
                                    enterComillas = true;
                                    break;
                                default:
                                    if ((estadoInicial+1) == cadena.Length)
                                    {
                                        insertarLexema(tempToken, 66);
                                        tempToken = "";
                                        setEstadoActual(0);
                                    }
                                    else
                                    {
                                        tempToken += caracter;
                                        setEstadoActual(4);
                                    }
                                    break;
                            }
                            break;
                        }
                        /* Estado para cuando viene un verdadero*/
                    case 5:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'e':     
                                    tempToken += caracter;
                                    setEstadoActual(6);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':         
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 6:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'r':
                                    tempToken += caracter;
                                    setEstadoActual(7);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 7:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'd':
                                    tempToken += caracter;
                                    setEstadoActual(8);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':    
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 8:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'a':
                                    tempToken += caracter;
                                    setEstadoActual(9);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 9:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'd':
                                    tempToken += caracter;
                                    setEstadoActual(10);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 10:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'e':
                                    tempToken += caracter;
                                    setEstadoActual(11);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 11:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'r':
                                    tempToken += caracter;
                                    setEstadoActual(12);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /*Estado final para falso y verdadero*/
                    case 12:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'o':
                                    tempToken += caracter;
                                    setEstadoActual(65);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /* Estados para falso*/
                    case 13:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'a':
                                    tempToken += caracter;
                                    setEstadoActual(14);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken,getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 14:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 'l':
                                    tempToken += caracter;
                                    setEstadoActual(15);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 15:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case 's':
                                    tempToken += caracter;
                                    setEstadoActual(12);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /*Estado para caracter*/
                    case 16:
                        {
                           
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken,getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /*Estado para cuando viene un -*/
                   case 18:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    tempToken += caracter;
                                    setEstadoActual(1);
                                    break;
                                case '-':
                                    tempToken += caracter;
                                    setEstadoActual(20);
                                    break;
                                default:
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                        /*Estado cuando viene un +*/
                    case 19:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '+':
                                    tempToken += caracter;
                                    setEstadoActual(20);
                                    break;
                                default:
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                        /* Estado final para cuando viene un ++ o -- o division o multiplicacion */
                    case 20:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                    /*Estado para || */
                    case 21:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken,66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '|':
                                    tempToken += caracter;
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    insertarLexema(tempToken,66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                    /*Estado para >, < o = */
                    case 23:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '=':
                                    tempToken += caracter;
                                    setEstadoActual(24);
                                    break;
                                default:
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                        /* Estado por si viene un = despues */
                    case 24:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                    /*Estado final para booleano*/
                    case 65:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                        /*Estado para errores*/
                    case 66:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    estadoInicial = estadoInicial - 1;
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    break;
                            }
                            break;
                        }
                }

                if (caracter.Equals('\n')&&(!enterComillas))
                {
                    insertarLexema(caracter.ToString(), 67);
                }
                else
                {
                    enterComillas = false;
                }
            }
        }

   
        public void setEstadoActual(int estadoActual)
        {
            this.estadoActual = estadoActual;
        }
        public int getEstadoActual()
        {
            return estadoActual;
        }

        public void setToken(String token)
        {
            this.token = token;
            
        }

        public string getToken()
        {
            return token;
        }

        /*public void setTokenErroneo(String token)
        {
            listaErrores.Add(token);
        }*/


        public void insertarLexema(String token, int estadoActual)
        {
            Lexema nuevoToken;
            switch (estadoActual)
            {
                case 1:
                    nuevoToken = new Lexema(token, "Morado", "Entero");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 3:
                    nuevoToken = new Lexema(token, "Celeste", "Decimal");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 4:
                    nuevoToken = new Lexema(token, "Gris", "Cadena");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 65:
                    nuevoToken = new Lexema(token, "Naranja", "Booleano");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 66:
                    nuevoToken = new Lexema(token, "Negro", "Error");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 67:
                    nuevoToken = new Lexema(token, "Nulo", "Enter");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 16:
                case 5:
                case 13:
                    nuevoToken = new Lexema(token, "Cafe", "Caracter");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 18:
                case 19:
                case 20:
                case 23:
                case 24:
                    nuevoToken = new Lexema(token, "Azul", "Operador");
                    listaLexemas.Add(nuevoToken);
                    break;
            }
          
        }

        public void mostrarTokens()
        {
            for (int i = 0; i < listaLexemas.Count; i++)
            {
                Lexema lexema = (Lexema)listaLexemas[i];
                MessageBox.Show(i + ") " + lexema.getLexema() + " " + lexema.getTipo());
            }
        }

        public ArrayList getListaLexema()
        {
            return listaLexemas;
        }





    }
}
