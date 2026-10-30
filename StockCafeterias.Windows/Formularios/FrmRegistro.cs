using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmRegistro : Form
{
    private readonly UsuarioServicio _usuarioServicio = new();

    public string? NombreUsuarioRegistrado { get; private set; }

    public FrmRegistro()
    {
        InitializeComponent();
    }

    private void btnRegistrar_Click(object sender, EventArgs e)
    {
        string nombres = txtNombres.Text.Trim();
        string apellidos = txtApellidos.Text.Trim();
        string usuario = txtNombreUsuario.Text.Trim();
        string contrasena = txtContrasena.Text;
        string confirmar = txtConfirmarContrasena.Text;

        if (string.IsNullOrWhiteSpace(nombres) ||
            string.IsNullOrWhiteSpace(apellidos) ||
            string.IsNullOrWhiteSpace(usuario) ||
            string.IsNullOrWhiteSpace(contrasena) ||
            string.IsNullOrWhiteSpace(confirmar))
        {
            MessageBox.Show(
                "Complete todos los campos.",
                "Campos obligatorios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (contrasena != confirmar)
        {
            MessageBox.Show(
                "Las contraseñas no coinciden.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtConfirmarContrasena.Clear();
            txtConfirmarContrasena.Focus();
            return;
        }

        try
        {
            btnRegistrar.Enabled = false;

            _usuarioServicio.RegistrarCuenta(
                nombres,
                apellidos,
                usuario,
                contrasena,
                confirmar);

            NombreUsuarioRegistrado = usuario;

            MessageBox.Show(
                "¡Cuenta creada correctamente! " +
                "Ahora puede iniciar sesión.",
                "Registro exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        catch (Microsoft.Data.SqlClient.SqlException ex)
            when (ex.Number is 50010 or 2601 or 2627)
        {
            MessageBox.Show(
                "Este nombre de usuario ya está registrado. " +
                "Por favor, elige otro.",
                "Usuario no disponible",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception)
        {
            MessageBox.Show(
                "No se pudo completar el registro. " +
                "Verifique la conexión con la base de datos.",
                "Error de registro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        finally
        {
            btnRegistrar.Enabled = true;
        }
    }

    private void lnkVolverLogin_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
