
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Web.Models;

public class MovimientosPorPeriodoConsultaViewModel
{
    // Filtros de búsqueda
    public DateTime FechaInicio { get; set; } =
        DateTime.Today.AddMonths(-3);

    public DateTime FechaFin { get; set; } =
        DateTime.Today;

    public string? Insumo { get; set; }
    public string? Local { get; set; }
    public string TipoMovimiento { get; set; } = "todos";

    // Paginación
    public int PaginaActual { get; set; } = 1;
    public int TotalPaginas { get; set; } = 1;
    public int TamanoPagina { get; set; } = 10;

    // Indicadores
    public int TotalRegistros { get; set; }
    public int TotalEnvios { get; set; }
    public int TotalAjustes { get; set; }
    public int TotalMermas { get; set; }

    // Resultados detallados
    public List<VwMovimientosDetallado> Registros
    { get; set; } = new();

    // Datos del gráfico
    public List<string> GraficoTipos
    { get; set; } = new();

    public List<int> GraficoMovimientos
    { get; set; } = new();
}
