using System;
using System.Collections;
using System.Windows.Forms;

namespace Analizador_lexico.Clases
{
    class Automata
    {
        //Atributo de estado inicial de automata
        private int estadoInicial = 0;
        //Atributo del estado actual de automata
        private int estadoActual = 0;
        //Atributo para obtener caracteres de la cadena
        private char caracter;
        //Atributo de arraylist para lexemas
        private ArrayList listaLexemas = new ArrayList();
        //Para que no tome el enter entre comillas
        private Boolean enterComillas = false;
        //Contador columna
        private int columna = 0;
        private int columna_aux = 0;
        //Contador fila
        private int fila = 1;

        Parser parser = new Parser();


        /*Metodo constructor*/
        public Automata()
        {
            estadoInicial = 0;
            estadoActual = 0;

        }
        public void analizadorAutomata(String cadena)
        {

            //Variable temporal para concatenar caracteres
            String tempToken = "";
            //Se agrega espacio vacio al final de la cadena para que guarde ultima palabra
            cadena = cadena + " ";
            //For para recorrer cadena
            for (estadoInicial = 0; estadoInicial < cadena.Length; estadoInicial++)
            {
                columna_aux++;
                sumarColumna();
                // se obtiene caracter en la cadena
                caracter = cadena[estadoInicial];
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
                                    tempToken += caracter;
                                    setEstadoActual(68);
                                    break;
                                case '*':
                                case '(':
                                case ')':
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
                                case '!':
                                    tempToken += caracter;
                                    setEstadoActual(23);
                                    break;
                                case '=':
                                    tempToken += caracter;
                                    setEstadoActual(25);
                                    break;
                                case ';':
                                    tempToken += caracter;
                                    setEstadoActual(26);
                                    break;
                                case '|':
                                    tempToken += caracter;
                                    setEstadoActual(21);
                                    break;
                                case '&':
                                    tempToken += caracter;
                                    setEstadoActual(22);
                                    break;
                                case '_':
                                    tempToken += caracter;
                                    setEstadoActual(30);
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
                                case '{':
                                case '}':
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
                                    if ((estadoInicial + 1) == cadena.Length)
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
                    /* Estado final para cuando viene un ++ o -- o multiplicacion o parentesis */
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
                    /* Para division */
                    case 68:
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
                                case '/':
                                    tempToken += caracter;
                                    setEstadoActual(27);
                                    break;
                                case '*':
                                    tempToken += caracter;
                                    setEstadoActual(28);
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
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '|':
                                    tempToken += caracter;
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
                    /*Estado para && */
                    case 22:
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
                                case '&':
                                    tempToken += caracter;
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
                    /*Estado para >, < */
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
                    /*Estado para = */
                    case 25:
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
                    /*Estado para ;*/
                    case 26:
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
                    /*Estado para comentario simple */
                    case 27:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(27);
                                    break;
                            }
                            break;
                        }
                    /*Estado para comentario compuesto */
                    case 28:
                        {
                            switch (caracter)
                            {
                                case '*':
                                    tempToken += caracter;
                                    setEstadoActual(29);
                                    break;
                                case '\n':
                                    tempToken += caracter;
                                    setEstadoActual(28);
                                    enterComillas = true;
                                    break;
                                default:
                                    if ((estadoInicial + 1) == cadena.Length)
                                    {
                                        insertarLexema(tempToken, 66);
                                        tempToken = "";
                                        setEstadoActual(0);
                                    }
                                    else
                                    {
                                        tempToken += caracter;
                                        setEstadoActual(28);
                                    }
                                    break;
                            }
                            break;
                        }
                    /*Estado para comentario compuesto*/
                    case 29:
                        {
                            switch (caracter)
                            {
                                case '/':
                                    tempToken += caracter;
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    insertarLexema(tempToken, 66);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                            }
                            break;
                        }
                    /*Estado para ID ejemplo: _id*/
                    case 30:
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
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
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
                                    setEstadoActual(31);
                                    break;
                            }
                            break;
                        }
                    /*Estado de aceptacion para ID ejemplo: _id*/
                    case 31:
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
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
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
                                    setEstadoActual(31);
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
                                case '{':
                                case '}':
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


                if (caracter.Equals('\n'))
                {
                    reiniciarColumna();
                    columna_aux = 0;
                    sumarFila();
                }


                /*Guarda los enters*/
                if (caracter.Equals('\n') && (!enterComillas))
                {
                    insertarLexema(caracter.ToString(), 67);
                }
                else
                {
                    enterComillas = false;
                }

            }
        }

        /*Establece el estado actual*/
        public void setEstadoActual(int estadoActual)
        {
            this.estadoActual = estadoActual;
        }
        /*Regresa el estado actual*/
        public int getEstadoActual()
        {
            return estadoActual;
        }


        /*Metodo para guardar lexema con su tipo*/
        public void insertarLexema(String token, int estadoActual)
        {
            Lexema nuevoToken;
            //Dependiendo del estado de aceptacion lo guarda con su tipo
            switch (estadoActual)
            {
                //Estado de aceptacion define el tipo de token segun el caso
                case 1:
                    nuevoToken = new Lexema(token, "Morado", "Entero");
                    asignarToken(nuevoToken);
                    break;
                case 3:
                    nuevoToken = new Lexema(token, "Celeste", "Decimal");
                    asignarToken(nuevoToken);
                    break;
                case 4:
                    nuevoToken = new Lexema(token, "Gris", "Cadena");
                    asignarToken(nuevoToken);
                    break;
                case 65:
                    nuevoToken = new Lexema(token, "Naranja", "Booleano");
                    asignarToken(nuevoToken);
                    break;
                case 66:
                    if (token.Equals("entero"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Variable");
                        asignarToken(nuevoToken);
                    }
                    else if (token.Equals("cadena"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Variable");
                        asignarToken(nuevoToken);
                    }
                    else if (token.Equals("caracter"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Variable");
                        asignarToken(nuevoToken);
                    }
                    else if (token.Equals("booleano"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Variable");
                        asignarToken(nuevoToken);

                    }
                    else if (token.Equals("decimal"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Variable");
                        asignarToken(nuevoToken);
                    }
                    else if (token.Equals("SI") || token.Equals("SINO") || token.Equals("SINO_SI") || token.Equals("MIENTRAS") || token.Equals("HACER") || token.Equals("DESDE") || token.Equals("HASTA") || token.Equals("INCREMENTO") || token.Equals("principal"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Reservada");
                        asignarToken(nuevoToken);
                    }
                    else if (token.Equals("leer") || token.Equals("imprimir"))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Funcionalidad");
                        asignarToken(nuevoToken);
                    }
                    else
                    {
                        nuevoToken = new Lexema(token, "Amarillo", "Error", getFila(), columna_aux - getColumna());
                        asignarToken(nuevoToken);

                    }

                    break;
                case 67:
                    nuevoToken = new Lexema(token, "Nulo", "Enter");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 16:
                case 5:
                case 13:
                    if (token.Equals("{") || token.Equals("}") || token.Equals(","))
                    {
                        nuevoToken = new Lexema(token, "Verde", "Reservada");
                        asignarToken(nuevoToken);
                    }
                    else
                    {
                        nuevoToken = new Lexema(token, "Cafe", "Caracter");
                        asignarToken(nuevoToken);
                    }
                    break;
                case 18:
                case 19:
                case 20:
                case 23:
                case 24:
                case 21:
                case 22:
                case 68:
                    nuevoToken = new Lexema(token, "Azul", "Operador");
                    asignarToken(nuevoToken);
                    break;
                case 25:
                case 26:
                    nuevoToken = new Lexema(token, "Rosado", "Asignacion");
                    asignarToken(nuevoToken);
                    break;
                case 27:
                case 29:
                    nuevoToken = new Lexema(token, "Rojo", "Comentario");
                    listaLexemas.Add(nuevoToken);
                    break;
                case 31:
                    nuevoToken = new Lexema(token, "Negro", "ID");
                    asignarToken(nuevoToken);
                    break;
            }
            reiniciarColumna();

        }

        /*Metodo que envia token a analizador sintactico y luego lo agrega a la lista*/
        public void asignarToken(Lexema nuevoToken)
        {
            if (!parser.analizador(nuevoToken))
            {
                nuevoToken.setTipo("Error");
                nuevoToken.setFila(getFila());
                nuevoToken.setColumna(columna_aux - getColumna());
            }
            listaLexemas.Add(nuevoToken);
        }


        /*Imprime tokens*/
        public void mostrarTokens()
        {
            for (int i = 0; i < listaLexemas.Count; i++)
            {
                Lexema lexema = (Lexema)listaLexemas[i];
                MessageBox.Show(i + ") " + lexema.getLexema() + " " + lexema.getTipo());
            }
        }


        /*Devuelve arraylist*/
        public ArrayList getListaLexema()
        {
            return listaLexemas;
        }

        public void sumarFila()
        {
            this.fila++;
        }

        public int getFila()
        {
            return fila;
        }

        public void sumarColumna()
        {
            this.columna++;
        }

        public void reiniciarColumna()
        {
            this.columna = 0;
        }

        public int getColumna()
        {
            return columna;
        }



    }
}
