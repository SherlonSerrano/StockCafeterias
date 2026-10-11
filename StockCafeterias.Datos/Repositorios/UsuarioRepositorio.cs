
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Datos.Repositorios;

public class UsuarioRepositorio
{
    // Lista usuarios y permite filtrar por nombre o estado
    public List<UsuarioListado> Listar(string? buscar = null, byte? estado = null)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<UsuarioListado>(
                "EXEC sp_Usuario_Listar @Buscar, @Estado",
                new SqlParameter("@Buscar", (object?)buscar ?? DBNull.Value),
                new SqlParameter("@Estado", (object?)estado ?? DBNull.Value))
            .ToList();
    }

    // Obtiene los datos de un usuario por su ID
    public UsuarioDetalle? ObtenerPorId(int idUsuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<UsuarioDetalle>(
                "EXEC sp_Usuario_ObtenerPorId @IdUsuario",
                new SqlParameter("@IdUsuario", idUsuario))
            .AsEnumerable()
            .FirstOrDefault();
    }

    // Registra un usuario nuevo y devuelve su ID
    public int Insertar(Usuario u, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<UsuarioIdResultado>(
                "EXEC sp_Usuario_Insertar @Nombres, @Apellidos, @NombreUsuario, @PasswordHash, @Email, @DNI, @Telefono, @FechaNacimiento, @FechaIngreso, @Foto, @IdRol, @IdLocal, @Usuario",
                new SqlParameter("@Nombres", u.Nombres),
                new SqlParameter("@Apellidos", u.Apellidos),
                new SqlParameter("@NombreUsuario", u.NombreUsuario),
                new SqlParameter("@PasswordHash", u.PasswordHash),
                new SqlParameter("@Email", (object?)u.Email ?? DBNull.Value),
                ParametroDni(u.Dni),
                new SqlParameter("@Telefono", (object?)u.Telefono ?? DBNull.Value),
                ParametroFechaNacimiento(u.FechaNacimiento),
                ParametroFechaIngreso(u.FechaIngreso),
                ParametroFoto(u.Foto),
                new SqlParameter("@IdRol", u.IdRol),
                new SqlParameter("@IdLocal", (object?)u.IdLocal ?? DBNull.Value),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .IdUsuario;
    }

    // Actualiza los datos de un usuario existente
    public int Actualizar(Usuario u, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Usuario_Actualizar @IdUsuario, @Nombres, @Apellidos, @Email, @DNI, @Telefono, @FechaNacimiento, @FechaIngreso, @Foto, @IdRol, @IdLocal, @Estado, @Usuario",
                new SqlParameter("@IdUsuario", u.IdUsuario),
                new SqlParameter("@Nombres", u.Nombres),
                new SqlParameter("@Apellidos", u.Apellidos),
                new SqlParameter("@Email", (object?)u.Email ?? DBNull.Value),
                ParametroDni(u.Dni),
                new SqlParameter("@Telefono", (object?)u.Telefono ?? DBNull.Value),
                ParametroFechaNacimiento(u.FechaNacimiento),
                ParametroFechaIngreso(u.FechaIngreso),
                ParametroFoto(u.Foto),
                new SqlParameter("@IdRol", u.IdRol),
                new SqlParameter("@IdLocal", (object?)u.IdLocal ?? DBNull.Value),
                new SqlParameter("@Estado", u.Estado),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    // Desactiva un usuario sin borrarlo físicamente
    public int Eliminar(int idUsuario, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Usuario_Eliminar @IdUsuario, @Usuario",
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    // Cambia el hash de la contraseña de un usuario
    public int CambiarPassword(int idUsuario, string passwordHash, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Usuario_CambiarPassword @IdUsuario, @PasswordHash, @Usuario",
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@PasswordHash", passwordHash),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    // Parámetro especial para DNI, que es CHAR(8) en SQL Server
    private static SqlParameter ParametroDni(string? dni) =>
        new SqlParameter("@DNI", SqlDbType.Char, 8)
        {
            Value = (object?)dni ?? DBNull.Value
        };

    // Parámetro para la fecha de nacimiento, que puede ser NULL
    private static SqlParameter ParametroFechaNacimiento(DateOnly? fecha) =>
        new SqlParameter("@FechaNacimiento", SqlDbType.Date)
        {
            Value = (object?)fecha ?? DBNull.Value
        };

    // Parámetro para la fecha de ingreso
    private static SqlParameter ParametroFechaIngreso(DateOnly fecha) =>
        new SqlParameter("@FechaIngreso", SqlDbType.Date)
        {
            Value = fecha
        };

    // Parámetro para la fotografía, que puede ser NULL
    private static SqlParameter ParametroFoto(byte[]? foto) =>
        new SqlParameter("@Foto", SqlDbType.VarBinary, -1)
        {
            Value = (object?)foto ?? DBNull.Value
        };
}
