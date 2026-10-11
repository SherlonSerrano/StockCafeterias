
namespace StockCafeterias.Entidades.Listados;

public class UsuarioDetalle
{
    public int IdUsuario { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string? Email { get; set; }
    public string? Dni { get; set; }
    public string? Telefono { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public byte[]? Foto { get; set; }
    public int IdRol { get; set; }
    public string Rol { get; set; } = null!;
    public int? IdLocal { get; set; }
    public string? Local { get; set; }
    public byte Estado { get; set; }
}
