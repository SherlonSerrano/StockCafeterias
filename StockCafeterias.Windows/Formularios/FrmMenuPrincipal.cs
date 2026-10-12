namespace StockCafeterias.Windows.Formularios;

public partial class FrmMenuPrincipal : Form
{
    public FrmMenuPrincipal()
    {
        InitializeComponent();
    }

    private void FrmMenuPrincipal_Load(object sender, EventArgs e)
    {
        lblStatusFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
        lblStatusUsuario.Text = "Usuario activo: admin (Administrador)";
    }

    private void btnProductos_Click(object sender, EventArgs e)
    {
        using var frm = new FrmProducto();
        frm.ShowDialog();
    }

    private void btnInsumos_Click(object sender, EventArgs e)
    {
        using var frm = new FrmInsumo();
        frm.ShowDialog();
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
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
