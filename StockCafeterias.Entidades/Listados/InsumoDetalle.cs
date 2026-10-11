
namespace StockCafeterias.Entidades.Listados;

public class InsumoDetalle
{
    public int IdInsumo { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int IdUnidadMedida { get; set; }
    public string UnidadNombre { get; set; } = null!;
    public string Unidad { get; set; } = null!;
    public decimal StockActual { get; set; }
    public decimal StockMinimo { get; set; }
    public byte Estado { get; set; }
}
