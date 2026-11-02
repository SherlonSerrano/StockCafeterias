
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Entidades.Listados;

namespace StockCafeterias.Datos.Repositorios;

public class StockPorLocalRepositorio
{
    public List<StockPorLocalListado> Consultar(
        int? idLocal = null)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<StockPorLocalListado>(
                "EXEC sp_ReporteStockPorLocal @IdLocal",
                new SqlParameter(
                    "@IdLocal",
                    (object?)idLocal ?? DBNull.Value))
            .ToList();
    }
}
