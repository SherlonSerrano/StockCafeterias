using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmProducto : Form
{
    private readonly ProductoServicio _productoServicio = new();

    public FrmProducto()
    {
        InitializeComponent();
    }

    private void FrmProducto_Load(object sender, EventArgs e)
    {
        cboFiltroEstado.SelectedIndex = 0; // "Todos"
        ConfigurarGrilla();
        CargarListado();
    }

    private void ConfigurarGrilla()
    {
        dgvProductos.AutoGenerateColumns = false;
        dgvProductos.Columns.Clear();

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.IdProducto),
            HeaderText = "ID",
            FillWeight = 10
        });

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.Nombre),
            HeaderText = "Producto",
            FillWeight = 30
        });

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.Categoria),
            HeaderText = "Categoría",
            FillWeight = 20
        });

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.PrecioVenta),
            HeaderText = "Precio (S/)",
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
            FillWeight = 15
        });

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.CostoPromedio),
            HeaderText = "Costo (S/)",
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
            FillWeight = 15
        });

        dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ProductoListado.StockMaximo),
            HeaderText = "Stock Máx.",
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            FillWeight = 12
        });

        var colEstado = new DataGridViewTextBoxColumn
        {
            HeaderText = "Estado",
            FillWeight = 12,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvProductos.Columns.Add(colEstado);

        dgvProductos.CellFormatting += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEstado.Index)
            {
                if (dgvProductos.Rows[e.RowIndex].DataBoundItem is ProductoListado p)
                {
                    e.Value = p.Estado == 1 ? "Activo" : "Inactivo";
                    e.CellStyle.ForeColor = p.Estado == 1 ? Color.DarkGreen : Color.DarkRed;
                    e.CellStyle.Font = new Font(dgvProductos.Font, FontStyle.Bold);
                }
            }
        };
    }

    private void CargarListado()
    {
        try
        {
            string? buscar = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
            byte? estado = cboFiltroEstado.SelectedIndex switch
            {
                1 => 1, // Activo
                2 => 0, // Inactivo
                _ => null // Todos
            };

            var productos = _productoServicio.Listar(buscar, estado);
            dgvProductos.DataSource = productos;
            lblTotal.Text = $"Total de registros: {productos.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnBuscar_Click(object sender, EventArgs e) => CargarListado();

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtBuscar.Clear();
        cboFiltroEstado.SelectedIndex = 0;
        CargarListado();
    }

    private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            CargarListado();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void cboFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => CargarListado();

    private void btnRefrescar_Click(object sender, EventArgs e) => CargarListado();

    private void btnNuevo_Click(object sender, EventArgs e)
    {
        using var frm = new FrmProductoEdicion();
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow?.DataBoundItem is not ProductoListado seleccionado)
        {
            MessageBox.Show("Seleccione un producto para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmProductoEdicion(seleccionado.IdProducto);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditar_Click(sender, EventArgs.Empty);
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.CurrentRow?.DataBoundItem is not ProductoListado seleccionado)
        {
            MessageBox.Show("Seleccione un producto para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (seleccionado.Estado == 0)
        {
            MessageBox.Show("El producto seleccionado ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirmacion = MessageBox.Show(
            $"¿Está seguro de desactivar el producto '{seleccionado.Nombre}'?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                _productoServicio.Eliminar(seleccionado.IdProducto, "admin");
                MessageBox.Show("Producto desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e) => Close();
}
