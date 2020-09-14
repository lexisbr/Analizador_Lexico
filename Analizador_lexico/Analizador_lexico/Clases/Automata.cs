using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_lexico.Clases
{
    class Automata
    {
        private int estadoInicial = 0;
        private int estadoActual = 0;
        private String token = "";
        private char caracter;
        private String tempToken = "";
        private String[] tokenValido;
        private String[] tokens;
        private string color;
        private int cont = 0;
        private ArrayList listaLexemas = new ArrayList();
        private ArrayList listaErrores = new ArrayList();

        public Automata()
        {
            estadoInicial = 0;
            estadoActual = 0;
            token = "";
        }
        public void analizadorAutomata(String cadena)
        {
            cadena = cadena + " ";
            for(estadoInicial=0; estadoInicial < cadena.Length; estadoInicial++)
            {
                caracter = cadena[estadoInicial];
                //MessageBox.Show("estado actual "+estadoActual +" caracter "+caracter);
                switch (estadoActual)
                {
                    case 0:
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
                                case '"':
                                    tempToken += caracter;
                                    setEstadoActual(4);
                                    break;
                                case 'v':
                                    tempToken += caracter;
                                    setEstadoActual(5);
                                    break;
                                default:
                                    tempToken += caracter;
                                    setEstadoActual(66);
                                    break;
                            }
                            break;
                            
                        }
                    case 1:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
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
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
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
                                default:
                                    if ((estadoInicial+1) == cadena.Length)
                                    {
                                        setTokenErroneo(tempToken);
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
                                case 'o':
                                    tempToken += caracter;
                                    setEstadoActual(13);
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
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    setTokenErroneo(tempToken);
                                    tempToken = "";
                                    setEstadoActual(0);
                                    break;
                                default:
                                    tempToken += caracter;
                                    break;
                            }
                            break;
                        }
                    

                }
            }
        }

        private void setTokenValido(String lexema, char siguiente)
        {
            switch (siguiente)
            {
                case ' ':
                    tokenValido[0] = lexema;
                    break;
                default:
                    tokenValido[0] = lexema;
                    break;
            }
        }

        public String [] getTokenValido()
        {
            return tokenValido;
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

        public void setTokenErroneo(String token)
        {
            listaErrores.Add(token);
        }


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
                case 13:
                    nuevoToken = new Lexema(token, "Naranja", "Booleano");
                    listaLexemas.Add(nuevoToken);
                    break;
            }
          
        }

        public void mostrarTokens()
        {
            for (int i = 0; i < listaLexemas.Count; i++)
            {
                Lexema lexema = (Lexema)listaLexemas[i];
                MessageBox.Show(i+") "+lexema.getLexema()+" "+lexema.getTipo());
            }
        }
        public void mostrarErrores()
        {
            foreach (string cadena in listaErrores)
                MessageBox.Show(cadena + " Error");
        }

        public void setTempToken(String tempToken)
        {
            if (!tempToken.Equals(""))
            {
                this.tempToken = tempToken;
            }
            
        }

        public String getTempToken()
        {
            return tempToken;
        }


    }
}
