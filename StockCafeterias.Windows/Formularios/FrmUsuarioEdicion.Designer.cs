namespace StockCafeterias.Windows.Formularios;

partial class FrmUsuarioEdicion
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
        lblNombres = new Label();
        txtNombres = new TextBox();
        lblApellidos = new Label();
        txtApellidos = new TextBox();
        lblNombreUsuario = new Label();
        txtNombreUsuario = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblDni = new Label();
        txtDni = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblTelefono = new Label();
        txtTelefono = new TextBox();
        lblRol = new Label();
        cboRol = new ComboBox();
        lblLocal = new Label();
        cboLocal = new ComboBox();
        lblFechaNacimiento = new Label();
        dtpFechaNacimiento = new DateTimePicker();
        lblFechaIngreso = new Label();
        dtpFechaIngreso = new DateTimePicker();
        chkActivo = new CheckBox();
        lblFoto = new Label();
        picFoto = new PictureBox();
        btnCargarFoto = new Button();
        btnQuitarFoto = new Button();
        btnGuardar = new Button();
        btnCancelar = new Button();
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
        lblTitulo.Size = new Size(181, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Datos de Usuario";
        // 
        // lblNombres
        // 
        lblNombres.AutoSize = true;
        lblNombres.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblNombres.Location = new Point(26, 70);
        lblNombres.Name = "lblNombres";
        lblNombres.Size = new Size(84, 21);
        lblNombres.TabIndex = 1;
        lblNombres.Text = "Nombres:";
        // 
        // txtNombres
        // 
        txtNombres.Font = new Font("Segoe UI", 10F);
        txtNombres.Location = new Point(26, 95);
        txtNombres.MaxLength = 100;
        txtNombres.Name = "txtNombres";
        txtNombres.Size = new Size(240, 30);
        txtNombres.TabIndex = 2;
        // 
        // lblApellidos
        // 
        lblApellidos.AutoSize = true;
        lblApellidos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblApellidos.Location = new Point(286, 70);
        lblApellidos.Name = "lblApellidos";
        lblApellidos.Size = new Size(86, 21);
        lblApellidos.TabIndex = 3;
        lblApellidos.Text = "Apellidos:";
        // 
        // txtApellidos
        // 
        txtApellidos.Font = new Font("Segoe UI", 10F);
        txtApellidos.Location = new Point(286, 95);
        txtApellidos.MaxLength = 100;
        txtApellidos.Name = "txtApellidos";
        txtApellidos.Size = new Size(240, 30);
        txtApellidos.TabIndex = 4;
        // 
        // lblNombreUsuario
        // 
        lblNombreUsuario.AutoSize = true;
        lblNombreUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblNombreUsuario.Location = new Point(26, 135);
        lblNombreUsuario.Name = "lblNombreUsuario";
        lblNombreUsuario.Size = new Size(160, 21);
        lblNombreUsuario.TabIndex = 5;
        lblNombreUsuario.Text = "Nombre de Usuario:";
        // 
        // txtNombreUsuario
        // 
        txtNombreUsuario.Font = new Font("Segoe UI", 10F);
        txtNombreUsuario.Location = new Point(26, 160);
        txtNombreUsuario.MaxLength = 50;
        txtNombreUsuario.Name = "txtNombreUsuario";
        txtNombreUsuario.Size = new Size(240, 30);
        txtNombreUsuario.TabIndex = 6;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblPassword.Location = new Point(286, 135);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(102, 21);
        lblPassword.TabIndex = 7;
        lblPassword.Text = "Contraseña:";
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.Location = new Point(286, 160);
        txtPassword.MaxLength = 50;
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(240, 30);
        txtPassword.TabIndex = 8;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblDni.Location = new Point(26, 200);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(45, 21);
        lblDni.TabIndex = 9;
        lblDni.Text = "DNI:";
        // 
        // txtDni
        // 
        txtDni.Font = new Font("Segoe UI", 10F);
        txtDni.Location = new Point(26, 225);
        txtDni.MaxLength = 8;
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(150, 30);
        txtDni.TabIndex = 10;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblEmail.Location = new Point(190, 200);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(155, 21);
        lblEmail.TabIndex = 11;
        lblEmail.Text = "Correo Electrónico:";
        // 
        // txtEmail
        // 
        txtEmail.Font = new Font("Segoe UI", 10F);
        txtEmail.Location = new Point(190, 225);
        txtEmail.MaxLength = 100;
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(180, 30);
        txtEmail.TabIndex = 12;
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTelefono.Location = new Point(385, 200);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(82, 21);
        lblTelefono.TabIndex = 13;
        lblTelefono.Text = "Teléfono:";
        // 
        // txtTelefono
        // 
        txtTelefono.Font = new Font("Segoe UI", 10F);
        txtTelefono.Location = new Point(385, 225);
        txtTelefono.MaxLength = 15;
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(141, 30);
        txtTelefono.TabIndex = 14;
        // 
        // lblRol
        // 
        lblRol.AutoSize = true;
        lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblRol.Location = new Point(26, 265);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(128, 21);
        lblRol.TabIndex = 15;
        lblRol.Text = "Rol de Usuario:";
        // 
        // cboRol
        // 
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRol.Font = new Font("Segoe UI", 10F);
        cboRol.FormattingEnabled = true;
        cboRol.Location = new Point(26, 290);
        cboRol.Name = "cboRol";
        cboRol.Size = new Size(240, 29);
        cboRol.TabIndex = 16;
        // 
        // lblLocal
        // 
        lblLocal.AutoSize = true;
        lblLocal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblLocal.Location = new Point(286, 265);
        lblLocal.Name = "lblLocal";
        lblLocal.Size = new Size(134, 21);
        lblLocal.TabIndex = 17;
        lblLocal.Text = "Local Asignado:";
        // 
        // cboLocal
        // 
        cboLocal.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocal.Font = new Font("Segoe UI", 10F);
        cboLocal.FormattingEnabled = true;
        cboLocal.Location = new Point(286, 290);
        cboLocal.Name = "cboLocal";
        cboLocal.Size = new Size(240, 29);
        cboLocal.TabIndex = 18;
        // 
        // lblFechaNacimiento
        // 
        lblFechaNacimiento.AutoSize = true;
        lblFechaNacimiento.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFechaNacimiento.Location = new Point(26, 330);
        lblFechaNacimiento.Name = "lblFechaNacimiento";
        lblFechaNacimiento.Size = new Size(153, 21);
        lblFechaNacimiento.TabIndex = 19;
        lblFechaNacimiento.Text = "Fecha Nacimiento:";
        // 
        // dtpFechaNacimiento
        // 
        dtpFechaNacimiento.Font = new Font("Segoe UI", 10F);
        dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
        dtpFechaNacimiento.Location = new Point(26, 355);
        dtpFechaNacimiento.Name = "dtpFechaNacimiento";
        dtpFechaNacimiento.Size = new Size(240, 30);
        dtpFechaNacimiento.TabIndex = 20;
        // 
        // lblFechaIngreso
        // 
        lblFechaIngreso.AutoSize = true;
        lblFechaIngreso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFechaIngreso.Location = new Point(286, 330);
        lblFechaIngreso.Name = "lblFechaIngreso";
        lblFechaIngreso.Size = new Size(121, 21);
        lblFechaIngreso.TabIndex = 21;
        lblFechaIngreso.Text = "Fecha Ingreso:";
        // 
        // dtpFechaIngreso
        // 
        dtpFechaIngreso.Font = new Font("Segoe UI", 10F);
        dtpFechaIngreso.Format = DateTimePickerFormat.Short;
        dtpFechaIngreso.Location = new Point(286, 355);
        dtpFechaIngreso.Name = "dtpFechaIngreso";
        dtpFechaIngreso.Size = new Size(240, 30);
        dtpFechaIngreso.TabIndex = 22;
        // 
        // chkActivo
        // 
        chkActivo.AutoSize = true;
        chkActivo.Checked = true;
        chkActivo.CheckState = CheckState.Checked;
        chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        chkActivo.Location = new Point(26, 400);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(144, 25);
        chkActivo.TabIndex = 23;
        chkActivo.Text = "Usuario Activo";
        chkActivo.UseVisualStyleBackColor = true;
        // 
        // lblFoto
        // 
        lblFoto.AutoSize = true;
        lblFoto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblFoto.Location = new Point(560, 70);
        lblFoto.Name = "lblFoto";
        lblFoto.Size = new Size(93, 21);
        lblFoto.TabIndex = 24;
        lblFoto.Text = "Fotografía:";
        // 
        // picFoto
        // 
        picFoto.BorderStyle = BorderStyle.FixedSingle;
        picFoto.Location = new Point(560, 95);
        picFoto.Name = "picFoto";
        picFoto.Size = new Size(190, 190);
        picFoto.SizeMode = PictureBoxSizeMode.Zoom;
        picFoto.TabIndex = 25;
        picFoto.TabStop = false;
        // 
        // btnCargarFoto
        // 
        btnCargarFoto.BackColor = Color.FromArgb(236, 240, 241);
        btnCargarFoto.Cursor = Cursors.Hand;
        btnCargarFoto.FlatStyle = FlatStyle.Flat;
        btnCargarFoto.Font = new Font("Segoe UI", 9F);
        btnCargarFoto.Location = new Point(560, 300);
        btnCargarFoto.Name = "btnCargarFoto";
        btnCargarFoto.Size = new Size(90, 32);
        btnCargarFoto.TabIndex = 26;
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
        btnQuitarFoto.Location = new Point(660, 300);
        btnQuitarFoto.Name = "btnQuitarFoto";
        btnQuitarFoto.Size = new Size(90, 32);
        btnQuitarFoto.TabIndex = 27;
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
        btnGuardar.Location = new Point(490, 435);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.TabIndex = 28;
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
        btnCancelar.Location = new Point(625, 435);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(125, 40);
        btnCancelar.TabIndex = 29;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        // 
        // FrmUsuarioEdicion
        // 
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancelar;
        ClientSize = new Size(780, 495);
        Controls.Add(btnCancelar);
        Controls.Add(btnGuardar);
        Controls.Add(btnQuitarFoto);
        Controls.Add(btnCargarFoto);
        Controls.Add(picFoto);
        Controls.Add(lblFoto);
        Controls.Add(chkActivo);
        Controls.Add(dtpFechaIngreso);
        Controls.Add(lblFechaIngreso);
        Controls.Add(dtpFechaNacimiento);
        Controls.Add(lblFechaNacimiento);
        Controls.Add(cboLocal);
        Controls.Add(lblLocal);
        Controls.Add(cboRol);
        Controls.Add(lblRol);
        Controls.Add(txtTelefono);
        Controls.Add(lblTelefono);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtDni);
        Controls.Add(lblDni);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtNombreUsuario);
        Controls.Add(lblNombreUsuario);
        Controls.Add(txtApellidos);
        Controls.Add(lblApellidos);
        Controls.Add(txtNombres);
        Controls.Add(lblNombres);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmUsuarioEdicion";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Formulario de Usuario";
        Load += FrmUsuarioEdicion_Load;
        ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private Label lblNombres;
    private TextBox txtNombres;
    private Label lblApellidos;
    private TextBox txtApellidos;
    private Label lblNombreUsuario;
    private TextBox txtNombreUsuario;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblDni;
    private TextBox txtDni;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblTelefono;
    private TextBox txtTelefono;
    private Label lblRol;
    private ComboBox cboRol;
    private Label lblLocal;
    private ComboBox cboLocal;
    private Label lblFechaNacimiento;
    private DateTimePicker dtpFechaNacimiento;
    private Label lblFechaIngreso;
    private DateTimePicker dtpFechaIngreso;
    private CheckBox chkActivo;
    private Label lblFoto;
    private PictureBox picFoto;
    private Button btnCargarFoto;
    private Button btnQuitarFoto;
    private Button btnGuardar;
    private Button btnCancelar;
}
