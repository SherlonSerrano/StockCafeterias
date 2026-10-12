using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Negocio.Servicios;

public class UsuarioServicio
{
    private readonly UsuarioRepositorio _repo;

    public UsuarioServicio(UsuarioRepositorio? repo = null)
    {
        _repo = repo ?? new UsuarioRepositorio();
    }

    public List<UsuarioListado> Listar(string? buscar = null, byte? estado = null)
    {
        return _repo.Listar(string.IsNullOrWhiteSpace(buscar) ? null : buscar.Trim(), estado);
    }

    public UsuarioDetalle? ObtenerPorId(int idUsuario)
    {
        if (idUsuario <= 0)
            throw new ArgumentException("El identificador del usuario no es válido.");

        return _repo.ObtenerPorId(idUsuario);
    }

    public int Guardar(Usuario usuario, string usuarioAuditoria)
    {
        Validar(usuario);

        if (string.IsNullOrWhiteSpace(usuarioAuditoria))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        usuario.Nombres = usuario.Nombres.Trim();
        usuario.Apellidos = usuario.Apellidos.Trim();
        usuario.NombreUsuario = usuario.NombreUsuario.Trim();
        if (usuario.Email != null) usuario.Email = usuario.Email.Trim();
        if (usuario.Dni != null) usuario.Dni = usuario.Dni.Trim();
        if (usuario.Telefono != null) usuario.Telefono = usuario.Telefono.Trim();

        if (usuario.IdUsuario == 0)
        {
            if (string.IsNullOrWhiteSpace(usuario.PasswordHash))
                throw new ArgumentException("La contraseña es obligatoria para un usuario nuevo.");

            if (usuario.PasswordHash.Length < 4)
                throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");

            usuario.IdUsuario = _repo.Insertar(usuario, usuarioAuditoria.Trim());
            return usuario.IdUsuario;
        }

        _repo.Actualizar(usuario, usuarioAuditoria.Trim());
        return usuario.IdUsuario;
    }

    public int CambiarPassword(int idUsuario, string nuevaPassword, string usuarioAuditoria)
    {
        if (idUsuario <= 0)
            throw new ArgumentException("El identificador del usuario no es válido.");

        if (string.IsNullOrWhiteSpace(nuevaPassword))
            throw new ArgumentException("La contraseña no puede estar vacía.");

        if (nuevaPassword.Trim().Length < 4)
            throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");

        if (string.IsNullOrWhiteSpace(usuarioAuditoria))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        return _repo.CambiarPassword(idUsuario, nuevaPassword.Trim(), usuarioAuditoria.Trim());
    }

    public int Eliminar(int idUsuario, string usuarioAuditoria)
    {
        if (idUsuario <= 0)
            throw new ArgumentException("El identificador del usuario no es válido.");

        if (string.IsNullOrWhiteSpace(usuarioAuditoria))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        return _repo.Eliminar(idUsuario, usuarioAuditoria.Trim());
    }

    private static void Validar(Usuario u)
    {
        if (u == null)
            throw new ArgumentNullException(nameof(u), "Los datos del usuario no pueden ser nulos.");

        if (string.IsNullOrWhiteSpace(u.Nombres))
            throw new ArgumentException("Los nombres del usuario son obligatorios.");

        if (string.IsNullOrWhiteSpace(u.Apellidos))
            throw new ArgumentException("Los apellidos del usuario son obligatorios.");

        if (string.IsNullOrWhiteSpace(u.NombreUsuario))
            throw new ArgumentException("El nombre de usuario es obligatorio.");

        if (u.NombreUsuario.Trim().Contains(' '))
            throw new ArgumentException("El nombre de usuario no puede contener espacios.");

        if (u.IdRol <= 0)
            throw new ArgumentException("Debe seleccionar un rol válido.");

        if (!string.IsNullOrWhiteSpace(u.Dni))
        {
            var dniLimpio = u.Dni.Trim();
            if (dniLimpio.Length != 8 || !dniLimpio.All(char.IsDigit))
                throw new ArgumentException("El DNI debe tener exactamente 8 dígitos numéricos.");
        }

        if (!string.IsNullOrWhiteSpace(u.Email))
        {
            var emailLimpio = u.Email.Trim();
            if (!emailLimpio.Contains('@') || !emailLimpio.Contains('.'))
                throw new ArgumentException("El formato del correo electrónico no es válido.");
        }
    }
}
