namespace StockCafeterias.Entidades.Listados;

public class ProductoDetalle
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; } = null!; //Es solo una instrucción para que VS no muestre una advertencia amarilla. Los datos reales llegarán desde la base de datos.
    public int IdCategoria { get; set; }
    public string Categoria { get; set; } = null!;
    public decimal PrecioVenta { get; set; }
    public decimal CostoPromedio { get; set; }
    public int StockMaximo { get; set; }
    public byte[]? Foto { get; set; } //? indica que la foto puede venir vacía, porque un producto puede no tener imagen.
    public byte Estado { get; set; }
}