using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmUsuarioCambiarClave : Form
{
    private readonly UsuarioServicio _usuarioServicio = new();
    private readonly int _idUsuario;
    private readonly string _nombreUsuario;

    public FrmUsuarioCambiarClave(int idUsuario, string nombreUsuario)
    {
        InitializeComponent();
        _idUsuario = idUsuario;
        _nombreUsuario = nombreUsuario;
        lblUsuarioInfo.Text = $"Usuario: {nombreUsuario} (ID #{idUsuario})";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            string clave = txtNuevaClave.Text;
            string confirmar = txtConfirmarClave.Text;

            if (string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("La contraseña no puede estar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clave.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clave != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usuarioServicio.CambiarPassword(_idUsuario, clave, "admin");

            MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cambiar contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
