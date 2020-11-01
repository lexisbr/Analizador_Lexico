using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Analizador_lexico
{
    public partial class TablaForm : Form
    {
        private ArrayList simbolos;

        public TablaForm(ArrayList simbolos)
        {
            InitializeComponent();
            this.simbolos = (ArrayList)simbolos.Clone();
        }

        private void TablaForm_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        public void cargarTabla()
        {
            try
            {
                tabla_tbl.Columns[0].Width = 200;
                tabla_tbl.Columns[1].Width = 200;
                tabla_tbl.Columns[2].Width = 200;
                for (int i = 0; i < simbolos.Count; i++)
                {
                    Simbolo simbolo = (Simbolo)simbolos[i];
                    tabla_tbl.Rows.Add(simbolo.getTipo(),simbolo.getIdentificador(),simbolo.getValor());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error al cargar tabla");
            }
           
        }

        public class AgregarItem
        {
            //Se usa clase MyItem para agregar valor a filas
            public string Tokens { get; set; }
            public string Tipo { get; set; }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabla_tbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblProyectoActual_Click(object sender, EventArgs e)
        {

        }
    }
}
