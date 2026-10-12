using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmInsumoEdicion : Form
{
    private readonly InsumoServicio _insumoServicio = new();
    private readonly CatalogoServicio _catalogoServicio = new();
    private readonly int _idInsumo;

    public FrmInsumoEdicion(int idInsumo = 0)
    {
        InitializeComponent();
        _idInsumo = idInsumo;
    }

    private void FrmInsumoEdicion_Load(object sender, EventArgs e)
    {
        try
        {
            CargarUnidadesMedida();

            if (_idInsumo > 0)
            {
                lblTitulo.Text = "Modificar Insumo";
                Text = "Modificar Insumo #" + _idInsumo;
                CargarDatosInsumo();
            }
            else
            {
                lblTitulo.Text = "Nuevo Insumo";
                Text = "Nuevo Insumo";
                chkActivo.Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarUnidadesMedida()
    {
        var unidades = _catalogoServicio.ListarUnidadesMedida();
        cboUnidadMedida.DataSource = unidades;
        cboUnidadMedida.DisplayMember = "Nombre";
        cboUnidadMedida.ValueMember = "IdUnidadMedida";
    }

    private void CargarDatosInsumo()
    {
        var insumo = _insumoServicio.ObtenerPorId(_idInsumo);
        if (insumo == null)
        {
            MessageBox.Show("No se encontró el insumo solicitado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
            return;
        }

        txtDescripcion.Text = insumo.Descripcion;
        cboUnidadMedida.SelectedValue = insumo.IdUnidadMedida;
        nudPrecio.Value = insumo.Precio;
        nudStockMinimo.Value = insumo.StockMinimo;
        chkActivo.Checked = insumo.Estado == 1;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboUnidadMedida.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una unidad de medida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var insumo = new Insumo
            {
                IdInsumo = _idInsumo,
                Descripcion = txtDescripcion.Text,
                IdUnidadMedida = (int)cboUnidadMedida.SelectedValue,
                Precio = nudPrecio.Value,
                StockMinimo = nudStockMinimo.Value,
                Estado = (byte)(chkActivo.Checked ? 1 : 0)
            };

            _insumoServicio.Guardar(insumo, "admin");

            MessageBox.Show("Insumo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
