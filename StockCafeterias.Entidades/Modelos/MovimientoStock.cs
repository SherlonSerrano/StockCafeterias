using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class MovimientoStock
{
    public int IdMovimiento { get; set; }

    public int IdLocal { get; set; }

    public int IdInsumo { get; set; }

    public int IdUsuario { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string? Observacion { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual Local IdLocalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
