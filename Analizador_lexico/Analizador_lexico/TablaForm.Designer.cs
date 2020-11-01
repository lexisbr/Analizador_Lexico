namespace Analizador_lexico
{
    partial class TablaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabla_tbl = new System.Windows.Forms.DataGridView();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProyectoActual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_tbl)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla_tbl
            // 
            this.tabla_tbl.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.tabla_tbl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.tabla_tbl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tabla_tbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_tbl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo,
            this.ID,
            this.Valor});
            this.tabla_tbl.Location = new System.Drawing.Point(33, 81);
            this.tabla_tbl.Name = "tabla_tbl";
            this.tabla_tbl.Size = new System.Drawing.Size(615, 301);
            this.tabla_tbl.TabIndex = 0;
            this.tabla_tbl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_tbl_CellContentClick);
            // 
            // Tipo
            // 
            this.Tipo.Frozen = true;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.Frozen = true;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // lblProyectoActual
            // 
            this.lblProyectoActual.AutoSize = true;
            this.lblProyectoActual.BackColor = System.Drawing.Color.Transparent;
            this.lblProyectoActual.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProyectoActual.ForeColor = System.Drawing.Color.Transparent;
            this.lblProyectoActual.Location = new System.Drawing.Point(203, 26);
            this.lblProyectoActual.Name = "lblProyectoActual";
            this.lblProyectoActual.Size = new System.Drawing.Size(265, 39);
            this.lblProyectoActual.TabIndex = 1;
            this.lblProyectoActual.Text = "Tabla de Simbolos";
            this.lblProyectoActual.Click += new System.EventHandler(this.lblProyectoActual_Click);
            // 
            // TablaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Analizador_lexico.Properties.Resources.fondo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 421);
            this.Controls.Add(this.lblProyectoActual);
            this.Controls.Add(this.tabla_tbl);
            this.Name = "TablaForm";
            this.Text = "IDE - Lexees";
            this.Load += new System.EventHandler(this.TablaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_tbl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla_tbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Label lblProyectoActual;
    }
}