namespace StockCafeterias.Windows.Formularios;

partial class FrmUsuarioCambiarClave
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
        lblUsuarioInfo = new Label();
        lblNuevaClave = new Label();
        txtNuevaClave = new TextBox();
        lblConfirmarClave = new Label();
        txtConfirmarClave = new TextBox();
        btnGuardar = new Button();
        btnCancelar = new Button();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
        lblTitulo.Location = new Point(20, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(224, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Cambiar Contraseña";
        // 
        // lblUsuarioInfo
        // 
        lblUsuarioInfo.AutoSize = true;
        lblUsuarioInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        lblUsuarioInfo.ForeColor = Color.FromArgb(52, 73, 94);
        lblUsuarioInfo.Location = new Point(22, 55);
        lblUsuarioInfo.Name = "lblUsuarioInfo";
        lblUsuarioInfo.Size = new Size(73, 21);
        lblUsuarioInfo.TabIndex = 1;
        lblUsuarioInfo.Text = "Usuario: -";
        // 
        // lblNuevaClave
        // 
        lblNuevaClave.AutoSize = true;
        lblNuevaClave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblNuevaClave.Location = new Point(22, 95);
        lblNuevaClave.Name = "lblNuevaClave";
        lblNuevaClave.Size = new Size(153, 21);
        lblNuevaClave.TabIndex = 2;
        lblNuevaClave.Text = "Nueva Contraseña:";
        // 
        // txtNuevaClave
        // 
        txtNuevaClave.Font = new Font("Segoe UI", 10F);
        txtNuevaClave.Location = new Point(22, 120);
        txtNuevaClave.MaxLength = 50;
        txtNuevaClave.Name = "txtNuevaClave";
        txtNuevaClave.Size = new Size(320, 30);
        txtNuevaClave.TabIndex = 3;
        txtNuevaClave.UseSystemPasswordChar = true;
        // 
        // lblConfirmarClave
        // 
        lblConfirmarClave.AutoSize = true;
        lblConfirmarClave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblConfirmarClave.Location = new Point(22, 165);
        lblConfirmarClave.Name = "lblConfirmarClave";
        lblConfirmarClave.Size = new Size(183, 21);
        lblConfirmarClave.TabIndex = 4;
        lblConfirmarClave.Text = "Confirmar Contraseña:";
        // 
        // txtConfirmarClave
        // 
        txtConfirmarClave.Font = new Font("Segoe UI", 10F);
        txtConfirmarClave.Location = new Point(22, 190);
        txtConfirmarClave.MaxLength = 50;
        txtConfirmarClave.Name = "txtConfirmarClave";
        txtConfirmarClave.Size = new Size(320, 30);
        txtConfirmarClave.TabIndex = 5;
        txtConfirmarClave.UseSystemPasswordChar = true;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
        btnGuardar.Cursor = Cursors.Hand;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(90, 245);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(120, 38);
        btnGuardar.TabIndex = 6;
        btnGuardar.Text = "Actualizar";
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
        btnCancelar.Font = new Font("Segoe UI", 9.5F);
        btnCancelar.ForeColor = Color.White;
        btnCancelar.Location = new Point(222, 245);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(120, 38);
        btnCancelar.TabIndex = 7;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        // 
        // FrmUsuarioCambiarClave
        // 
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancelar;
        ClientSize = new Size(365, 305);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        Controls.Add(txtConfirmarClave);
        Controls.Add(lblConfirmarClave);
        Controls.Add(txtNuevaClave);
        Controls.Add(lblNuevaClave);
        Controls.Add(lblUsuarioInfo);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmUsuarioCambiarClave";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Actualizar Contraseña";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private Label lblUsuarioInfo;
    private Label lblNuevaClave;
    private TextBox txtNuevaClave;
    private Label lblConfirmarClave;
    private TextBox txtConfirmarClave;
    private Button btnGuardar;
    private Button btnCancelar;
}
