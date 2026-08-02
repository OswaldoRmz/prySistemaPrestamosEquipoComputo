namespace prySistemaPrestamosEquipoComputo
{
    partial class frmVentanaDevoluciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentanaDevoluciones));
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlEncabezado = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFiltroBusqueda = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.dvgDevoluciones = new System.Windows.Forms.DataGridView();
            this.pcbSesion = new System.Windows.Forms.PictureBox();
            this.pcbUsuario = new System.Windows.Forms.PictureBox();
            this.lblRaya = new System.Windows.Forms.Label();
            this.pcbInicio = new System.Windows.Forms.PictureBox();
            this.pcbPrestamos = new System.Windows.Forms.PictureBox();
            this.pcbDevoluciones = new System.Windows.Forms.PictureBox();
            this.pcbInventario = new System.Windows.Forms.PictureBox();
            this.pcbReportes = new System.Windows.Forms.PictureBox();
            this.pcbTituloPC = new System.Windows.Forms.PictureBox();
            this.pcbFondoIncio = new System.Windows.Forms.PictureBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.pnlBusqueda.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDevoluciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDevoluciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTituloPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFondoIncio)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.cmbEstado);
            this.pnlBusqueda.Controls.Add(this.lblEstado);
            this.pnlBusqueda.Controls.Add(this.pnlEncabezado);
            this.pnlBusqueda.Location = new System.Drawing.Point(378, 42);
            this.pnlBusqueda.Margin = new System.Windows.Forms.Padding(1);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(1146, 159);
            this.pnlBusqueda.TabIndex = 1;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(196)))), ((int)(((byte)(201)))));
            this.pnlEncabezado.Controls.Add(this.lblFiltroBusqueda);
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(1);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1945, 44);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblFiltroBusqueda
            // 
            this.lblFiltroBusqueda.AutoSize = true;
            this.lblFiltroBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(196)))), ((int)(((byte)(201)))));
            this.lblFiltroBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFiltroBusqueda.ForeColor = System.Drawing.Color.Black;
            this.lblFiltroBusqueda.Location = new System.Drawing.Point(1, 0);
            this.lblFiltroBusqueda.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblFiltroBusqueda.Name = "lblFiltroBusqueda";
            this.lblFiltroBusqueda.Size = new System.Drawing.Size(189, 28);
            this.lblFiltroBusqueda.TabIndex = 1;
            this.lblFiltroBusqueda.Text = "Filtro de Busqueda";
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.ForeColor = System.Drawing.Color.Black;
            this.lblHistorial.Location = new System.Drawing.Point(910, 260);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(93, 28);
            this.lblHistorial.TabIndex = 2;
            this.lblHistorial.Text = "Historial";
            // 
            // dvgDevoluciones
            // 
            this.dvgDevoluciones.AllowUserToAddRows = false;
            this.dvgDevoluciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(223)))));
            this.dvgDevoluciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dvgDevoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgDevoluciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dvgDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgDevoluciones.DefaultCellStyle = dataGridViewCellStyle9;
            this.dvgDevoluciones.EnableHeadersVisualStyles = false;
            this.dvgDevoluciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(223)))));
            this.dvgDevoluciones.Location = new System.Drawing.Point(378, 309);
            this.dvgDevoluciones.Margin = new System.Windows.Forms.Padding(1);
            this.dvgDevoluciones.Name = "dvgDevoluciones";
            this.dvgDevoluciones.ReadOnly = true;
            this.dvgDevoluciones.RowHeadersVisible = false;
            this.dvgDevoluciones.RowHeadersWidth = 72;
            this.dvgDevoluciones.RowTemplate.Height = 31;
            this.dvgDevoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgDevoluciones.Size = new System.Drawing.Size(1146, 624);
            this.dvgDevoluciones.TabIndex = 3;
            this.dvgDevoluciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgDevoluciones_CellClick);
            // 
            // pcbSesion
            // 
            this.pcbSesion.BackColor = System.Drawing.Color.Transparent;
            this.pcbSesion.Image = ((System.Drawing.Image)(resources.GetObject("pcbSesion.Image")));
            this.pcbSesion.Location = new System.Drawing.Point(-1, 924);
            this.pcbSesion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbSesion.Name = "pcbSesion";
            this.pcbSesion.Size = new System.Drawing.Size(337, 90);
            this.pcbSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbSesion.TabIndex = 21;
            this.pcbSesion.TabStop = false;
            // 
            // pcbUsuario
            // 
            this.pcbUsuario.BackColor = System.Drawing.Color.Transparent;
            this.pcbUsuario.Image = ((System.Drawing.Image)(resources.GetObject("pcbUsuario.Image")));
            this.pcbUsuario.Location = new System.Drawing.Point(-1, 828);
            this.pcbUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbUsuario.Name = "pcbUsuario";
            this.pcbUsuario.Size = new System.Drawing.Size(337, 90);
            this.pcbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbUsuario.TabIndex = 20;
            this.pcbUsuario.TabStop = false;
            // 
            // lblRaya
            // 
            this.lblRaya.AutoSize = true;
            this.lblRaya.BackColor = System.Drawing.Color.Transparent;
            this.lblRaya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaya.Location = new System.Drawing.Point(-4, 810);
            this.lblRaya.Name = "lblRaya";
            this.lblRaya.Size = new System.Drawing.Size(340, 25);
            this.lblRaya.TabIndex = 19;
            this.lblRaya.Text = "-----------------------------------------";
            // 
            // pcbInicio
            // 
            this.pcbInicio.BackColor = System.Drawing.Color.Transparent;
            this.pcbInicio.Image = ((System.Drawing.Image)(resources.GetObject("pcbInicio.Image")));
            this.pcbInicio.Location = new System.Drawing.Point(-1, 176);
            this.pcbInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbInicio.Name = "pcbInicio";
            this.pcbInicio.Size = new System.Drawing.Size(337, 90);
            this.pcbInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbInicio.TabIndex = 18;
            this.pcbInicio.TabStop = false;
            this.pcbInicio.Click += new System.EventHandler(this.pcbInicio_Click);
            // 
            // pcbPrestamos
            // 
            this.pcbPrestamos.BackColor = System.Drawing.Color.Transparent;
            this.pcbPrestamos.Image = ((System.Drawing.Image)(resources.GetObject("pcbPrestamos.Image")));
            this.pcbPrestamos.Location = new System.Drawing.Point(-1, 309);
            this.pcbPrestamos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbPrestamos.Name = "pcbPrestamos";
            this.pcbPrestamos.Size = new System.Drawing.Size(337, 90);
            this.pcbPrestamos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPrestamos.TabIndex = 17;
            this.pcbPrestamos.TabStop = false;
            // 
            // pcbDevoluciones
            // 
            this.pcbDevoluciones.BackColor = System.Drawing.Color.Transparent;
            this.pcbDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("pcbDevoluciones.Image")));
            this.pcbDevoluciones.Location = new System.Drawing.Point(-1, 442);
            this.pcbDevoluciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbDevoluciones.Name = "pcbDevoluciones";
            this.pcbDevoluciones.Size = new System.Drawing.Size(337, 90);
            this.pcbDevoluciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDevoluciones.TabIndex = 16;
            this.pcbDevoluciones.TabStop = false;
            // 
            // pcbInventario
            // 
            this.pcbInventario.BackColor = System.Drawing.Color.Transparent;
            this.pcbInventario.Image = ((System.Drawing.Image)(resources.GetObject("pcbInventario.Image")));
            this.pcbInventario.Location = new System.Drawing.Point(-1, 575);
            this.pcbInventario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbInventario.Name = "pcbInventario";
            this.pcbInventario.Size = new System.Drawing.Size(337, 90);
            this.pcbInventario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbInventario.TabIndex = 15;
            this.pcbInventario.TabStop = false;
            // 
            // pcbReportes
            // 
            this.pcbReportes.BackColor = System.Drawing.Color.Transparent;
            this.pcbReportes.Image = ((System.Drawing.Image)(resources.GetObject("pcbReportes.Image")));
            this.pcbReportes.Location = new System.Drawing.Point(-1, 708);
            this.pcbReportes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbReportes.Name = "pcbReportes";
            this.pcbReportes.Size = new System.Drawing.Size(337, 90);
            this.pcbReportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReportes.TabIndex = 14;
            this.pcbReportes.TabStop = false;
            // 
            // pcbTituloPC
            // 
            this.pcbTituloPC.BackColor = System.Drawing.Color.Transparent;
            this.pcbTituloPC.Image = ((System.Drawing.Image)(resources.GetObject("pcbTituloPC.Image")));
            this.pcbTituloPC.Location = new System.Drawing.Point(-1, 15);
            this.pcbTituloPC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbTituloPC.Name = "pcbTituloPC";
            this.pcbTituloPC.Size = new System.Drawing.Size(335, 121);
            this.pcbTituloPC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbTituloPC.TabIndex = 13;
            this.pcbTituloPC.TabStop = false;
            // 
            // pcbFondoIncio
            // 
            this.pcbFondoIncio.BackColor = System.Drawing.Color.Transparent;
            this.pcbFondoIncio.Image = ((System.Drawing.Image)(resources.GetObject("pcbFondoIncio.Image")));
            this.pcbFondoIncio.Location = new System.Drawing.Point(-1, 0);
            this.pcbFondoIncio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcbFondoIncio.Name = "pcbFondoIncio";
            this.pcbFondoIncio.Size = new System.Drawing.Size(339, 1040);
            this.pcbFondoIncio.TabIndex = 12;
            this.pcbFondoIncio.TabStop = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(21, 81);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(117, 28);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Filtrar Tipo";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Equipo",
            "Consumibles"});
            this.cmbEstado.Location = new System.Drawing.Point(210, 78);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(708, 36);
            this.cmbEstado.TabIndex = 3;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // frmVentanaDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1573, 1055);
            this.Controls.Add(this.pcbSesion);
            this.Controls.Add(this.pcbUsuario);
            this.Controls.Add(this.lblRaya);
            this.Controls.Add(this.pcbInicio);
            this.Controls.Add(this.pcbPrestamos);
            this.Controls.Add(this.pcbDevoluciones);
            this.Controls.Add(this.pcbInventario);
            this.Controls.Add(this.pcbReportes);
            this.Controls.Add(this.pcbTituloPC);
            this.Controls.Add(this.pcbFondoIncio);
            this.Controls.Add(this.dvgDevoluciones);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.pnlBusqueda);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmVentanaDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devoluciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDevoluciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDevoluciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTituloPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFondoIncio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.FlowLayoutPanel pnlEncabezado;
        private System.Windows.Forms.Label lblFiltroBusqueda;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dvgDevoluciones;
        private System.Windows.Forms.PictureBox pcbSesion;
        private System.Windows.Forms.PictureBox pcbUsuario;
        private System.Windows.Forms.Label lblRaya;
        private System.Windows.Forms.PictureBox pcbInicio;
        private System.Windows.Forms.PictureBox pcbPrestamos;
        private System.Windows.Forms.PictureBox pcbDevoluciones;
        private System.Windows.Forms.PictureBox pcbInventario;
        private System.Windows.Forms.PictureBox pcbReportes;
        private System.Windows.Forms.PictureBox pcbTituloPC;
        private System.Windows.Forms.PictureBox pcbFondoIncio;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}