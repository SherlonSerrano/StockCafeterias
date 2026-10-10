using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class CategoriaProducto
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
