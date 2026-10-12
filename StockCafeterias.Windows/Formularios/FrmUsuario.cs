using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmUsuario : Form
{
    private readonly UsuarioServicio _usuarioServicio = new();

    public FrmUsuario()
    {
        InitializeComponent();
    }

    private void FrmUsuario_Load(object sender, EventArgs e)
    {
        cboFiltroEstado.SelectedIndex = 0; // "Todos"
        ConfigurarGrilla();
        CargarListado();
    }

    private void ConfigurarGrilla()
    {
        dgvUsuarios.AutoGenerateColumns = false;
        dgvUsuarios.Columns.Clear();

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.IdUsuario),
            HeaderText = "ID",
            FillWeight = 8
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Nombres),
            HeaderText = "Nombres",
            FillWeight = 16
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Apellidos),
            HeaderText = "Apellidos",
            FillWeight = 16
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.NombreUsuario),
            HeaderText = "Usuario",
            FillWeight = 14
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Dni),
            HeaderText = "DNI",
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            FillWeight = 10
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Email),
            HeaderText = "Correo",
            FillWeight = 18
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Rol),
            HeaderText = "Rol",
            FillWeight = 12
        });

        dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(UsuarioListado.Local),
            HeaderText = "Local",
            FillWeight = 16
        });

        var colEstado = new DataGridViewTextBoxColumn
        {
            HeaderText = "Estado",
            FillWeight = 10,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvUsuarios.Columns.Add(colEstado);

        dgvUsuarios.CellFormatting += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colEstado.Index)
            {
                if (dgvUsuarios.Rows[e.RowIndex].DataBoundItem is UsuarioListado u)
                {
                    e.Value = u.Estado == 1 ? "Activo" : "Inactivo";
                    e.CellStyle.ForeColor = u.Estado == 1 ? Color.DarkGreen : Color.DarkRed;
                    e.CellStyle.Font = new Font(dgvUsuarios.Font, FontStyle.Bold);
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

            var usuarios = _usuarioServicio.Listar(buscar, estado);
            dgvUsuarios.DataSource = usuarios;
            lblTotal.Text = $"Total de registros: {usuarios.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        using var frm = new FrmUsuarioEdicion();
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.CurrentRow?.DataBoundItem is not UsuarioListado seleccionado)
        {
            MessageBox.Show("Seleccione un usuario para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmUsuarioEdicion(seleccionado.IdUsuario);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            CargarListado();
        }
    }

    private void btnCambiarClave_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.CurrentRow?.DataBoundItem is not UsuarioListado seleccionado)
        {
            MessageBox.Show("Seleccione un usuario para cambiar la contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var frm = new FrmUsuarioCambiarClave(seleccionado.IdUsuario, seleccionado.NombreUsuario);
        frm.ShowDialog();
    }

    private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditar_Click(sender, EventArgs.Empty);
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.CurrentRow?.DataBoundItem is not UsuarioListado seleccionado)
        {
            MessageBox.Show("Seleccione un usuario para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (seleccionado.Estado == 0)
        {
            MessageBox.Show("El usuario seleccionado ya se encuentra inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirmacion = MessageBox.Show(
            $"¿Está seguro de desactivar al usuario '{seleccionado.NombreUsuario}' ({seleccionado.Nombres} {seleccionado.Apellidos})?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacion == DialogResult.Yes)
        {
            try
            {
                _usuarioServicio.Eliminar(seleccionado.IdUsuario, "admin");
                MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar al usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCerrar_Click(object sender, EventArgs e) => Close();
}
