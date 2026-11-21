namespace StockCafeterias.Web.Models;

public class AlertaPeriodoResumen
{
    public string Local { get; set; } = string.Empty;
    public string TipoAlerta { get; set; } = string.Empty;
    public int Total { get; set; }
}

public class AlertaDetalleItem
{
    public int IdAlerta { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Insumo { get; set; } = string.Empty;
    public string TipoAlerta { get; set; } = string.Empty;
    public DateTime FechaAlerta { get; set; }
    public bool Resuelta { get; set; }
}

public class AlertasPorPeriodoConsultaViewModel
{
    public DateTime FechaInicio { get; set; } = DateTime.Today.AddMonths(-1);
    public DateTime FechaFin { get; set; } = DateTime.Today;
    public int? IdLocal { get; set; }
    public string TipoAlerta { get; set; } = "todos"; // todos | B | S

    public int PaginaActual { get; set; } = 1;
    public int TotalPaginas { get; set; } = 1;
    public int TamanoPagina { get; set; } = 10;

    public int TotalRegistros { get; set; }
    public int TotalStockBajo { get; set; }
    public int TotalSinStock { get; set; }
    public int TotalResueltas { get; set; }

    public List<AlertaDetalleItem> Registros { get; set; } = new();
    public List<AlertaPeriodoResumen> ResumenProcedimiento { get; set; } = new();

    public List<string> GraficoLocales { get; set; } = new();
    public List<int> GraficoStockBajo { get; set; } = new();
    public List<int> GraficoSinStock { get; set; } = new();
}
