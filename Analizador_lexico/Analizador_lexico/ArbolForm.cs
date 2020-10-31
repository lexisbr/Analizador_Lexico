using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_lexico
{
    public partial class ArbolForm : Form
    {
        public ArbolForm()
        {
            InitializeComponent();
        }

        private void ArbolForm_Shown(object sender, EventArgs e)
        {
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(@"..\..\Arboles\tempArbol.jpeg");
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void exportarBttn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.Filter = "JPEG(.JPG)|.JPG|BMP(.BMP)|.BMP|PNG(.PNG)|.PNG";
                Image Imagen = pictureBox1.Image;
                if (Guardar.ShowDialog() == DialogResult.OK)
                {
                    Imagen.Save(Guardar.FileName);
                    MessageBox.Show("Se guardo exitosamente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
