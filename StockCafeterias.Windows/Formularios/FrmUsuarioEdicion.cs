using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Negocio.Servicios;
using StockCafeterias.Windows.Utilidades;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmUsuarioEdicion : Form
{
    private readonly UsuarioServicio _usuarioServicio = new();
    private readonly CatalogoServicio _catalogoServicio = new();
    private readonly int _idUsuario;
    private byte[]? _fotoBytes;

    public FrmUsuarioEdicion(int idUsuario = 0)
    {
        InitializeComponent();
        _idUsuario = idUsuario;
    }

    private void FrmUsuarioEdicion_Load(object sender, EventArgs e)
    {
        try
        {
            CargarCatalogos();

            if (_idUsuario > 0)
            {
                lblTitulo.Text = "Modificar Usuario";
                Text = "Modificar Usuario #" + _idUsuario;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                txtNombreUsuario.ReadOnly = true;
                CargarDatosUsuario();
            }
            else
            {
                lblTitulo.Text = "Nuevo Usuario";
                Text = "Nuevo Usuario";
                chkActivo.Visible = false;
                dtpFechaNacimiento.Value = DateTime.Today.AddYears(-20);
                dtpFechaIngreso.Value = DateTime.Today;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarCatalogos()
    {
        var roles = _catalogoServicio.ListarRoles();
        cboRol.DataSource = roles;
        cboRol.DisplayMember = "Nombre";
        cboRol.ValueMember = "IdRol";

        var locales = _catalogoServicio.ListarLocales();
        var listaLocales = new List<LocalItem>
        {
            new LocalItem { IdLocal = 0, Nombre = "(Sin local asignado)" }
        };
        listaLocales.AddRange(locales);

        cboLocal.DataSource = listaLocales;
        cboLocal.DisplayMember = "Nombre";
        cboLocal.ValueMember = "IdLocal";
    }

    private void CargarDatosUsuario()
    {
        var usuario = _usuarioServicio.ObtenerPorId(_idUsuario);
        if (usuario == null)
        {
            MessageBox.Show("No se encontró el usuario solicitado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
            return;
        }

        txtNombres.Text = usuario.Nombres;
        txtApellidos.Text = usuario.Apellidos;
        txtNombreUsuario.Text = usuario.NombreUsuario;
        txtDni.Text = usuario.Dni ?? string.Empty;
        txtEmail.Text = usuario.Email ?? string.Empty;
        txtTelefono.Text = usuario.Telefono ?? string.Empty;
        cboRol.SelectedValue = usuario.IdRol;
        cboLocal.SelectedValue = usuario.IdLocal ?? 0;

        if (usuario.FechaNacimiento.HasValue)
            dtpFechaNacimiento.Value = usuario.FechaNacimiento.Value.ToDateTime(TimeOnly.MinValue);

        dtpFechaIngreso.Value = usuario.FechaIngreso.ToDateTime(TimeOnly.MinValue);
        chkActivo.Checked = usuario.Estado == 1;

        if (usuario.Foto != null && usuario.Foto.Length > 0)
        {
            _fotoBytes = usuario.Foto;
            picFoto.Image = ImagenUtil.BytesAImagen(_fotoBytes);
        }
    }

    private void btnCargarFoto_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
            Title = "Seleccionar fotografía del usuario"
        };

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var bmp = new Bitmap(ofd.FileName);
                picFoto.Image?.Dispose();
                picFoto.Image = new Bitmap(bmp);
                _fotoBytes = ImagenUtil.ImagenABytes(picFoto.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la imagen: {ex.Message}", "Error de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnQuitarFoto_Click(object sender, EventArgs e)
    {
        picFoto.Image?.Dispose();
        picFoto.Image = null;
        _fotoBytes = null;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboRol.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLocalSeleccionado = cboLocal.SelectedValue is int idLoc ? idLoc : 0;

            var usuario = new Usuario
            {
                IdUsuario = _idUsuario,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                NombreUsuario = txtNombreUsuario.Text,
                PasswordHash = txtPassword.Text, // Para nuevos usuarios
                Dni = string.IsNullOrWhiteSpace(txtDni.Text) ? null : txtDni.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                IdRol = (int)cboRol.SelectedValue,
                IdLocal = idLocalSeleccionado > 0 ? idLocalSeleccionado : null,
                FechaNacimiento = DateOnly.FromDateTime(dtpFechaNacimiento.Value),
                FechaIngreso = DateOnly.FromDateTime(dtpFechaIngreso.Value),
                Foto = _fotoBytes,
                Estado = (byte)(chkActivo.Checked ? 1 : 0)
            };

            _usuarioServicio.Guardar(usuario, "admin");

            MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
