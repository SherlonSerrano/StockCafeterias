using Microsoft.EntityFrameworkCore;
using StockCafeterias.Entidades.Listados;

namespace StockCafeterias.Datos.Repositorios;

public class CatalogoRepositorio
{
    // Lista las categorías de producto activas
    public List<CategoriaItem> ListarCategorias()
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<CategoriaItem>("EXEC sp_CategoriaProducto_Listar")
            .ToList();
    }

    // Lista las unidades de medida activas
    public List<UnidadMedidaItem> ListarUnidadesMedida()
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<UnidadMedidaItem>("EXEC sp_UnidadMedida_Listar")
            .ToList();
    }

    // Lista los roles activos de usuario
    public List<RolItem> ListarRoles()
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<RolItem>("EXEC sp_Rol_Listar")
            .ToList();
    }

    // Lista los locales activos del sistema
    public List<LocalItem> ListarLocales()
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<LocalItem>("EXEC sp_Local_Listar")
            .ToList();
    }
}
