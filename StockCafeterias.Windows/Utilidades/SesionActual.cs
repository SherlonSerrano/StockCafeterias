
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Windows.Utilidades;

public static class SesionActual
{
    public static UsuarioAutenticado? Usuario { get; private set; }

    public static string NombreUsuario =>
        Usuario?.NombreUsuario
        ?? throw new InvalidOperationException(
            "No hay un usuario autenticado.");

    public static void Iniciar(UsuarioAutenticado usuario)
    {
        ArgumentNullException.ThrowIfNull(usuario);
        Usuario = usuario;
    }

    public static void Cerrar()
    {
        Usuario = null;
    }
}
