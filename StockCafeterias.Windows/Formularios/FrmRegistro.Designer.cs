namespace StockCafeterias.Windows.Formularios
{
    partial class FrmRegistro
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
            lblTitulo = new Label();
            lblNombres = new Label();
            lblApellidos = new Label();
            lblNombreUsuario = new Label();
            lblContrasena = new Label();
            lblConfirmarContrasena = new Label();
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtNombreUsuario = new TextBox();
            txtContrasena = new TextBox();
            txtConfirmarContrasena = new TextBox();
            btnRegistrar = new Button();
            lnkVolverLogin = new LinkLabel();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(78, 28);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(343, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Crear una cuenta";
            //
            // lblNombres
            //
            lblNombres.AutoSize = true;
            lblNombres.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombres.ForeColor = Color.FromArgb(44, 62, 80);
            lblNombres.Location = new Point(80, 102);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(98, 28);
            lblNombres.TabIndex = 1;
            lblNombres.Text = "Nombres";
            //
            // lblApellidos
            //
            lblApellidos.AutoSize = true;
            lblApellidos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellidos.ForeColor = Color.FromArgb(44, 62, 80);
            lblApellidos.Location = new Point(80, 177);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(100, 28);
            lblApellidos.TabIndex = 2;
            lblApellidos.Text = "Apellidos";
            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.FromArgb(44, 62, 80);
            lblNombreUsuario.Location = new Point(80, 252);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(194, 28);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Nombre de usuario";
            //
            // lblContrasena
            //
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContrasena.ForeColor = Color.FromArgb(44, 62, 80);
            lblContrasena.Location = new Point(78, 327);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(118, 28);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contraseña";
            //
            // lblConfirmarContrasena
            //
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmarContrasena.ForeColor = Color.FromArgb(44, 62, 80);
            lblConfirmarContrasena.Location = new Point(80, 402);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(217, 28);
            lblConfirmarContrasena.TabIndex = 5;
            lblConfirmarContrasena.Text = "Confirmar contraseña";
            //
            // txtNombres
            //
            txtNombres.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(80, 134);
            txtNombres.MaxLength = 50;
            txtNombres.Name = "txtNombres";
            txtNombres.PlaceholderText = "Ingresa tus nombres";
            txtNombres.Size = new Size(340, 34);
            txtNombres.TabIndex = 6;
            //
            // txtApellidos
            //
            txtApellidos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(80, 209);
            txtApellidos.MaxLength = 50;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.PlaceholderText = "Ingresa tus apellidos";
            txtApellidos.Size = new Size(340, 34);
            txtApellidos.TabIndex = 7;
            //
            // txtNombreUsuario
            //
            txtNombreUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreUsuario.Location = new Point(80, 284);
            txtNombreUsuario.MaxLength = 50;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Elige un nombre de usuario";
            txtNombreUsuario.Size = new Size(340, 34);
            txtNombreUsuario.TabIndex = 8;
            //
            // txtContrasena
            //
            txtContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(80, 359);
            txtContrasena.MaxLength = 128;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Ingresa una contraseña";
            txtContrasena.Size = new Size(340, 34);
            txtContrasena.TabIndex = 9;
            txtContrasena.UseSystemPasswordChar = true;
            //
            // txtConfirmarContrasena
            //
            txtConfirmarContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmarContrasena.Location = new Point(80, 434);
            txtConfirmarContrasena.MaxLength = 128;
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PlaceholderText = "Repite tu contraseña";
            txtConfirmarContrasena.Size = new Size(340, 34);
            txtConfirmarContrasena.TabIndex = 10;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            //
            // btnRegistrar
            //
            btnRegistrar.BackColor = Color.FromArgb(41, 128, 185);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(80, 492);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(340, 44);
            btnRegistrar.TabIndex = 11;
            btnRegistrar.Text = "Crear cuenta";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // lnkVolverLogin
            //
            lnkVolverLogin.ActiveLinkColor = Color.FromArgb(31, 97, 141);
            lnkVolverLogin.AutoSize = true;
            lnkVolverLogin.BackColor = Color.Transparent;
            lnkVolverLogin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkVolverLogin.LinkColor = Color.FromArgb(41, 128, 185);
            lnkVolverLogin.Location = new Point(159, 557);
            lnkVolverLogin.Name = "lnkVolverLogin";
            lnkVolverLogin.Size = new Size(198, 28);
            lnkVolverLogin.TabIndex = 12;
            lnkVolverLogin.TabStop = true;
            lnkVolverLogin.Text = "Volver a iniciar sesión";
            lnkVolverLogin.LinkClicked += lnkVolverLogin_LinkClicked;
            //
            // FrmRegistro
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(498, 594);
            Controls.Add(lnkVolverLogin);
            Controls.Add(btnRegistrar);
            Controls.Add(txtConfirmarContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombres);
            Controls.Add(lblConfirmarContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblApellidos);
            Controls.Add(lblNombres);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de usuario - StockCafeterias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombres;
        private Label lblApellidos;
        private Label lblNombreUsuario;
        private Label lblContrasena;
        private Label lblConfirmarContrasena;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtNombreUsuario;
        private TextBox txtContrasena;
        private TextBox txtConfirmarContrasena;
        private Button btnRegistrar;
        private LinkLabel lnkVolverLogin;
    }
}