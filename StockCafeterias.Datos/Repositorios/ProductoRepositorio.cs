using System.Data; //Permite usar SqlDbType en el parámetro de la foto
using Microsoft.Data.SqlClient; //Permite usar SqlParameter, que envía datos al procedimiento
using Microsoft.EntityFrameworkCore; //Permite usar SqlQueryRaw, que ejecuta el procedimiento
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Datos.Repositorios;

public class ProductoRepositorio
{
    public List<ProductoListado> Listar(string? buscar = null, byte? estado = null)
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<ProductoListado>(
                "EXEC sp_Producto_Listar @Buscar, @Estado",
                new SqlParameter("@Buscar", (object?)buscar ?? DBNull.Value),
                new SqlParameter("@Estado", (object?)estado ?? DBNull.Value))
            .ToList();
    }

    public ProductoDetalle? ObtenerPorId(int idProducto) //Se usará al abrir un producto para editarlo
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<ProductoDetalle>(
                "EXEC sp_Producto_ObtenerPorId @IdProducto",
                new SqlParameter("@IdProducto", idProducto))
            .AsEnumerable() //Un procedimiento almacenado no se puede combinar con más consultas LINQ, así que se trae el resultado primero y recién ahí se filtra
            .FirstOrDefault();
    }

    public int Insertar(Producto p, string usuario) //Devuelve el id nuevo, se usará en el botón Guardar de un producto nuevo
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<ProductoIdResultado>(
                "EXEC sp_Producto_Insertar @Nombre, @IdCategoria, @PrecioVenta, @CostoPromedio, @StockMaximo, @Foto, @Usuario",
                new SqlParameter("@Nombre", p.Nombre),
                new SqlParameter("@IdCategoria", p.IdCategoria),
                new SqlParameter("@PrecioVenta", p.PrecioVenta),
                new SqlParameter("@CostoPromedio", p.CostoPromedio),
                new SqlParameter("@StockMaximo", p.StockMaximo),
                ParametroFoto(p.Foto),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .IdProducto;
    }

    public int Actualizar(Producto p, string usuario) //Devuelve filas modificadas, se usará en el botón Guardar al editar
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Producto_Actualizar @IdProducto, @Nombre, @IdCategoria, @PrecioVenta, @CostoPromedio, @StockMaximo, @Foto, @Estado, @Usuario",
                new SqlParameter("@IdProducto", p.IdProducto),
                new SqlParameter("@Nombre", p.Nombre),
                new SqlParameter("@IdCategoria", p.IdCategoria),
                new SqlParameter("@PrecioVenta", p.PrecioVenta),
                new SqlParameter("@CostoPromedio", p.CostoPromedio),
                new SqlParameter("@StockMaximo", p.StockMaximo),
                ParametroFoto(p.Foto),
                new SqlParameter("@Estado", p.Estado),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    public int Eliminar(int idProducto, string usuario) //Devuleve filas modificadas, se usará en el botón Eliminar
    {
        using var db = Conexion.CrearContexto();
        return db.Database
            .SqlQueryRaw<ResultadoFilas>(
                "EXEC sp_Producto_Eliminar @IdProducto, @Usuario",
                new SqlParameter("@IdProducto", idProducto),
                new SqlParameter("@Usuario", usuario))
            .AsEnumerable()
            .First()
            .FilasAfectadas;
    }

    //Foto lleva un parámetro especial. Si se enviara un NULL sin indicar el tipo, SQL Server lo tomaría como texto y daría error al convertirlo a varbinary(max)
    private static SqlParameter ParametroFoto(byte[]? foto) =>
        new SqlParameter("@Foto", SqlDbType.VarBinary, -1)
        {
            Value = (object?)foto ?? DBNull.Value
        };
}