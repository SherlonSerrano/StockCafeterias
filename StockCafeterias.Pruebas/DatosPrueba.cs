using Microsoft.Data.SqlClient;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Pruebas;

// Valores y ayudas compartidas por las pruebas de los repositorios.
// Los IDs corresponden a los datos del script 2.Script_datos_de_prueba.txt
public static class DatosPrueba
{
    public const string UsuarioAuditoria = "pruebas";

    public const int IdUnidadMedidaUnidad = 1;    // 'Unidad' (und)
    public const int IdUnidadMedidaKilogramo = 2; // 'Kilogramo' (kg)
    public const int IdRolAdmin = 1;
    public const int IdRolEncargado = 2;
    public const int IdLocalJockey = 1;
    public const int IdCategoriaPostres = 1;
    public const int IdInexistente = int.MaxValue;

    // Texto único para que cada ejecución use datos propios y no choque con otros
    public static string Token() => Guid.NewGuid().ToString("N")[..12];

    // DNI de 8 dígitos que empieza en 9 (los datos de prueba usan 7001xxxx)
    public static string DniUnico() => "9" + Random.Shared.Next(0, 10_000_000).ToString("D7");

    public static Insumo NuevoInsumo(string? token = null) => new()
    {
        Descripcion = "Insumo prueba " + (token ?? Token()),
        Precio = 12.50m,
        IdUnidadMedida = IdUnidadMedidaKilogramo,
        StockMinimo = 4m
    };

    public static Producto NuevoProducto(string? token = null) => new()
    {
        Nombre = "Producto prueba " + (token ?? Token()),
        IdCategoria = IdCategoriaPostres,
        PrecioVenta = 25.00m,
        CostoPromedio = 10.00m,
        StockMaximo = 50,
        Foto = null
    };

    public static Usuario NuevoUsuario(string? token = null)
    {
        token ??= Token();
        return new Usuario
        {
            Nombres = "Nombre " + token,
            Apellidos = "Apellido Prueba",
            NombreUsuario = "t_" + token,
            PasswordHash = "HASH_PRUEBA_" + token,
            Email = $"{token}@prueba.com",
            Dni = DniUnico(),
            Telefono = "999888777",
            FechaNacimiento = new DateOnly(1995, 6, 15),
            FechaIngreso = new DateOnly(2025, 1, 10),
            IdRol = IdRolEncargado,
            IdLocal = IdLocalJockey
        };
    }

    // Ejecuta una acción que debe fallar con un error de SQL Server y devuelve ese error.
    // Sirve para comprobar los THROW de los procedimientos (50010, 50011, etc.).
    public static SqlException EsperarErrorSql(Action accion)
    {
        try
        {
            accion();
        }
        catch (SqlException ex)
        {
            return ex;
        }

        Assert.Fail("Se esperaba una SqlException y la operación terminó sin error.");
        return null!;
    }
}