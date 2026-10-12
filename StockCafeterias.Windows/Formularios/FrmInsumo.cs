using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmInsumo : Form
{
    private readonly InsumoServicio _insumoServicio = new();

    public FrmInsumo()
    {
        InitializeComponent();
    }

    private void FrmInsumo_Load(object sender, EventArgs e)
    {
        cboFiltroEstado.SelectedIndex = 0; // "Todos"
        ConfigurarGrilla();
        CargarListado();
    }

    private void ConfigurarGrilla()
    {
        dgvInsumos.AutoGenerateColumns = false;
        dgvInsumos.Columns.Clear();

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.IdInsumo),
            HeaderText = "ID",
            FillWeight = 10
        });

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.Descripcion),
            HeaderText = "Descripción",
            FillWeight = 32
        });

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.Unidad),
            HeaderText = "Unidad",
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            FillWeight = 12
        });

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.Precio),
            HeaderText = "Precio Unit. (S/)",
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
            FillWeight = 15
        });

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.StockActual),
            HeaderText = "Stock Actual",
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
            FillWeight = 15
        });

        dgvInsumos.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(InsumoListado.StockMinimo),
            HeaderText = "Stock Mínimo",
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
            FillWeight = 15
        });

        var colEstado = new DataGridViewTextBoxColumn
        {
            HeaderText = "Estado",
            FillWeight = 12,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvInsumos.Columns.Add(colEstado);

        dgvInsumos.CellFormatting += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEstado.Index)
            {
                if (dgvInsumos.Rows[e.RowIndex].DataBoundItem is InsumoListado ins)
                {
                    e.Value = ins.Estado == 1 ? "Activo" : "Inactivo";
                    e.CellStyle.ForeColor = ins.Estado == 1 ? Color.DarkGreen : Color.DarkRed;
                    e.CellStyle.Font = new Font(dgvInsumos.Font, FontStyle.Bold);
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

            var insumos = _insumoServicio.Listar(buscar, estado);
            dgvInsumos.DataSource = insumos;
            lblTotal.Text = $"Total de registros: {insumos.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar insumos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        using var frm = new FrmInsumoEdicion();
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvInsumos.CurrentRow?.DataBoundItem is not InsumoListado seleccionado)
        {
            MessageBox.Show("Seleccione un insumo para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmInsumoEdicion(seleccionado.IdInsumo);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void dgvInsumos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditar_Click(sender, EventArgs.Empty);
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvInsumos.CurrentRow?.DataBoundItem is not InsumoListado seleccionado)
        {
            MessageBox.Show("Seleccione un insumo para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (seleccionado.Estado == 0)
        {
            MessageBox.Show("El insumo seleccionado ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirmacion = MessageBox.Show(
            $"¿Está seguro de desactivar el insumo '{seleccionado.Descripcion}'?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                _insumoServicio.Eliminar(seleccionado.IdInsumo, "admin");
                MessageBox.Show("Insumo desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar el insumo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e) => Close();
}
