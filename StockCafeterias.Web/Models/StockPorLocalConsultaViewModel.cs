using StockCafeterias.Entidades.Listados;

namespace StockCafeterias.Web.Models;

public class StockPorLocalConsultaViewModel
{
    public int? IdLocal { get; set; }
    public string? Buscar { get; set; }
    public string EstadoFiltro { get; set; } = "todos"; // todos | bajo | sinstock

    public int PaginaActual { get; set; } = 1;
    public int TotalPaginas { get; set; } = 1;
    public int TamanoPagina { get; set; } = 10;

    public int TotalRegistros { get; set; }
    public int TotalNormal { get; set; }
    public int TotalStockBajo { get; set; }
    public int TotalSinStock { get; set; }

    public List<StockPorLocalListado> Registros { get; set; } = new();

    public List<string> GraficoEtiquetas { get; set; } = new();
    public List<int> GraficoNormal { get; set; } = new();
    public List<int> GraficoStockBajo { get; set; } = new();
    public List<int> GraficoSinStock { get; set; } = new();
}
