using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Receta
{
    public int IdProducto { get; set; }

    public int IdInsumo { get; set; }

    public decimal CantidadRequerida { get; set; }

    public int IdUnidadMedida { get; set; }

    public byte Estado { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual UnidadMedida IdUnidadMedidaNavigation { get; set; } = null!;
}
