using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;

namespace StockCafeterias.Datos;

public static class Conexion
{
    public static string Cadena { get; set; } =
        "Server=localhost;Database=StockCafeterias;Trusted_Connection=True;TrustServerCertificate=True;";

    public static StockCafeteriasContext CrearContexto()
    {
        var opciones = new DbContextOptionsBuilder<StockCafeteriasContext>()
            .UseSqlServer(Cadena)
            .Options;
        return new StockCafeteriasContext(opciones);
    }
}