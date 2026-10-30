
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmLogin : Form
{
    // Guarda los datos del usuario que inició sesión.
    public UsuarioAutenticado? UsuarioActual { get; private set; }

    public FrmLogin()
    {
        InitializeComponent();
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
        string nombreUsuario = txtUsuario.Text.Trim();
        string contrasena = txtContrasena.Text;

        // Verificar que los campos no estén vacíos.
        if (string.IsNullOrWhiteSpace(nombreUsuario) ||
            string.IsNullOrEmpty(contrasena))
        {
            MessageBox.Show(
                "Ingrese su usuario y contraseña.",
                "Campos obligatorios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            btnIngresar.Enabled = false;

            // Consultar las credenciales en SQL Server.
            var servicio = new AutenticacionServicio();

            var usuario = servicio.IniciarSesion(
                nombreUsuario,
                contrasena);

            // Rechazar credenciales incorrectas.
            if (usuario is null)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            // Autenticación exitosa.
            UsuarioActual = usuario;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception)
        {
            MessageBox.Show(
                "No se pudo validar el inicio de sesión. " +
                "Verifique la conexión con la base de datos.",
                "Error de autenticación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnIngresar.Enabled = true;
        }
    }

    private void lnkRegistrarse_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        using var registro = new FrmRegistro();

        if (registro.ShowDialog(this) == DialogResult.OK)
        {
            txtUsuario.Text =
                registro.NombreUsuarioRegistrado ?? string.Empty;

            txtContrasena.Clear();
            txtContrasena.Focus();
        }
    }
}
