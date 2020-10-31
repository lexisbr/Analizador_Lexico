namespace Analizador_lexico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProyectoActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaTexto = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exportarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProyectoActual = new System.Windows.Forms.Label();
            this.generarArbol_bttn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblColumna = new System.Windows.Forms.Label();
            this.lblLinea = new System.Windows.Forms.Label();
            this.areaErrores = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightYellow;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.menuStrip1_KeyPress);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.eliminarProyectoActualToolStripMenuItem});
            this.archivoToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.carpeta;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.nuevo;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.caja__1_;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.salvar;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.toppng_com_icono_guardar_todo_419x419;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // eliminarProyectoActualToolStripMenuItem
            // 
            this.eliminarProyectoActualToolStripMenuItem.Image = global::Analizador_lexico.Properties.Resources.pngfind_com_bin_png_4577925;
            this.eliminarProyectoActualToolStripMenuItem.Name = "eliminarProyectoActualToolStripMenuItem";
            this.eliminarProyectoActualToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.eliminarProyectoActualToolStripMenuItem.Text = "Eliminar proyecto actual";
            this.eliminarProyectoActualToolStripMenuItem.Click += new System.EventHandler(this.eliminarProyectoActualToolStripMenuItem_Click);
            // 
            // areaTexto
            // 
            this.areaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.areaTexto.BackColor = System.Drawing.Color.White;
            this.areaTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaTexto.ForeColor = System.Drawing.Color.Black;
            this.areaTexto.Location = new System.Drawing.Point(13, 17);
            this.areaTexto.Name = "areaTexto";
            this.areaTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.areaTexto.Size = new System.Drawing.Size(918, 417);
            this.areaTexto.TabIndex = 2;
            this.areaTexto.Text = "";
            this.areaTexto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.areaTexto_MouseClick);
            this.areaTexto.TextChanged += new System.EventHandler(this.areaTexto_TextChanged);
            this.areaTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.areaTexto_KeyDown);
            this.areaTexto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaTexto_KeyPress);
            this.areaTexto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.areaTexto_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.exportarButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblProyectoActual);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 64);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // exportarButton
            // 
            this.exportarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportarButton.BackColor = System.Drawing.Color.Transparent;
            this.exportarButton.FlatAppearance.BorderSize = 0;
            this.exportarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.exportarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportarButton.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportarButton.ForeColor = System.Drawing.Color.White;
            this.exportarButton.Image = global::Analizador_lexico.Properties.Resources.pngegg__2___1_;
            this.exportarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportarButton.Location = new System.Drawing.Point(772, 9);
            this.exportarButton.Margin = new System.Windows.Forms.Padding(0);
            this.exportarButton.Name = "exportarButton";
            this.exportarButton.Size = new System.Drawing.Size(172, 43);
            this.exportarButton.TabIndex = 5;
            this.exportarButton.Text = "Exportar errores";
            this.exportarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportarButton.UseVisualStyleBackColor = false;
            this.exportarButton.Click += new System.EventHandler(this.exportarButton_Click);
            this.exportarButton.MouseHover += new System.EventHandler(this.exportarButton_MouseHover);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Analizador_lexico.Properties.Resources.jugar__1___1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(639, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Compilar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Analizador_lexico.Properties.Resources.resumen;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 48);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblProyectoActual
            // 
            this.lblProyectoActual.AutoSize = true;
            this.lblProyectoActual.BackColor = System.Drawing.Color.Brown;
            this.lblProyectoActual.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyectoActual.ForeColor = System.Drawing.Color.Transparent;
            this.lblProyectoActual.Location = new System.Drawing.Point(60, 16);
            this.lblProyectoActual.Name = "lblProyectoActual";
            this.lblProyectoActual.Size = new System.Drawing.Size(155, 26);
            this.lblProyectoActual.TabIndex = 0;
            this.lblProyectoActual.Text = "Proyecto actual:";
            this.lblProyectoActual.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // generarArbol_bttn
            // 
            this.generarArbol_bttn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generarArbol_bttn.BackColor = System.Drawing.Color.YellowGreen;
            this.generarArbol_bttn.Enabled = false;
            this.generarArbol_bttn.FlatAppearance.BorderSize = 0;
            this.generarArbol_bttn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.generarArbol_bttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generarArbol_bttn.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarArbol_bttn.ForeColor = System.Drawing.Color.Black;
            this.generarArbol_bttn.Image = global::Analizador_lexico.Properties.Resources.arbol;
            this.generarArbol_bttn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.generarArbol_bttn.Location = new System.Drawing.Point(757, 651);
            this.generarArbol_bttn.Margin = new System.Windows.Forms.Padding(0);
            this.generarArbol_bttn.Name = "generarArbol_bttn";
            this.generarArbol_bttn.Size = new System.Drawing.Size(204, 86);
            this.generarArbol_bttn.TabIndex = 6;
            this.generarArbol_bttn.Text = "Generar Arbol Sintactico";
            this.generarArbol_bttn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.generarArbol_bttn.UseVisualStyleBackColor = false;
            this.generarArbol_bttn.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblColumna);
            this.panel2.Controls.Add(this.lblLinea);
            this.panel2.Controls.Add(this.areaTexto);
            this.panel2.Location = new System.Drawing.Point(12, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 465);
            this.panel2.TabIndex = 4;
            // 
            // lblColumna
            // 
            this.lblColumna.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColumna.AutoSize = true;
            this.lblColumna.BackColor = System.Drawing.Color.Transparent;
            this.lblColumna.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumna.ForeColor = System.Drawing.Color.Black;
            this.lblColumna.Location = new System.Drawing.Point(96, 437);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(71, 18);
            this.lblColumna.TabIndex = 4;
            this.lblColumna.Text = "Columna:";
            // 
            // lblLinea
            // 
            this.lblLinea.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLinea.AutoSize = true;
            this.lblLinea.BackColor = System.Drawing.Color.Transparent;
            this.lblLinea.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinea.ForeColor = System.Drawing.Color.Black;
            this.lblLinea.Location = new System.Drawing.Point(28, 437);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(48, 18);
            this.lblLinea.TabIndex = 3;
            this.lblLinea.Text = "Linea:";
            // 
            // areaErrores
            // 
            this.areaErrores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.areaErrores.BackColor = System.Drawing.SystemColors.ControlDark;
            this.areaErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaErrores.ForeColor = System.Drawing.Color.DarkRed;
            this.areaErrores.Location = new System.Drawing.Point(27, 627);
            this.areaErrores.Name = "areaErrores";
            this.areaErrores.ReadOnly = true;
            this.areaErrores.Size = new System.Drawing.Size(711, 134);
            this.areaErrores.TabIndex = 5;
            this.areaErrores.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 595);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Errores:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Analizador_lexico.Properties.Resources.kisspng_computer_icons_error_download_triangle_icon_5b41d8cf40b6e3_1645135015310419992651__1_;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(27, 588);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 33);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.BackgroundImage = global::Analizador_lexico.Properties.Resources.fondo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(973, 785);
            this.Controls.Add(this.generarArbol_bttn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.areaErrores);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDE - Lexees";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox areaTexto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProyectoActual;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox areaErrores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem eliminarProyectoActualToolStripMenuItem;
        private System.Windows.Forms.Button exportarButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblColumna;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Button generarArbol_bttn;
    }
}

