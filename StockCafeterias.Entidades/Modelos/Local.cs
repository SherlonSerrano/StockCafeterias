using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Local
{
    public int IdLocal { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public TimeOnly HorarioApertura { get; set; }

    public TimeOnly HorarioCierre { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<CierreDia> CierreDia { get; set; } = new List<CierreDia>();

    public virtual ICollection<MovimientoStock> MovimientoStock { get; set; } = new List<MovimientoStock>();

    public virtual ICollection<StockLocal> StockLocal { get; set; } = new List<StockLocal>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
