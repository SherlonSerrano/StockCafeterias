namespace StockCafeterias.Windows.Formularios
{
    partial class FrmConsultaStockLocal
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
            lblLocal = new Label();
            cboLocal = new ComboBox();
            chkSoloStockBajo = new CheckBox();
            btnConsultar = new Button();
            dgvStock = new DataGridView();
            lblTotalRegistros = new Label();
            lblStockBajo = new Label();
            lblSinStock = new Label();
            pnlEncabezado = new Panel();
            lblTituloConsulta = new Label();
            lblSubtituloConsulta = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.Location = new Point(40, 120);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(56, 25);
            lblLocal.TabIndex = 0;
            lblLocal.Text = "Local:";
            // 
            // cboLocal
            // 
            cboLocal.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocal.FormattingEnabled = true;
            cboLocal.Location = new Point(130, 111);
            cboLocal.Name = "cboLocal";
            cboLocal.Size = new Size(182, 33);
            cboLocal.TabIndex = 1;
            // 
            // chkSoloStockBajo
            // 
            chkSoloStockBajo.AutoSize = true;
            chkSoloStockBajo.Location = new Point(345, 115);
            chkSoloStockBajo.Name = "chkSoloStockBajo";
            chkSoloStockBajo.Size = new Size(161, 29);
            chkSoloStockBajo.TabIndex = 2;
            chkSoloStockBajo.Text = "Solo stock bajo";
            chkSoloStockBajo.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(41, 128, 185);
            btnConsultar.Cursor = Cursors.Hand;
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(560, 111);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(140, 40);
            btnConsultar.TabIndex = 3;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(25, 213);
            dgvStock.MultiSelect = false;
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.RowHeadersWidth = 62;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(1020, 350);
            dgvStock.TabIndex = 4;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalRegistros.BackColor = Color.White;
            lblTotalRegistros.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalRegistros.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalRegistros.Location = new Point(40, 580);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(260, 45);
            lblTotalRegistros.TabIndex = 5;
            lblTotalRegistros.Text = "Registros: 0";
            lblTotalRegistros.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStockBajo
            // 
            lblStockBajo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStockBajo.BackColor = Color.White;
            lblStockBajo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStockBajo.ForeColor = Color.FromArgb(230, 126, 34);
            lblStockBajo.Location = new Point(345, 580);
            lblStockBajo.Name = "lblStockBajo";
            lblStockBajo.Size = new Size(260, 45);
            lblStockBajo.TabIndex = 6;
            lblStockBajo.Text = "Stock bajo: 0";
            lblStockBajo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSinStock
            // 
            lblSinStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSinStock.BackColor = Color.White;
            lblSinStock.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSinStock.ForeColor = Color.FromArgb(192, 57, 43);
            lblSinStock.Location = new Point(650, 580);
            lblSinStock.Name = "lblSinStock";
            lblSinStock.Size = new Size(260, 45);
            lblSinStock.TabIndex = 7;
            lblSinStock.Text = "Sin stock: 0";
            lblSinStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(44, 62, 80);
            pnlEncabezado.Controls.Add(lblSubtituloConsulta);
            pnlEncabezado.Controls.Add(lblTituloConsulta);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1078, 86);
            pnlEncabezado.TabIndex = 8;
            // 
            // lblTituloConsulta
            // 
            lblTituloConsulta.AutoSize = true;
            lblTituloConsulta.BackColor = Color.Transparent;
            lblTituloConsulta.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloConsulta.ForeColor = Color.White;
            lblTituloConsulta.Location = new Point(30, 5);
            lblTituloConsulta.Name = "lblTituloConsulta";
            lblTituloConsulta.Size = new Size(473, 48);
            lblTituloConsulta.TabIndex = 0;
            lblTituloConsulta.Text = "Consulta de stock por local";
            // 
            // lblSubtituloConsulta
            // 
            lblSubtituloConsulta.AutoSize = true;
            lblSubtituloConsulta.BackColor = Color.Transparent;
            lblSubtituloConsulta.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloConsulta.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtituloConsulta.Location = new Point(34, 53);
            lblSubtituloConsulta.Name = "lblSubtituloConsulta";
            lblSubtituloConsulta.Size = new Size(302, 28);
            lblSubtituloConsulta.TabIndex = 1;
            lblSubtituloConsulta.Text = "Control de Inventario Multi-Local";
            // 
            // FrmConsultaStockLocal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(1078, 644);
            Controls.Add(pnlEncabezado);
            Controls.Add(lblSinStock);
            Controls.Add(lblStockBajo);
            Controls.Add(lblTotalRegistros);
            Controls.Add(dgvStock);
            Controls.Add(btnConsultar);
            Controls.Add(chkSoloStockBajo);
            Controls.Add(cboLocal);
            Controls.Add(lblLocal);
            MinimumSize = new Size(900, 600);
            Name = "FrmConsultaStockLocal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta de stock por local";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLocal;
        private ComboBox cboLocal;
        private CheckBox chkSoloStockBajo;
        private Button btnConsultar;
        private DataGridView dgvStock;
        private Label lblTotalRegistros;
        private Label lblStockBajo;
        private Label lblSinStock;
        private Panel pnlEncabezado;
        private Label lblSubtituloConsulta;
        private Label lblTituloConsulta;
    }
}