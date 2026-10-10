using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int IdUnidadMedida { get; set; }

    public decimal StockActual { get; set; }

    public decimal StockMinimo { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<DetalleCierre> DetalleCierre { get; set; } = new List<DetalleCierre>();

    public virtual UnidadMedida IdUnidadMedidaNavigation { get; set; } = null!;

    public virtual ICollection<MovimientoStock> MovimientoStock { get; set; } = new List<MovimientoStock>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    public virtual ICollection<StockLocal> StockLocal { get; set; } = new List<StockLocal>();
}
