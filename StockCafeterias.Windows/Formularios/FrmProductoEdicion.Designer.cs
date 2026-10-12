namespace StockCafeterias.Windows.Formularios;

partial class FrmProductoEdicion
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
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblCategoria = new Label();
        cboCategoria = new ComboBox();
        lblPrecioVenta = new Label();
        nudPrecioVenta = new NumericUpDown();
        lblCostoPromedio = new Label();
        nudCostoPromedio = new NumericUpDown();
        lblStockMaximo = new Label();
        nudStockMaximo = new NumericUpDown();
        chkActivo = new CheckBox();
        lblFoto = new Label();
        picFoto = new PictureBox();
        btnCargarFoto = new Button();
        btnQuitarFoto = new Button();
        btnGuardar = new Button();
        btnCancelar = new Button();
        ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudCostoPromedio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStockMaximo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblTitulo.Location = new Point(24, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(189, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Datos de Producto";
        // 
        // lblNombre
        // 
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblNombre.Location = new Point(26, 75);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(77, 21);
        lblNombre.TabIndex = 1;
        lblNombre.Text = "Nombre:";
        // 
        // txtNombre
        // 
        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(26, 100);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(320, 30);
        txtNombre.TabIndex = 2;
        // 
        // lblCategoria
        // 
        lblCategoria.AutoSize = true;
        lblCategoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCategoria.Location = new Point(26, 145);
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Size = new Size(88, 21);
        lblCategoria.TabIndex = 3;
        lblCategoria.Text = "Categoría:";
        // 
        // cboCategoria
        // 
        cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCategoria.Font = new Font("Segoe UI", 10F);
        cboCategoria.FormattingEnabled = true;
        cboCategoria.Location = new Point(26, 170);
        cboCategoria.Name = "cboCategoria";
        cboCategoria.Size = new Size(320, 29);
        cboCategoria.TabIndex = 4;
        // 
        // lblPrecioVenta
        // 
        lblPrecioVenta.AutoSize = true;
        lblPrecioVenta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPrecioVenta.Location = new Point(26, 215);
        lblPrecioVenta.Name = "lblPrecioVenta";
        lblPrecioVenta.Size = new Size(130, 21);
        lblPrecioVenta.TabIndex = 5;
        lblPrecioVenta.Text = "Precio Venta (S/):";
        // 
        // nudPrecioVenta
        // 
        nudPrecioVenta.DecimalPlaces = 2;
        nudPrecioVenta.Font = new Font("Segoe UI", 10F);
        nudPrecioVenta.Location = new Point(26, 240);
        nudPrecioVenta.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudPrecioVenta.Name = "nudPrecioVenta";
        nudPrecioVenta.Size = new Size(150, 30);
        nudPrecioVenta.TabIndex = 6;
        // 
        // lblCostoPromedio
        // 
        lblCostoPromedio.AutoSize = true;
        lblCostoPromedio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblCostoPromedio.Location = new Point(196, 215);
        lblCostoPromedio.Name = "lblCostoPromedio";
        lblCostoPromedio.Size = new Size(150, 21);
        lblCostoPromedio.TabIndex = 7;
        lblCostoPromedio.Text = "Costo Promedio (S/):";
        // 
        // nudCostoPromedio
        // 
        nudCostoPromedio.DecimalPlaces = 2;
        nudCostoPromedio.Font = new Font("Segoe UI", 10F);
        nudCostoPromedio.Location = new Point(196, 240);
        nudCostoPromedio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudCostoPromedio.Name = "nudCostoPromedio";
        nudCostoPromedio.Size = new Size(150, 30);
        nudCostoPromedio.TabIndex = 8;
        // 
        // lblStockMaximo
        // 
        lblStockMaximo.AutoSize = true;
        lblStockMaximo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblStockMaximo.Location = new Point(26, 285);
        lblStockMaximo.Name = "lblStockMaximo";
        lblStockMaximo.Size = new Size(119, 21);
        lblStockMaximo.TabIndex = 9;
        lblStockMaximo.Text = "Stock Máximo:";
        // 
        // nudStockMaximo
        // 
        nudStockMaximo.Font = new Font("Segoe UI", 10F);
        nudStockMaximo.Location = new Point(26, 310);
        nudStockMaximo.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        nudStockMaximo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudStockMaximo.Name = "nudStockMaximo";
        nudStockMaximo.Size = new Size(150, 30);
        nudStockMaximo.TabIndex = 10;
        nudStockMaximo.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // chkActivo
        // 
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = CheckState.Checked;
        chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        chkActivo.Location = new Point(196, 312);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(155, 25);
        chkActivo.TabIndex = 11;
        chkActivo.Text = "Producto Activo";
        chkActivo.UseVisualStyleBackColor = true;
        // 
        // lblFoto
        // 
        lblFoto.AutoSize = true;
        lblFoto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFoto.Location = new Point(390, 75);
        lblFoto.Name = "lblFoto";
        lblFoto.Size = new Size(93, 21);
        lblFoto.TabIndex = 12;
        lblFoto.Text = "Fotografía:";
        // 
        // picFoto
        // 
        picFoto.BorderStyle = BorderStyle.FixedSingle;
        picFoto.Location = new Point(390, 100);
        picFoto.Name = "picFoto";
        picFoto.Size = new Size(190, 170);
        picFoto.SizeMode = PictureBoxSizeMode.Zoom;
        picFoto.TabIndex = 13;
        picFoto.TabStop = false;
        // 
        // btnCargarFoto
        // 
        btnCargarFoto.BackColor = Color.FromArgb(236, 240, 241);
        btnCargarFoto.Cursor = Cursors.Hand;
        btnCargarFoto.FlatStyle = FlatStyle.Flat;
        btnCargarFoto.Font = new Font("Segoe UI", 9F);
        btnCargarFoto.Location = new Point(390, 280);
        btnCargarFoto.Name = "btnCargarFoto";
        btnCargarFoto.Size = new Size(90, 32);
        btnCargarFoto.TabIndex = 14;
        btnCargarFoto.Text = "Examinar...";
        btnCargarFoto.UseVisualStyleBackColor = false;
        btnCargarFoto.Click += btnCargarFoto_Click;
        // 
        // btnQuitarFoto
        // 
        btnQuitarFoto.BackColor = Color.FromArgb(236, 240, 241);
        btnQuitarFoto.Cursor = Cursors.Hand;
        btnQuitarFoto.FlatStyle = FlatStyle.Flat;
        btnQuitarFoto.Font = new Font("Segoe UI", 9F);
        btnQuitarFoto.Location = new Point(490, 280);
        btnQuitarFoto.Name = "btnQuitarFoto";
        btnQuitarFoto.Size = new Size(90, 32);
        btnQuitarFoto.TabIndex = 15;
        btnQuitarFoto.Text = "Quitar";
        btnQuitarFoto.UseVisualStyleBackColor = false;
        btnQuitarFoto.Click += btnQuitarFoto_Click;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
        btnGuardar.Cursor = Cursors.Hand;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(320, 370);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.TabIndex = 16;
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
        btnCancelar.Location = new Point(455, 370);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(125, 40);
        btnCancelar.TabIndex = 17;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        // 
        // FrmProductoEdicion
        // 
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancelar;
        ClientSize = new Size(610, 435);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        Controls.Add(btnQuitarFoto);
        Controls.Add(btnCargarFoto);
        Controls.Add(picFoto);
        Controls.Add(lblFoto);
        Controls.Add(chkActivo);
        Controls.Add(nudStockMaximo);
        Controls.Add(lblStockMaximo);
        Controls.Add(nudCostoPromedio);
        Controls.Add(lblCostoPromedio);
        Controls.Add(nudPrecioVenta);
        Controls.Add(lblPrecioVenta);
        Controls.Add(cboCategoria);
        Controls.Add(lblCategoria);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmProductoEdicion";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Formulario de Producto";
        Load += FrmProductoEdicion_Load;
        ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudCostoPromedio).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStockMaximo).EndInit();
        ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblCategoria;
    private ComboBox cboCategoria;
    private Label lblPrecioVenta;
    private NumericUpDown nudPrecioVenta;
    private Label lblCostoPromedio;
    private NumericUpDown nudCostoPromedio;
    private Label lblStockMaximo;
    private NumericUpDown nudStockMaximo;
    private CheckBox chkActivo;
    private Label lblFoto;
    private PictureBox picFoto;
    private Button btnCargarFoto;
    private Button btnQuitarFoto;
    private Button btnGuardar;
    private Button btnCancelar;
}
