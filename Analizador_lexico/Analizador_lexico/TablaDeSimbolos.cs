using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_lexico
{
    class TablaDeSimbolos
    {
        public static List<List<string>> tabla = new List<List<string>>();
        private int contador = 0;

        public void agregarItem(string tipo, string identificador, string valor)
        {
            tabla.Add(new List<string>());
            tabla[contador].Add(tipo);
            tabla[contador].Add(identificador);
            tabla[contador].Add(valor);
            sumarContador();

        }

        public void sumarContador()
        {
            contador++;
        }

        public List<List<string>> enviarTabla()
        {
            return tabla;
        }

        public void mostrarTabla()
        {
            for (int i = 0; i < tabla.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Windows.Forms.MessageBox.Show("Tabla " +  tabla[i][j].ToString());
                }
            }
        }
    }
}
