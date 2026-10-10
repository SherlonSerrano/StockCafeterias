using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class CierreDia
{
    public int IdCierreDia { get; set; }

    public int IdLocal { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaCierre { get; set; }

    public string? Observacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<DetalleCierre> DetalleCierre { get; set; } = new List<DetalleCierre>();

    public virtual Local IdLocalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
