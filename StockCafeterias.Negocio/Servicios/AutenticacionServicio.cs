
using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Seguridad;

namespace StockCafeterias.Negocio.Servicios;

public sealed record UsuarioAutenticado(
    int IdUsuario,
    string NombreCompleto,
    string NombreUsuario,
    int IdRol,
    string Rol,
    int? IdLocal);

public class AutenticacionServicio
{
    private readonly Func<string, UsuarioCredenciales?>
        _obtenerCredenciales;

    public AutenticacionServicio(
        Func<string, UsuarioCredenciales?>? obtenerCredenciales = null)
    {
        _obtenerCredenciales = obtenerCredenciales
            ?? new UsuarioRepositorio().ObtenerCredenciales;
    }

    public UsuarioAutenticado? IniciarSesion(
        string nombreUsuario,
        string contrasena)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario)
            || string.IsNullOrEmpty(contrasena))
        {
            return null;
        }

        var usuario = _obtenerCredenciales(nombreUsuario.Trim());

        if (usuario is null ||
            !PasswordHasher.Verificar(
                contrasena,
                usuario.PasswordHash))
        {
            return null;
        }

        return new UsuarioAutenticado(
            usuario.IdUsuario,
            usuario.NombreCompleto,
            usuario.NombreUsuario,
            usuario.IdRol,
            usuario.Rol,
            usuario.IdLocal);
    }
}
