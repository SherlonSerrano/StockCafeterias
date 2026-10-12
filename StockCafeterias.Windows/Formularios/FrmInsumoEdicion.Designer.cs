namespace StockCafeterias.Windows.Formularios;

partial class FrmInsumoEdicion
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblDescripcion = new Label();
        txtDescripcion = new TextBox();
        lblUnidadMedida = new Label();
        cboUnidadMedida = new ComboBox();
        lblPrecio = new Label();
        nudPrecio = new NumericUpDown();
        lblStockMinimo = new Label();
        nudStockMinimo = new NumericUpDown();
        chkActivo = new CheckBox();
        btnGuardar = new Button();
        btnCancelar = new Button();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblTitulo.Location = new Point(24, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(174, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Datos de Insumo";
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDescripcion.Location = new Point(26, 75);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(106, 21);
        lblDescripcion.TabIndex = 1;
        lblDescripcion.Text = "Descripción:";
        // 
        // txtDescripcion
        // 
        txtDescripcion.Font = new Font("Segoe UI", 10F);
        txtDescripcion.Location = new Point(26, 100);
        txtDescripcion.MaxLength = 100;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Size = new Size(380, 30);
        txtDescripcion.TabIndex = 2;
        // 
        // lblUnidadMedida
        // 
        lblUnidadMedida.AutoSize = true;
        lblUnidadMedida.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblUnidadMedida.Location = new Point(26, 145);
        lblUnidadMedida.Name = "lblUnidadMedida";
        lblUnidadMedida.Size = new Size(153, 21);
        lblUnidadMedida.TabIndex = 3;
        lblUnidadMedida.Text = "Unidad de Medida:";
        // 
        // cboUnidadMedida
        // 
        cboUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
        cboUnidadMedida.Font = new Font("Segoe UI", 10F);
        cboUnidadMedida.FormattingEnabled = true;
        cboUnidadMedida.Location = new Point(26, 170);
        cboUnidadMedida.Name = "cboUnidadMedida";
        cboUnidadMedida.Size = new Size(380, 29);
        cboUnidadMedida.TabIndex = 4;
        // 
        // lblPrecio
        // 
        lblPrecio.AutoSize = true;
        lblPrecio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPrecio.Location = new Point(26, 215);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Size = new Size(160, 21);
        lblPrecio.TabIndex = 5;
        lblPrecio.Text = "Precio Unitario (S/):";
        // 
        // nudPrecio
        // 
        nudPrecio.DecimalPlaces = 2;
        nudPrecio.Font = new Font("Segoe UI", 10F);
        nudPrecio.Location = new Point(26, 240);
        nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudPrecio.Name = "nudPrecio";
        nudPrecio.Size = new Size(180, 30);
        nudPrecio.TabIndex = 6;
        // 
        // lblStockMinimo
        // 
        lblStockMinimo.AutoSize = true;
        lblStockMinimo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblStockMinimo.Location = new Point(226, 215);
        lblStockMinimo.Name = "lblStockMinimo";
        lblStockMinimo.Size = new Size(116, 21);
        lblStockMinimo.TabIndex = 7;
        lblStockMinimo.Text = "Stock Mínimo:";
        // 
        // nudStockMinimo
        // 
        nudStockMinimo.DecimalPlaces = 2;
        nudStockMinimo.Font = new Font("Segoe UI", 10F);
        nudStockMinimo.Location = new Point(226, 240);
        nudStockMinimo.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        nudStockMinimo.Name = "nudStockMinimo";
        nudStockMinimo.Size = new Size(180, 30);
        nudStockMinimo.TabIndex = 8;
        // 
        // chkActivo
        // 
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = CheckState.Checked;
        chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        chkActivo.Location = new Point(26, 290);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(141, 25);
        chkActivo.TabIndex = 9;
        chkActivo.Text = "Insumo Activo";
        chkActivo.UseVisualStyleBackColor = true;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
        btnGuardar.Cursor = Cursors.Hand;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(150, 345);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.TabIndex = 10;
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += btnGuardar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
        btnCancelar.Cursor = Cursors.Hand;
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.FlatAppearance.BorderSize = 0;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.Font = new Font("Segoe UI", 10F);
        btnCancelar.ForeColor = Color.White;
        btnCancelar.Location = new Point(281, 345);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(125, 40);
        btnCancelar.TabIndex = 11;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        // 
        // FrmInsumoEdicion
        // 
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancelar;
        ClientSize = new Size(434, 410);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        Controls.Add(chkActivo);
        Controls.Add(nudStockMinimo);
        Controls.Add(lblStockMinimo);
        Controls.Add(nudPrecio);
        Controls.Add(lblPrecio);
        Controls.Add(cboUnidadMedida);
        Controls.Add(lblUnidadMedida);
        Controls.Add(txtDescripcion);
        Controls.Add(lblDescripcion);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmInsumoEdicion";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Formulario de Insumo";
        Load += FrmInsumoEdicion_Load;
        ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private Label lblDescripcion;
    private TextBox txtDescripcion;
    private Label lblUnidadMedida;
    private ComboBox cboUnidadMedida;
    private Label lblPrecio;
    private NumericUpDown nudPrecio;
    private Label lblStockMinimo;
    private NumericUpDown nudStockMinimo;
    private CheckBox chkActivo;
    private Button btnGuardar;
    private Button btnCancelar;
}
