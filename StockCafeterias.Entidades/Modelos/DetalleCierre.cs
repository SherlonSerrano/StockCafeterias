using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class DetalleCierre
{
    public int IdDetalleCierre { get; set; }

    public int IdCierreDia { get; set; }

    public int IdInsumo { get; set; }

    public decimal CantidadFinal { get; set; }

    public decimal CantidadEsperada { get; set; }

    public virtual CierreDia IdCierreDiaNavigation { get; set; } = null!;

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}
