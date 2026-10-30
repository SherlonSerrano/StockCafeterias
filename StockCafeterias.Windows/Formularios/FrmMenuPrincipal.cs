
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmMenuPrincipal : Form
{
    private readonly UsuarioAutenticado _usuario;

    public FrmMenuPrincipal(UsuarioAutenticado usuario)
    {
        _usuario = usuario ??
            throw new ArgumentNullException(nameof(usuario));

        InitializeComponent();
    }

    private void FrmMenuPrincipal_Load(object sender, EventArgs e)
    {
        lblStatusFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";

        // Mostrar el usuario que inició sesión realmente.
        lblStatusUsuario.Text =
            $"Usuario activo: {_usuario.NombreUsuario} ({_usuario.Rol})";

        // Permisos según el rol.
        bool esAdministrador = _usuario.IdRol == 1;
        bool puedeMantenerStock = _usuario.IdRol is 1 or 2;

        btnProductos.Enabled = puedeMantenerStock;
        btnInsumos.Enabled = puedeMantenerStock;
        btnUsuarios.Enabled = esAdministrador;

        // Deshabilitar también los botones de las tarjetas.
        btnCardProductos.Enabled = puedeMantenerStock;
        btnCardInsumos.Enabled = puedeMantenerStock;
        btnCardUsuarios.Enabled = esAdministrador;

        // Mostrar en gris las tarjetas sin permiso.
        if (!puedeMantenerStock)
        {
            btnCardProductos.BackColor = Color.LightGray;
            btnCardInsumos.BackColor = Color.LightGray;
        }

        if (!esAdministrador)
        {
            btnCardUsuarios.BackColor = Color.LightGray;
        }

        // Atenuar las opciones del menú lateral.
        btnProductos.ForeColor = puedeMantenerStock
            ? Color.White : Color.LightGray;

        btnInsumos.ForeColor = puedeMantenerStock
            ? Color.White : Color.LightGray;

        btnUsuarios.ForeColor = esAdministrador
            ? Color.White : Color.LightGray;

    }

    private void btnProductos_Click(object sender, EventArgs e)
    {
        if (_usuario.IdRol is not (1 or 2)) return;

        using var frm = new FrmProducto();
        frm.ShowDialog();
    }

    private void btnInsumos_Click(object sender, EventArgs e)
    {
        if (_usuario.IdRol is not (1 or 2)) return;

        using var frm = new FrmInsumo();
        frm.ShowDialog();
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
        if (_usuario.IdRol != 1) return;

        using var frm = new FrmUsuario();
        frm.ShowDialog();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        var resp = MessageBox.Show(
            "¿Desea salir del sistema StockCafeterias?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (resp == DialogResult.Yes)
        {
            Application.Exit();
        }
    }
}
