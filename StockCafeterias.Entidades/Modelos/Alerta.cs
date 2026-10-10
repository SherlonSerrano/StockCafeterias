using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Alerta
{
    public int IdAlerta { get; set; }

    public int IdStockLocal { get; set; }

    public string TipoAlerta { get; set; } = null!;

    public DateTime FechaAlerta { get; set; }

    public byte Resuelta { get; set; }

    public virtual StockLocal IdStockLocalNavigation { get; set; } = null!;
}
