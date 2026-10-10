using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class VwAlertasStockActual
{
    public int IdStockLocal { get; set; }

    public string Local { get; set; } = null!;

    public string Insumo { get; set; } = null!;

    public decimal CantidadActual { get; set; }

    public decimal StockMinimo { get; set; }

    public string Unidad { get; set; } = null!;

    public string TipoAlerta { get; set; } = null!;

    public string DescripcionAlerta { get; set; } = null!;
}
