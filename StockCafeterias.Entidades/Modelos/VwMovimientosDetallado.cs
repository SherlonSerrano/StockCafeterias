using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class VwMovimientosDetallado
{
    public int IdMovimiento { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string Local { get; set; } = null!;

    public string Insumo { get; set; } = null!;

    public string? TipoMovimiento { get; set; }

    public decimal Cantidad { get; set; }

    public string Unidad { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string? Observacion { get; set; }
}
