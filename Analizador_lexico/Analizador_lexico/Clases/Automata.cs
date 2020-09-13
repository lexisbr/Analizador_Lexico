using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico.Clases
{
    class Automata
    {
        private int estadoInicial = 0;
        private int estadoActual = 0;
        private String token = "";
        private char caracter;
        private String[] tokenValido = new string [1];
        private int cont = 0;

        public Automata()
        {
            estadoInicial = 0;
            estadoActual = 0;
            token = "";
    }
        public void analizadorAutomata(String cadena)
        {
            for(estadoInicial=0; estadoInicial < cadena.Length; estadoInicial++)
            {
                caracter = cadena[estadoInicial];

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
                                    estadoActual = 0;
                                    break;
                                case 'a':
                                    setToken(token+caracter);
                                    setEstadoActual(2);
                                    break;
                                case 'b':
                                    setToken(token + caracter);
                                    setEstadoActual(1);
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
                                    estadoActual = 0;
                                    break;
                                case 'a':
                                    setToken(token + caracter);
                                    setEstadoActual(2);
                                    break;
                                case 'b':
                                    setToken(token + caracter);
                                    setEstadoActual(1);
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
                                    estadoActual = 0;
                                    break;
                                case 'a':
                                    setToken(token + caracter);
                                    setEstadoActual(2);
                                    break;
                                case 'b':
                                    setToken(token + caracter);
                                    setEstadoActual(1);
                                    break;
                            }
                            break;
                        }
                    

                }
            }
            setTokenValido(getToken(), cadena.Last());
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

        public void setToken(String token)
        {
            this.token = token;
        }

        public string getToken()
        {
            return token;
        }
    }
}
