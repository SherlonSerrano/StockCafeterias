using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Negocio.Servicios;

public class ProductoServicio
{
    private readonly ProductoRepositorio _repo;

    public ProductoServicio(ProductoRepositorio? repo = null)
    {
        _repo = repo ?? new ProductoRepositorio();
    }

    public List<ProductoListado> Listar(string? buscar = null, byte? estado = null)
    {
        return _repo.Listar(string.IsNullOrWhiteSpace(buscar) ? null : buscar.Trim(), estado);
    }

    public ProductoDetalle? ObtenerPorId(int idProducto)
    {
        if (idProducto <= 0)
            throw new ArgumentException("El identificador del producto no es válido.");

        return _repo.ObtenerPorId(idProducto);
    }

    public int Guardar(Producto producto, string usuario)
    {
        Validar(producto);

        if (string.IsNullOrWhiteSpace(usuario))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        producto.Nombre = producto.Nombre.Trim();

        if (producto.IdProducto == 0)
        {
            producto.IdProducto = _repo.Insertar(producto, usuario.Trim());
            return producto.IdProducto;
        }

        _repo.Actualizar(producto, usuario.Trim());
        return producto.IdProducto;
    }

    public int Eliminar(int idProducto, string usuario)
    {
        if (idProducto <= 0)
            throw new ArgumentException("El identificador del producto no es válido.");

        if (string.IsNullOrWhiteSpace(usuario))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        return _repo.Eliminar(idProducto, usuario.Trim());
    }

    private static void Validar(Producto p)
    {
        if (p == null)
            throw new ArgumentNullException(nameof(p), "Los datos del producto no pueden ser nulos.");

        if (string.IsNullOrWhiteSpace(p.Nombre))
            throw new ArgumentException("El nombre del producto es obligatorio.");

        if (p.Nombre.Trim().Length > 100)
            throw new ArgumentException("El nombre del producto no puede exceder los 100 caracteres.");

        if (p.IdCategoria <= 0)
            throw new ArgumentException("Debe seleccionar una categoría válida.");

        if (p.PrecioVenta <= 0)
            throw new ArgumentException("El precio de venta debe ser mayor a cero.");

        if (p.CostoPromedio < 0)
            throw new ArgumentException("El costo promedio no puede ser negativo.");

        if (p.StockMaximo <= 0)
            throw new ArgumentException("El stock máximo debe ser mayor a cero.");

        if (p.PrecioVenta < p.CostoPromedio)
            throw new ArgumentException("El precio de venta no puede ser menor al costo promedio.");
    }
}
