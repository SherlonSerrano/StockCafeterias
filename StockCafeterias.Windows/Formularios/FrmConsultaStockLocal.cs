
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmConsultaStockLocal : Form
{
    private readonly StockPorLocalServicio _stockServicio = new();
    private readonly CatalogoServicio _catalogoServicio = new();

    public FrmConsultaStockLocal()
    {
        InitializeComponent();

        Load += FrmConsultaStockLocal_Load;
        btnConsultar.Click += btnConsultar_Click;
    }

    private void FrmConsultaStockLocal_Load(
        object? sender, EventArgs e)
    {
        try
        {
            var locales = _catalogoServicio.ListarLocales();

            locales.Insert(0, new LocalItem
            {
                IdLocal = 0,
                Nombre = "Todos los locales"
            });

            cboLocal.DisplayMember = nameof(LocalItem.Nombre);
            cboLocal.ValueMember = nameof(LocalItem.IdLocal);
            cboLocal.DataSource = locales;

            dgvStock.AutoGenerateColumns = true;

            ConsultarStock();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error al iniciar la consulta: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnConsultar_Click(
        object? sender, EventArgs e)
    {
        ConsultarStock();
    }

    private void ConsultarStock()
    {
        try
        {
            int idLocal = cboLocal.SelectedValue is int id
                ? id
                : 0;

            int? filtroLocal = idLocal == 0
                ? null
                : idLocal;

            bool soloStockBajo = chkSoloStockBajo.Checked;

            var registros = _stockServicio.Consultar(
                filtroLocal,
                soloStockBajo);

            dgvStock.DataSource = null;
            dgvStock.DataSource = registros;


            // Crear la columna Estado solo si no existe.
            if (dgvStock.Columns["EstadoStock"] == null)
            {
                dgvStock.Columns.Add(
                    new DataGridViewTextBoxColumn
                    {
                        Name = "EstadoStock",
                        HeaderText = "Estado del stock",
                        ReadOnly = true,
                        FillWeight = 18,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    });
            }

            // Evaluar el stock de cada registro.
            foreach (DataGridViewRow fila in dgvStock.Rows)
            {
                if (fila.DataBoundItem is not StockPorLocalListado item)
                    continue;

                var celda = fila.Cells["EstadoStock"];

                if (item.CantidadActual <= 0)
                {
                    celda.Value = "Sin stock";
                    celda.Style.BackColor =
                        Color.FromArgb(255, 235, 233);
                    celda.Style.ForeColor =
                        Color.FromArgb(192, 57, 43);
                }
                else if (item.CantidadActual <= item.StockMinimo)
                {
                    celda.Value = "Stock bajo";
                    celda.Style.BackColor =
                        Color.FromArgb(255, 243, 224);
                    celda.Style.ForeColor =
                        Color.FromArgb(230, 126, 34);
                }
                else
                {
                    celda.Value = "Normal";
                    celda.Style.BackColor =
                        Color.FromArgb(232, 245, 233);
                    celda.Style.ForeColor =
                        Color.FromArgb(39, 120, 68);
                }

                celda.Style.Font =
                    new Font("Segoe UI", 9, FontStyle.Bold);

                celda.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            // Ocultar columnas técnicas.
            dgvStock.Columns["IdLocal"]!.Visible = false;
            dgvStock.Columns["IdInsumo"]!.Visible = false;
            dgvStock.Columns["FechaUltimoInventario"]!.Visible = false;

            // Encabezados más claros.
            dgvStock.Columns["Local"]!.HeaderText = "Cafetería";
            dgvStock.Columns["Insumo"]!.HeaderText = "Insumo";
            dgvStock.Columns["CantidadActual"]!.HeaderText = "Stock actual";
            dgvStock.Columns["StockMinimo"]!.HeaderText = "Stock mínimo";
            dgvStock.Columns["Unidad"]!.HeaderText = "Unidad";
            dgvStock.Columns["Ubicacion"]!.HeaderText = "Ubicación";

            // Distribuir el ancho de las columnas.
            dgvStock.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStock.Columns["Local"]!.FillWeight = 25;
            dgvStock.Columns["Insumo"]!.FillWeight = 35;
            dgvStock.Columns["CantidadActual"]!.FillWeight = 12;
            dgvStock.Columns["StockMinimo"]!.FillWeight = 12;
            dgvStock.Columns["Unidad"]!.FillWeight = 8;
            dgvStock.Columns["Ubicacion"]!.FillWeight = 12;

            // Mostrar cantidades con dos decimales.
            dgvStock.Columns["CantidadActual"]!
                .DefaultCellStyle.Format = "N2";

            dgvStock.Columns["StockMinimo"]!
                .DefaultCellStyle.Format = "N2";


            lblTotalRegistros.Text =
                $"Registros: {registros.Count}";

            lblStockBajo.Text =
                $"Stock bajo: {registros.Count(x =>
                    x.CantidadActual > 0 &&
                    x.CantidadActual <= x.StockMinimo)}";

            lblSinStock.Text =
                $"Sin stock: {registros.Count(x =>
                    x.CantidadActual == 0)}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error al consultar el inventario: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
