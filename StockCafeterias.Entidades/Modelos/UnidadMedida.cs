using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class UnidadMedida
{
    public int IdUnidadMedida { get; set; }

    public string Nombre { get; set; } = null!;

    public string Abreviatura { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<Insumo> Insumo { get; set; } = new List<Insumo>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
