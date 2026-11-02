
namespace StockCafeterias.Entidades.Listados;

public class StockPorLocalListado
{
    public int IdLocal { get; set; }

    public string Local { get; set; } = null!;

    public int IdInsumo { get; set; }

    public string Insumo { get; set; } = null!;

    public decimal CantidadActual { get; set; }

    public string Unidad { get; set; } = null!;

    public decimal StockMinimo { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaUltimoInventario { get; set; }
}
