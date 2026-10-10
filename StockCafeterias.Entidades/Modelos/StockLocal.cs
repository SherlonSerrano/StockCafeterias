using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class StockLocal
{
    public int IdStockLocal { get; set; }

    public int IdLocal { get; set; }

    public int IdInsumo { get; set; }

    public decimal CantidadActual { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaUltimoInventario { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<Alerta> Alerta { get; set; } = new List<Alerta>();

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual Local IdLocalNavigation { get; set; } = null!;
}
