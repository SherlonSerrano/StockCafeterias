using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdCategoria { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal CostoPromedio { get; set; }

    public int StockMaximo { get; set; }

    public byte[]? Foto { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual CategoriaProducto IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
