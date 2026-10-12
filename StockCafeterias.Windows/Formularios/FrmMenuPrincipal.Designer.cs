namespace StockCafeterias.Windows.Formularios;

partial class FrmMenuPrincipal
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
        pnlHeader = new Panel();
        lblSubtitulo = new Label();
        lblTitulo = new Label();
        pnlLateral = new Panel();
        btnSalir = new Button();
        btnUsuarios = new Button();
        btnInsumos = new Button();
        btnProductos = new Button();
        pnlContenedor = new Panel();
        pnlCardUsuarios = new Panel();
        btnCardUsuarios = new Button();
        lblCardUsuariosDesc = new Label();
        lblCardUsuariosTitulo = new Label();
        pnlCardInsumos = new Panel();
        btnCardInsumos = new Button();
        lblCardInsumosDesc = new Label();
        lblCardInsumosTitulo = new Label();
        pnlCardProductos = new Panel();
        btnCardProductos = new Button();
        lblCardProductosDesc = new Label();
        lblCardProductosTitulo = new Label();
        lblBienvenida = new Label();
        statusStrip1 = new StatusStrip();
        lblStatusUsuario = new ToolStripStatusLabel();
        lblStatusSeparador = new ToolStripStatusLabel();
        lblStatusFecha = new ToolStripStatusLabel();
        pnlHeader.SuspendLayout();
        pnlLateral.SuspendLayout();
        pnlContenedor.SuspendLayout();
        pnlCardUsuarios.SuspendLayout();
        pnlCardInsumos.SuspendLayout();
        pnlCardProductos.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
        pnlHeader.Controls.Add(lblSubtitulo);
        pnlHeader.Controls.Add(lblTitulo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1000, 80);
        pnlHeader.TabIndex = 0;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font("Segoe UI", 10F);
        lblSubtitulo.ForeColor = Color.FromArgb(189, 195, 199);
        lblSubtitulo.Location = new Point(25, 45);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(480, 23);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Sistema de Control de Inventario Multi-Local | PA2 Programación";
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(22, 9);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(307, 41);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "☕ StockCafeterias";
        // 
        // pnlLateral
        // 
        pnlLateral.BackColor = Color.FromArgb(52, 73, 94);
        pnlLateral.Controls.Add(btnSalir);
        pnlLateral.Controls.Add(btnUsuarios);
        pnlLateral.Controls.Add(btnInsumos);
        pnlLateral.Controls.Add(btnProductos);
        pnlLateral.Dock = DockStyle.Left;
        pnlLateral.Location = new Point(0, 80);
        pnlLateral.Name = "pnlLateral";
        pnlLateral.Size = new Size(220, 520);
        pnlLateral.TabIndex = 1;
        // 
        // btnSalir
        // 
        btnSalir.BackColor = Color.FromArgb(192, 57, 43);
        btnSalir.Cursor = Cursors.Hand;
        btnSalir.Dock = DockStyle.Bottom;
        btnSalir.FlatAppearance.BorderSize = 0;
        btnSalir.FlatStyle = FlatStyle.Flat;
        btnSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnSalir.ForeColor = Color.White;
        btnSalir.Location = new Point(0, 465);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(220, 55);
        btnSalir.TabIndex = 3;
        btnSalir.Text = "🚪 Salir del Sistema";
        btnSalir.UseVisualStyleBackColor = false;
        btnSalir.Click += btnSalir_Click;
        // 
        // btnUsuarios
        // 
        btnUsuarios.Cursor = Cursors.Hand;
        btnUsuarios.Dock = DockStyle.Top;
        btnUsuarios.FlatAppearance.BorderSize = 0;
        btnUsuarios.FlatStyle = FlatStyle.Flat;
        btnUsuarios.Font = new Font("Segoe UI", 11F);
        btnUsuarios.ForeColor = Color.White;
        btnUsuarios.Location = new Point(0, 110);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Padding = new Padding(20, 0, 0, 0);
        btnUsuarios.Size = new Size(220, 55);
        btnUsuarios.TabIndex = 2;
        btnUsuarios.Text = "👤 Usuarios";
        btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
        btnUsuarios.UseVisualStyleBackColor = true;
        btnUsuarios.Click += btnUsuarios_Click;
        // 
        // btnInsumos
        // 
        btnInsumos.Cursor = Cursors.Hand;
        btnInsumos.Dock = DockStyle.Top;
        btnInsumos.FlatAppearance.BorderSize = 0;
        btnInsumos.FlatStyle = FlatStyle.Flat;
        btnInsumos.Font = new Font("Segoe UI", 11F);
        btnInsumos.ForeColor = Color.White;
        btnInsumos.Location = new Point(0, 55);
        btnInsumos.Name = "btnInsumos";
        btnInsumos.Padding = new Padding(20, 0, 0, 0);
        btnInsumos.Size = new Size(220, 55);
        btnInsumos.TabIndex = 1;
        btnInsumos.Text = "📦 Insumos";
        btnInsumos.TextAlign = ContentAlignment.MiddleLeft;
        btnInsumos.UseVisualStyleBackColor = true;
        btnInsumos.Click += btnInsumos_Click;
        // 
        // btnProductos
        // 
        btnProductos.Cursor = Cursors.Hand;
        btnProductos.Dock = DockStyle.Top;
        btnProductos.FlatAppearance.BorderSize = 0;
        btnProductos.FlatStyle = FlatStyle.Flat;
        btnProductos.Font = new Font("Segoe UI", 11F);
        btnProductos.ForeColor = Color.White;
        btnProductos.Location = new Point(0, 0);
        btnProductos.Name = "btnProductos";
        btnProductos.Padding = new Padding(20, 0, 0, 0);
        btnProductos.Size = new Size(220, 55);
        btnProductos.TabIndex = 0;
        btnProductos.Text = "🍰 Productos";
        btnProductos.TextAlign = ContentAlignment.MiddleLeft;
        btnProductos.UseVisualStyleBackColor = true;
        btnProductos.Click += btnProductos_Click;
        // 
        // pnlContenedor
        // 
        pnlContenedor.BackColor = Color.FromArgb(240, 244, 248);
        pnlContenedor.Controls.Add(pnlCardUsuarios);
        pnlContenedor.Controls.Add(pnlCardInsumos);
        pnlContenedor.Controls.Add(pnlCardProductos);
        pnlContenedor.Controls.Add(lblBienvenida);
        pnlContenedor.Dock = DockStyle.Fill;
        pnlContenedor.Location = new Point(220, 80);
        pnlContenedor.Name = "pnlContenedor";
        pnlContenedor.Size = new Size(780, 520);
        pnlContenedor.TabIndex = 2;
        // 
        // pnlCardUsuarios
        // 
        pnlCardUsuarios.BackColor = Color.White;
        pnlCardUsuarios.BorderStyle = BorderStyle.FixedSingle;
        pnlCardUsuarios.Controls.Add(btnCardUsuarios);
        pnlCardUsuarios.Controls.Add(lblCardUsuariosDesc);
        pnlCardUsuarios.Controls.Add(lblCardUsuariosTitulo);
        pnlCardUsuarios.Location = new Point(515, 100);
        pnlCardUsuarios.Name = "pnlCardUsuarios";
        pnlCardUsuarios.Size = new Size(225, 230);
        pnlCardUsuarios.TabIndex = 3;
        // 
        // btnCardUsuarios
        // 
        btnCardUsuarios.BackColor = Color.FromArgb(142, 68, 173);
        btnCardUsuarios.Cursor = Cursors.Hand;
        btnCardUsuarios.FlatAppearance.BorderSize = 0;
        btnCardUsuarios.FlatStyle = FlatStyle.Flat;
        btnCardUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCardUsuarios.ForeColor = Color.White;
        btnCardUsuarios.Location = new Point(20, 165);
        btnCardUsuarios.Name = "btnCardUsuarios";
        btnCardUsuarios.Size = new Size(180, 42);
        btnCardUsuarios.TabIndex = 2;
        btnCardUsuarios.Text = "Abrir Usuarios";
        btnCardUsuarios.UseVisualStyleBackColor = false;
        btnCardUsuarios.Click += btnUsuarios_Click;
        // 
        // lblCardUsuariosDesc
        // 
        lblCardUsuariosDesc.Font = new Font("Segoe UI", 9F);
        lblCardUsuariosDesc.ForeColor = Color.FromArgb(127, 140, 141);
        lblCardUsuariosDesc.Location = new Point(15, 60);
        lblCardUsuariosDesc.Name = "lblCardUsuariosDesc";
        lblCardUsuariosDesc.Size = new Size(190, 90);
        lblCardUsuariosDesc.TabIndex = 1;
        lblCardUsuariosDesc.Text = "Administración de usuarios, asignación de roles, locales asignados y credenciales de acceso.";
        // 
        // lblCardUsuariosTitulo
        // 
        lblCardUsuariosTitulo.AutoSize = true;
        lblCardUsuariosTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblCardUsuariosTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblCardUsuariosTitulo.Location = new Point(15, 18);
        lblCardUsuariosTitulo.Name = "lblCardUsuariosTitulo";
        lblCardUsuariosTitulo.Size = new Size(118, 28);
        lblCardUsuariosTitulo.TabIndex = 0;
        lblCardUsuariosTitulo.Text = "👤 Usuarios";
        // 
        // pnlCardInsumos
        // 
        pnlCardInsumos.BackColor = Color.White;
        pnlCardInsumos.BorderStyle = BorderStyle.FixedSingle;
        pnlCardInsumos.Controls.Add(btnCardInsumos);
        pnlCardInsumos.Controls.Add(lblCardInsumosDesc);
        pnlCardInsumos.Controls.Add(lblCardInsumosTitulo);
        pnlCardInsumos.Location = new Point(275, 100);
        pnlCardInsumos.Name = "pnlCardInsumos";
        pnlCardInsumos.Size = new Size(225, 230);
        pnlCardInsumos.TabIndex = 2;
        // 
        // btnCardInsumos
        // 
        btnCardInsumos.BackColor = Color.FromArgb(230, 126, 34);
        btnCardInsumos.Cursor = Cursors.Hand;
        btnCardInsumos.FlatAppearance.BorderSize = 0;
        btnCardInsumos.FlatStyle = FlatStyle.Flat;
        btnCardInsumos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCardInsumos.ForeColor = Color.White;
        btnCardInsumos.Location = new Point(20, 165);
        btnCardInsumos.Name = "btnCardInsumos";
        btnCardInsumos.Size = new Size(180, 42);
        btnCardInsumos.TabIndex = 2;
        btnCardInsumos.Text = "Abrir Insumos";
        btnCardInsumos.UseVisualStyleBackColor = false;
        btnCardInsumos.Click += btnInsumos_Click;
        // 
        // lblCardInsumosDesc
        // 
        lblCardInsumosDesc.Font = new Font("Segoe UI", 9F);
        lblCardInsumosDesc.ForeColor = Color.FromArgb(127, 140, 141);
        lblCardInsumosDesc.Location = new Point(15, 60);
        lblCardInsumosDesc.Name = "lblCardInsumosDesc";
        lblCardInsumosDesc.Size = new Size(190, 90);
        lblCardInsumosDesc.TabIndex = 1;
        lblCardInsumosDesc.Text = "Control de insumos básicos, unidades de medida, costos y umbrales de stock mínimo de seguridad.";
        // 
        // lblCardInsumosTitulo
        // 
        lblCardInsumosTitulo.AutoSize = true;
        lblCardInsumosTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblCardInsumosTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblCardInsumosTitulo.Location = new Point(15, 18);
        lblCardInsumosTitulo.Name = "lblCardInsumosTitulo";
        lblCardInsumosTitulo.Size = new Size(116, 28);
        lblCardInsumosTitulo.TabIndex = 0;
        lblCardInsumosTitulo.Text = "📦 Insumos";
        // 
        // pnlCardProductos
        // 
        pnlCardProductos.BackColor = Color.White;
        pnlCardProductos.BorderStyle = BorderStyle.FixedSingle;
        pnlCardProductos.Controls.Add(btnCardProductos);
        pnlCardProductos.Controls.Add(lblCardProductosDesc);
        pnlCardProductos.Controls.Add(lblCardProductosTitulo);
        pnlCardProductos.Location = new Point(35, 100);
        pnlCardProductos.Name = "pnlCardProductos";
        pnlCardProductos.Size = new Size(225, 230);
        pnlCardProductos.TabIndex = 1;
        // 
        // btnCardProductos
        // 
        btnCardProductos.BackColor = Color.FromArgb(41, 128, 185);
        btnCardProductos.Cursor = Cursors.Hand;
        btnCardProductos.FlatAppearance.BorderSize = 0;
        btnCardProductos.FlatStyle = FlatStyle.Flat;
        btnCardProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCardProductos.ForeColor = Color.White;
        btnCardProductos.Location = new Point(20, 165);
        btnCardProductos.Name = "btnCardProductos";
        btnCardProductos.Size = new Size(180, 42);
        btnCardProductos.TabIndex = 2;
        btnCardProductos.Text = "Abrir Productos";
        btnCardProductos.UseVisualStyleBackColor = false;
        btnCardProductos.Click += btnProductos_Click;
        // 
        // lblCardProductosDesc
        // 
        lblCardProductosDesc.Font = new Font("Segoe UI", 9F);
        lblCardProductosDesc.ForeColor = Color.FromArgb(127, 140, 141);
        lblCardProductosDesc.Location = new Point(15, 60);
        lblCardProductosDesc.Name = "lblCardProductosDesc";
        lblCardProductosDesc.Size = new Size(190, 90);
        lblCardProductosDesc.TabIndex = 1;
        lblCardProductosDesc.Text = "Catálogo de productos finales, precios de venta, costos, stock máximo y registro fotográfico.";
        // 
        // lblCardProductosTitulo
        // 
        lblCardProductosTitulo.AutoSize = true;
        lblCardProductosTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblCardProductosTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblCardProductosTitulo.Location = new Point(15, 18);
        lblCardProductosTitulo.Name = "lblCardProductosTitulo";
        lblCardProductosTitulo.Size = new Size(132, 28);
        lblCardProductosTitulo.TabIndex = 0;
        lblCardProductosTitulo.Text = "🍰 Productos";
        // 
        // lblBienvenida
        // 
        lblBienvenida.AutoSize = true;
        lblBienvenida.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblBienvenida.ForeColor = Color.FromArgb(44, 62, 80);
        lblBienvenida.Location = new Point(35, 35);
        lblBienvenida.Name = "lblBienvenida";
        lblBienvenida.Size = new Size(424, 32);
        lblBienvenida.TabIndex = 0;
        lblBienvenida.Text = "Panel de Mantenimientos (CRUDs)";
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusUsuario, lblStatusSeparador, lblStatusFecha });
        statusStrip1.Location = new Point(220, 574);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(780, 26);
        statusStrip1.TabIndex = 3;
        statusStrip1.Text = "statusStrip1";
        // 
        // lblStatusUsuario
        // 
        lblStatusUsuario.Name = "lblStatusUsuario";
        lblStatusUsuario.Size = new Size(111, 20);
        lblStatusUsuario.Text = "Usuario: admin";
        // 
        // lblStatusSeparador
        // 
        lblStatusSeparador.Name = "lblStatusSeparador";
        lblStatusSeparador.Size = new Size(13, 20);
        lblStatusSeparador.Text = "|";
        // 
        // lblStatusFecha
        // 
        lblStatusFecha.Name = "lblStatusFecha";
        lblStatusFecha.Size = new Size(144, 20);
        lblStatusFecha.Text = "Fecha: 2026-10-11";
        // 
        // FrmMenuPrincipal
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1000, 600);
        Controls.Add(statusStrip1);
        Controls.Add(pnlContenedor);
        Controls.Add(pnlLateral);
        Controls.Add(pnlHeader);
        MinimumSize = new Size(950, 550);
        Name = "FrmMenuPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "StockCafeterias - Menú Principal";
        Load += FrmMenuPrincipal_Load;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlLateral.ResumeLayout(false);
        pnlContenedor.ResumeLayout(false);
        pnlContenedor.PerformLayout();
        pnlCardUsuarios.ResumeLayout(false);
        pnlCardUsuarios.PerformLayout();
        pnlCardInsumos.ResumeLayout(false);
        pnlCardInsumos.PerformLayout();
        pnlCardProductos.ResumeLayout(false);
        pnlCardProductos.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel pnlHeader;
    private Label lblTitulo;
    private Label lblSubtitulo;
    private Panel pnlLateral;
    private Button btnProductos;
    private Button btnInsumos;
    private Button btnUsuarios;
    private Button btnSalir;
    private Panel pnlContenedor;
    private Label lblBienvenida;
    private Panel pnlCardProductos;
    private Label lblCardProductosTitulo;
    private Label lblCardProductosDesc;
    private Button btnCardProductos;
    private Panel pnlCardInsumos;
    private Label lblCardInsumosTitulo;
    private Label lblCardInsumosDesc;
    private Button btnCardInsumos;
    private Panel pnlCardUsuarios;
    private Label lblCardUsuariosTitulo;
    private Label lblCardUsuariosDesc;
    private Button btnCardUsuarios;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatusUsuario;
    private ToolStripStatusLabel lblStatusSeparador;
    private ToolStripStatusLabel lblStatusFecha;
}
