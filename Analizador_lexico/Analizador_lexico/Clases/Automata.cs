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
                    case 0:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    break;
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
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
                                    setEstadoActual(18);
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

                                default:
                                    tempToken += caracter;
                                    setEstadoActual(16);
                                    break;
                            }
                            break;
                            
                        }
                    case 1:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;

                            }
                            break;
                        }
                    case 2:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken,66);
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
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
                    case 3:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
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
                                    insertarLexema(caracter.ToString(), 67);
                                    tempToken += caracter;
                                    setEstadoActual(4);
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
                    case 5:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 13:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 16:
                        {
                           
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
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
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 65:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                        }
                    case 66:
                        {
                            switch (caracter)
                            {
                                case '\n':           
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    insertarLexema(caracter.ToString(), 67);
                                    setEstadoActual(0);
                                    break;
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                case '"':
                                    insertarLexema(tempToken, getEstadoActual());
                                    tempToken = "";
                                    tempToken += caracter;
                                    setEstadoActual(4);
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
                    insertarLexema(caracter.ToString(), 67);
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
                    nuevoToken = new Lexema(token, "Gris", "Error");
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
                    nuevoToken = new Lexema(token, "Azul", "Operador Aritmetico");
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
