using System;
using System.Collections.Generic;

namespace StockCafeterias.Entidades.Modelos;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public string? Dni { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public byte[]? Foto { get; set; }

    public int IdRol { get; set; }

    public int? IdLocal { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? UsuarioUltModificacion { get; set; }

    public DateTime? FechaUltModificacion { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<CierreDia> CierreDia { get; set; } = new List<CierreDia>();

    public virtual Local? IdLocalNavigation { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<MovimientoStock> MovimientoStock { get; set; } = new List<MovimientoStock>();
}
