
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Datos.Repositorios;

public class InsumoRepositorio
{
    // Lista los insumos y permite filtrar por nombre o estado
    public List<InsumoListado> Listar(string? buscar = null, byte? estado = null)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<InsumoListado>(
                "EXEC sp_Insumo_Listar @Buscar, @Estado",
                new SqlParameter("@Buscar", (object?)buscar ?? DBNull.Value),
                new SqlParameter("@Estado", (object?)estado ?? DBNull.Value))
            .ToList();
    }

    // Obtiene los datos de un insumo específico
    public InsumoDetalle? ObtenerPorId(int idInsumo)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<InsumoDetalle>(
                "EXEC sp_Insumo_ObtenerPorId @IdInsumo",
                new SqlParameter("@IdInsumo", idInsumo))
            .AsEnumerable()
            .FirstOrDefault();
    }

    // Registra un nuevo insumo y devuelve su ID
    public int Insertar(Insumo i, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<InsumoIdResultado>(
                "EXEC sp_Insumo_Insertar @Descripcion, @Precio, @IdUnidadMedida, @StockMinimo, @Usuario",
                new SqlParameter("@Descripcion", i.Descripcion),
                new SqlParameter("@Precio", i.Precio),
                new SqlParameter("@IdUnidadMedida", i.IdUnidadMedida),
                new SqlParameter("@StockMinimo", i.StockMinimo),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .IdInsumo;
    }

    // Actualiza los datos de un insumo existente
    public int Actualizar(Insumo i, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Insumo_Actualizar @IdInsumo, @Descripcion, @Precio, @IdUnidadMedida, @StockMinimo, @Estado, @Usuario",
                new SqlParameter("@IdInsumo", i.IdInsumo),
                new SqlParameter("@Descripcion", i.Descripcion),
                new SqlParameter("@Precio", i.Precio),
                new SqlParameter("@IdUnidadMedida", i.IdUnidadMedida),
                new SqlParameter("@StockMinimo", i.StockMinimo),
                new SqlParameter("@Estado", i.Estado),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    // Desactiva el insumo sin borrarlo físicamente
    public int Eliminar(int idInsumo, string usuario)
    {
        using var db = Conexion.CrearContexto();

        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Insumo_Eliminar @IdInsumo, @Usuario",
                new SqlParameter("@IdInsumo", idInsumo),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }
}
