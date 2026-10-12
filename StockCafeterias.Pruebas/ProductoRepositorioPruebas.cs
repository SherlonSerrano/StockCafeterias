using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Pruebas;

[TestClass]
public class ProductoRepositorioPruebas
{
    private readonly ProductoRepositorio _repo = new();
    private readonly List<int> _creados = new();

    private int Crear(Producto producto)
    {
        int id = _repo.Insertar(producto, DatosPrueba.UsuarioAuditoria);
        _creados.Add(id);
        return id;
    }

    [TestCleanup]
    public void Limpiar()
    {
        foreach (int id in _creados)
            _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);
        _creados.Clear();
    }

    [TestMethod]
    public void Listar_SinFiltros_DevuelveLosProductosDeLaBase()
    {
        var lista = _repo.Listar();

        Assert.IsNotNull(lista);
        Assert.IsTrue(lista.All(p => !string.IsNullOrEmpty(p.Nombre)));
        Assert.IsTrue(lista.All(p => !string.IsNullOrEmpty(p.Categoria)));
    }

    [TestMethod]
    public void Listar_PorTexto_DevuelveSoloLosQueCoinciden()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoProducto(token));

        var lista = _repo.Listar(buscar: token);

        Assert.AreEqual(1, lista.Count);
        Assert.AreEqual(id, lista[0].IdProducto);
        StringAssert.Contains(lista[0].Nombre, token);
    }

    [TestMethod]
    public void Listar_TextoSinCoincidencias_DevuelveListaVacia()
    {
        var lista = _repo.Listar(buscar: "zzz_" + DatosPrueba.Token());

        Assert.AreEqual(0, lista.Count);
    }

    [TestMethod]
    public void ObtenerPorId_Existente_DevuelveDatosCompletos()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoProducto(token));

        var obtenido = _repo.ObtenerPorId(id);

        Assert.IsNotNull(obtenido);
        Assert.AreEqual(id, obtenido.IdProducto);
        StringAssert.Contains(obtenido.Nombre, token);
    }

    [TestMethod]
    public void ObtenerPorId_Inexistente_DevuelveNull()
    {
        var obtenido = _repo.ObtenerPorId(DatosPrueba.IdInexistente);

        Assert.IsNull(obtenido);
    }

    [TestMethod]
    public void Insertar_Valido_CreaProductoYDevuelveId()
    {
        var producto = DatosPrueba.NuevoProducto();

        int id = Crear(producto);

        Assert.IsTrue(id > 0);
        var guardado = _repo.ObtenerPorId(id);
        Assert.IsNotNull(guardado);
        Assert.AreEqual(producto.Nombre, guardado.Nombre);
        Assert.AreEqual(producto.PrecioVenta, guardado.PrecioVenta);
        Assert.AreEqual(producto.CostoPromedio, guardado.CostoPromedio);
        Assert.AreEqual(producto.StockMaximo, guardado.StockMaximo);
    }

    [TestMethod]
    public void Actualizar_Valido_ModificaLosCampos()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoProducto(token));

        var modificado = new Producto
        {
            IdProducto = id,
            Nombre = "Producto editado " + token,
            IdCategoria = DatosPrueba.IdCategoriaPostres,
            PrecioVenta = 35.00m,
            CostoPromedio = 15.00m,
            StockMaximo = 80,
            Foto = null,
            Estado = 1
        };

        int filas = _repo.Actualizar(modificado, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(1, filas);
        var obtenido = _repo.ObtenerPorId(id);
        Assert.IsNotNull(obtenido);
        Assert.AreEqual("Producto editado " + token, obtenido.Nombre);
        Assert.AreEqual(35.00m, obtenido.PrecioVenta);
    }

    [TestMethod]
    public void Eliminar_Valido_CambiaEstadoACero()
    {
        int id = Crear(DatosPrueba.NuevoProducto());

        int filas = _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(1, filas);
        var obtenido = _repo.ObtenerPorId(id);
        Assert.IsNotNull(obtenido);
        Assert.AreEqual((byte)0, obtenido.Estado);
    }
}
