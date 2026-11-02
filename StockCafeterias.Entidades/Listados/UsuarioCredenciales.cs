namespace StockCafeterias.Entidades.Listados;

public class UsuarioCredenciales
{
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int IdRol { get; set; }

    public string Rol { get; set; } = null!;

    public int? IdLocal { get; set; }
}
