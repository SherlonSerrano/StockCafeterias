namespace StockCafeterias.Windows.Formularios
{
    partial class FrmLogin
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
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            lnkRegistrarse = new LinkLabel();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Location = new Point(72, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(314, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "StockCafeterias";
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(44, 62, 80);
            lblUsuario.Location = new Point(65, 135);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(194, 28);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Nombre de usuario";
            //
            // txtUsuario
            //
            txtUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(65, 175);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Ingresa tu usuario";
            txtUsuario.Size = new Size(320, 34);
            txtUsuario.TabIndex = 2;
            //
            // lblContrasena
            //
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContrasena.ForeColor = Color.FromArgb(44, 62, 80);
            lblContrasena.Location = new Point(65, 235);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(118, 28);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            //
            // txtContrasena
            //
            txtContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(65, 275);
            txtContrasena.MaxLength = 128;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Ingresa tu contraseña";
            txtContrasena.Size = new Size(320, 34);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            //
            // btnIngresar
            //
            btnIngresar.BackColor = Color.FromArgb(41, 128, 185);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(65, 345);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 42);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            //
            // lnkRegistrarse
            //
            lnkRegistrarse.ActiveLinkColor = Color.FromArgb(31, 97, 141);
            lnkRegistrarse.AutoSize = true;
            lnkRegistrarse.BackColor = Color.Transparent;
            lnkRegistrarse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkRegistrarse.LinkColor = Color.FromArgb(41, 128, 185);
            lnkRegistrarse.Location = new Point(95, 410);
            lnkRegistrarse.Name = "lnkRegistrarse";
            lnkRegistrarse.Size = new Size(268, 28);
            lnkRegistrarse.TabIndex = 6;
            lnkRegistrarse.TabStop = true;
            lnkRegistrarse.Text = "¿No tienes cuenta? Regístrate";
            lnkRegistrarse.LinkClicked += lnkRegistrarse_LinkClicked;
            //
            // FrmLogin
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(458, 474);
            Controls.Add(lnkRegistrarse);
            Controls.Add(btnIngresar);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión - StockCafeterias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private LinkLabel lnkRegistrarse;
    }
}