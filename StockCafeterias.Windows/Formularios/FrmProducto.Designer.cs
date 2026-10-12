namespace StockCafeterias.Windows.Formularios;

partial class FrmProducto
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlSuperior = new Panel();
        lblTitulo = new Label();
        pnlFiltros = new Panel();
        btnLimpiar = new Button();
        btnBuscar = new Button();
        cboFiltroEstado = new ComboBox();
        lblEstado = new Label();
        txtBuscar = new TextBox();
        lblBuscar = new Label();
        dgvProductos = new DataGridView();
        pnlInferior = new Panel();
        lblTotal = new Label();
        btnCerrar = new Button();
        btnRefrescar = new Button();
        btnEliminar = new Button();
        btnEditar = new Button();
        btnNuevo = new Button();
        pnlSuperior.SuspendLayout();
        pnlFiltros.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
        pnlInferior.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSuperior
        // 
        pnlSuperior.BackColor = Color.FromArgb(44, 62, 80);
        pnlSuperior.Controls.Add(lblTitulo);
        pnlSuperior.Dock = DockStyle.Top;
        pnlSuperior.Location = new Point(0, 0);
        pnlSuperior.Name = "pnlSuperior";
        pnlSuperior.Size = new Size(880, 60);
        pnlSuperior.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 15);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(295, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Mantenimiento de Productos";
        // 
        // pnlFiltros
        // 
        pnlFiltros.BackColor = Color.FromArgb(245, 247, 250);
        pnlFiltros.Controls.Add(btnLimpiar);
        pnlFiltros.Controls.Add(btnBuscar);
        pnlFiltros.Controls.Add(cboFiltroEstado);
        pnlFiltros.Controls.Add(lblEstado);
        pnlFiltros.Controls.Add(txtBuscar);
        pnlFiltros.Controls.Add(lblBuscar);
        pnlFiltros.Dock = DockStyle.Top;
        pnlFiltros.Location = new Point(0, 60);
        pnlFiltros.Name = "pnlFiltros";
        pnlFiltros.Size = new Size(880, 65);
        pnlFiltros.TabIndex = 1;
        // 
        // btnLimpiar
        // 
        btnLimpiar.BackColor = Color.FromArgb(149, 165, 166);
        btnLimpiar.Cursor = Cursors.Hand;
        btnLimpiar.FlatAppearance.BorderSize = 0;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.Font = new Font("Segoe UI", 9F);
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.Location = new Point(690, 17);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(85, 32);
        btnLimpiar.TabIndex = 5;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // btnBuscar
        // 
        btnBuscar.BackColor = Color.FromArgb(41, 128, 185);
        btnBuscar.Cursor = Cursors.Hand;
        btnBuscar.FlatAppearance.BorderSize = 0;
        btnBuscar.FlatStyle = FlatStyle.Flat;
        btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnBuscar.ForeColor = Color.White;
        btnBuscar.Location = new Point(595, 17);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(85, 32);
        btnBuscar.TabIndex = 4;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = false;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // cboFiltroEstado
        // 
        cboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFiltroEstado.Font = new Font("Segoe UI", 9.5F);
        cboFiltroEstado.FormattingEnabled = true;
        cboFiltroEstado.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });
        cboFiltroEstado.Location = new Point(440, 18);
        cboFiltroEstado.Name = "cboFiltroEstado";
        cboFiltroEstado.Size = new Size(135, 29);
        cboFiltroEstado.TabIndex = 3;
        cboFiltroEstado.SelectedIndexChanged += cboFiltroEstado_SelectedIndexChanged;
        // 
        // lblEstado
        // 
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblEstado.Location = new Point(375, 22);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(66, 21);
        lblEstado.TabIndex = 2;
        lblEstado.Text = "Estado:";
        // 
        // txtBuscar
        // 
        txtBuscar.Font = new Font("Segoe UI", 9.5F);
        txtBuscar.Location = new Point(85, 18);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.PlaceholderText = "Nombre del producto...";
        txtBuscar.Size = new Size(260, 29);
        txtBuscar.TabIndex = 1;
        txtBuscar.KeyDown += txtBuscar_KeyDown;
        // 
        // lblBuscar
        // 
        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblBuscar.Location = new Point(20, 22);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(65, 21);
        lblBuscar.TabIndex = 0;
        lblBuscar.Text = "Buscar:";
        // 
        // dgvProductos
        // 
        dgvProductos.AllowUserToAddRows = false;
        dgvProductos.AllowUserToDeleteRows = false;
        dgvProductos.AllowUserToResizeRows = false;
        dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProductos.BackgroundColor = Color.White;
        dgvProductos.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(236, 240, 241);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.FromArgb(44, 62, 80);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 152, 219);
        dataGridViewCellStyle2.SelectionForeColor = Color.White;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
        dgvProductos.Dock = DockStyle.Fill;
        dgvProductos.EnableHeadersVisualStyles = false;
        dgvProductos.Location = new Point(0, 125);
        dgvProductos.MultiSelect = false;
        dgvProductos.Name = "dgvProductos";
        dgvProductos.ReadOnly = true;
        dgvProductos.RowHeadersVisible = false;
        dgvProductos.RowHeadersWidth = 51;
        dgvProductos.RowTemplate.Height = 32;
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProductos.Size = new Size(880, 360);
        dgvProductos.TabIndex = 2;
        dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
        // 
        // pnlInferior
        // 
        pnlInferior.BackColor = Color.FromArgb(245, 247, 250);
        pnlInferior.Controls.Add(lblTotal);
        pnlInferior.Controls.Add(btnCerrar);
        pnlInferior.Controls.Add(btnRefrescar);
        pnlInferior.Controls.Add(btnEliminar);
        pnlInferior.Controls.Add(btnEditar);
        pnlInferior.Controls.Add(btnNuevo);
        pnlInferior.Dock = DockStyle.Bottom;
        pnlInferior.Location = new Point(0, 485);
        pnlInferior.Name = "pnlInferior";
        pnlInferior.Size = new Size(880, 65);
        pnlInferior.TabIndex = 3;
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblTotal.ForeColor = Color.FromArgb(127, 140, 141);
        lblTotal.Location = new Point(20, 23);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(141, 20);
        lblTotal.TabIndex = 5;
        lblTotal.Text = "Total de registros: 0";
        // 
        // btnCerrar
        // 
        btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCerrar.BackColor = Color.FromArgb(149, 165, 166);
        btnCerrar.Cursor = Cursors.Hand;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 9F);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.Location = new Point(770, 16);
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(95, 35);
        btnCerrar.TabIndex = 4;
        btnCerrar.Text = "Cerrar";
        btnCerrar.UseVisualStyleBackColor = false;
        btnCerrar.Click += btnCerrar_Click;
        // 
        // btnRefrescar
        // 
        btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefrescar.BackColor = Color.FromArgb(52, 73, 94);
        btnRefrescar.Cursor = Cursors.Hand;
        btnRefrescar.FlatAppearance.BorderSize = 0;
        btnRefrescar.FlatStyle = FlatStyle.Flat;
        btnRefrescar.Font = new Font("Segoe UI", 9F);
        btnRefrescar.ForeColor = Color.White;
        btnRefrescar.Location = new Point(665, 16);
        btnRefrescar.Name = "btnRefrescar";
        btnRefrescar.Size = new Size(95, 35);
        btnRefrescar.TabIndex = 3;
        btnRefrescar.Text = "Refrescar";
        btnRefrescar.UseVisualStyleBackColor = false;
        btnRefrescar.Click += btnRefrescar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
        btnEliminar.Cursor = Cursors.Hand;
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.Location = new Point(545, 16);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(110, 35);
        btnEliminar.TabIndex = 2;
        btnEliminar.Text = "Desactivar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // btnEditar
        // 
        btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnEditar.BackColor = Color.FromArgb(243, 156, 18);
        btnEditar.Cursor = Cursors.Hand;
        btnEditar.FlatAppearance.BorderSize = 0;
        btnEditar.FlatStyle = FlatStyle.Flat;
        btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEditar.ForeColor = Color.White;
        btnEditar.Location = new Point(430, 16);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(105, 35);
        btnEditar.TabIndex = 1;
        btnEditar.Text = "Modificar";
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // btnNuevo
        // 
        btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnNuevo.BackColor = Color.FromArgb(39, 174, 96);
        btnNuevo.Cursor = Cursors.Hand;
        btnNuevo.FlatAppearance.BorderSize = 0;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNuevo.ForeColor = Color.White;
        btnNuevo.Location = new Point(315, 16);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(105, 35);
        btnNuevo.TabIndex = 0;
        btnNuevo.Text = "+ Nuevo";
        btnNuevo.UseVisualStyleBackColor = false;
        btnNuevo.Click += btnNuevo_Click;
        // 
        // FrmProducto
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(880, 550);
        Controls.Add(dgvProductos);
        Controls.Add(pnlInferior);
        Controls.Add(pnlFiltros);
        Controls.Add(pnlSuperior);
        MinimumSize = new Size(800, 500);
        Name = "FrmProducto";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mantenimiento de Productos";
        Load += FrmProducto_Load;
        pnlSuperior.ResumeLayout(false);
        pnlSuperior.PerformLayout();
        pnlFiltros.ResumeLayout(false);
        pnlFiltros.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
        pnlInferior.ResumeLayout(false);
        pnlInferior.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlSuperior;
    private Label lblTitulo;
    private Panel pnlFiltros;
    private TextBox txtBuscar;
    private Label lblBuscar;
    private ComboBox cboFiltroEstado;
    private Label lblEstado;
    private Button btnBuscar;
    private Button btnLimpiar;
    private DataGridView dgvProductos;
    private Panel pnlInferior;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnRefrescar;
    private Button btnCerrar;
    private Label lblTotal;
}
