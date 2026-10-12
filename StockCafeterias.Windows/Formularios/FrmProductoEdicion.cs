using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Negocio.Servicios;
using StockCafeterias.Windows.Utilidades;

namespace StockCafeterias.Windows.Formularios;

public partial class FrmProductoEdicion : Form
{
    private readonly ProductoServicio _productoServicio = new();
    private readonly CatalogoServicio _catalogoServicio = new();
    private readonly int _idProducto;
    private byte[]? _fotoBytes;

    public FrmProductoEdicion(int idProducto = 0)
    {
        InitializeComponent();
        _idProducto = idProducto;
    }

    private void FrmProductoEdicion_Load(object sender, EventArgs e)
    {
        try
        {
            CargarCategorias();

            if (_idProducto > 0)
            {
                lblTitulo.Text = "Modificar Producto";
                Text = "Modificar Producto #" + _idProducto;
                CargarDatosProducto();
            }
            else
            {
                lblTitulo.Text = "Nuevo Producto";
                Text = "Nuevo Producto";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarCategorias()
    {
        var categorias = _catalogoServicio.ListarCategorias();
        cboCategoria.DataSource = categorias;
        cboCategoria.DisplayMember = "Nombre";
        cboCategoria.ValueMember = "IdCategoria";
    }

    private void CargarDatosProducto()
    {
        var producto = _productoServicio.ObtenerPorId(_idProducto);
        if (producto == null)
        {
            MessageBox.Show("No se encontró el producto solicitado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
            return;
        }

        txtNombre.Text = producto.Nombre;
        cboCategoria.SelectedValue = producto.IdCategoria;
        nudPrecioVenta.Value = producto.PrecioVenta;
        nudCostoPromedio.Value = producto.CostoPromedio;
        nudStockMaximo.Value = producto.StockMaximo;
        chkActivo.Checked = producto.Estado == 1;

        if (producto.Foto != null && producto.Foto.Length > 0)
        {
            _fotoBytes = producto.Foto;
            picFoto.Image = ImagenUtil.BytesAImagen(_fotoBytes);
        }
    }

    private void btnCargarFoto_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
            Title = "Seleccionar fotografía del producto"
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
            if (cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = new Producto
            {
                IdProducto = _idProducto,
                Nombre = txtNombre.Text,
                IdCategoria = (int)cboCategoria.SelectedValue,
                PrecioVenta = nudPrecioVenta.Value,
                CostoPromedio = nudCostoPromedio.Value,
                StockMaximo = (int)nudStockMaximo.Value,
                Foto = _fotoBytes,
                Estado = (byte)(chkActivo.Checked ? 1 : 0)
            };

            _productoServicio.Guardar(producto, "admin");

            MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
