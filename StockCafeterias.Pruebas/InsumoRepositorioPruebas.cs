using StockCafeterias.Datos;
using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Pruebas;

[TestClass]
public class InsumoRepositorioPruebas
{
    private readonly InsumoRepositorio _repo = new();
    private readonly List<int> _creados = new();

    // Crea un insumo de prueba y lo registra para darlo de baja al terminar
    private int Crear(Insumo insumo)
    {
        int id = _repo.Insertar(insumo, DatosPrueba.UsuarioAuditoria);
        _creados.Add(id);
        return id;
    }

    // El borrado es lógico, así que se desactivan los insumos creados
    // para que no ensucien los listados de los demás.
    [TestCleanup]
    public void Limpiar()
    {
        foreach (int id in _creados)
            _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);
        _creados.Clear();
    }

    // ---------- Listar ----------

    [TestMethod]
    public void Listar_SinFiltros_DevuelveLosInsumosDeLaBase()
    {
        var lista = _repo.Listar();

        Assert.IsTrue(lista.Count > 0, "Debe haber insumos (datos de prueba cargados).");
        Assert.IsTrue(lista.All(i => !string.IsNullOrEmpty(i.Descripcion)));
        Assert.IsTrue(lista.All(i => !string.IsNullOrEmpty(i.Unidad)));
    }

    [TestMethod]
    public void Listar_PorTexto_DevuelveSoloLosQueCoinciden()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoInsumo(token));

        var lista = _repo.Listar(buscar: token);

        Assert.AreEqual(1, lista.Count);
        Assert.AreEqual(id, lista[0].IdInsumo);
        StringAssert.Contains(lista[0].Descripcion, token);
    }

    [TestMethod]
    public void Listar_TextoSinCoincidencias_DevuelveListaVacia()
    {
        var lista = _repo.Listar(buscar: "zzz_" + DatosPrueba.Token());

        Assert.AreEqual(0, lista.Count);
    }

    [TestMethod]
    public void Listar_PorEstado_DevuelveSoloActivosOInactivos()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoInsumo(token));
        _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);

        var activos = _repo.Listar(buscar: token, estado: 1);
        var inactivos = _repo.Listar(buscar: token, estado: 0);

        Assert.AreEqual(0, activos.Count);
        Assert.AreEqual(1, inactivos.Count);
        Assert.AreEqual(0, inactivos[0].Estado);
    }

    // ---------- ObtenerPorId ----------

    [TestMethod]
    public void ObtenerPorId_Existente_DevuelveSusDatos()
    {
        var nuevo = DatosPrueba.NuevoInsumo();
        int id = Crear(nuevo);

        var detalle = _repo.ObtenerPorId(id);

        Assert.IsNotNull(detalle);
        Assert.AreEqual(id, detalle.IdInsumo);
        Assert.AreEqual(nuevo.Descripcion, detalle.Descripcion);
        Assert.AreEqual(nuevo.Precio, detalle.Precio);
        Assert.AreEqual(nuevo.IdUnidadMedida, detalle.IdUnidadMedida);
        Assert.AreEqual("Kilogramo", detalle.UnidadNombre);
        Assert.AreEqual("kg", detalle.Unidad);
        Assert.AreEqual(nuevo.StockMinimo, detalle.StockMinimo);
    }

    [TestMethod]
    public void ObtenerPorId_Inexistente_DevuelveNull()
    {
        var detalle = _repo.ObtenerPorId(DatosPrueba.IdInexistente);

        Assert.IsNull(detalle);
    }

    // ---------- Insertar ----------

    [TestMethod]
    public void Insertar_DevuelveUnIdValido()
    {
        int id = Crear(DatosPrueba.NuevoInsumo());

        Assert.IsTrue(id > 0);
    }

    [TestMethod]
    public void Insertar_ComienzaActivoYConStockEnCero()
    {
        int id = Crear(DatosPrueba.NuevoInsumo());

        var detalle = _repo.ObtenerPorId(id);

        Assert.IsNotNull(detalle);
        Assert.AreEqual((byte)1, detalle.Estado);
        Assert.AreEqual(0m, detalle.StockActual);
    }

    [TestMethod]
    public void Insertar_GuardaElUsuarioQueLoRegistro()
    {
        int id = Crear(DatosPrueba.NuevoInsumo());

        using var db = Conexion.CrearContexto();
        var entidad = db.Insumo.Single(i => i.IdInsumo == id);

        Assert.AreEqual(DatosPrueba.UsuarioAuditoria, entidad.UsuarioRegistro);
    }

    [TestMethod]
    public void Insertar_DosVecesGeneraIdsDistintos()
    {
        int id1 = Crear(DatosPrueba.NuevoInsumo());
        int id2 = Crear(DatosPrueba.NuevoInsumo());

        Assert.AreNotEqual(id1, id2);
    }

    [TestMethod]
    public void Insertar_ConUnidadInexistente_FallaPorLlaveForanea()
    {
        var insumo = DatosPrueba.NuevoInsumo();
        insumo.IdUnidadMedida = DatosPrueba.IdInexistente;

        DatosPrueba.EsperarErrorSql(() => _repo.Insertar(insumo, DatosPrueba.UsuarioAuditoria));
    }

    // ---------- Actualizar ----------

    [TestMethod]
    public void Actualizar_CambiaLosDatos()
    {
        var insumo = DatosPrueba.NuevoInsumo();
        insumo.IdInsumo = Crear(insumo);

        insumo.Descripcion = "Modificado " + DatosPrueba.Token();
        insumo.Precio = 99.90m;
        insumo.IdUnidadMedida = DatosPrueba.IdUnidadMedidaUnidad;
        insumo.StockMinimo = 10m;
        insumo.Estado = 1;
        int filas = _repo.Actualizar(insumo, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(insumo.IdInsumo);
        Assert.AreEqual(1, filas);
        Assert.IsNotNull(detalle);
        Assert.AreEqual(insumo.Descripcion, detalle.Descripcion);
        Assert.AreEqual(99.90m, detalle.Precio);
        Assert.AreEqual(DatosPrueba.IdUnidadMedidaUnidad, detalle.IdUnidadMedida);
        Assert.AreEqual(10m, detalle.StockMinimo);
    }

    [TestMethod]
    public void Actualizar_RegistraUsuarioYFechaDeModificacion()
    {
        var insumo = DatosPrueba.NuevoInsumo();
        insumo.IdInsumo = Crear(insumo);
        insumo.Estado = 1;

        _repo.Actualizar(insumo, "otro_usuario");

        using var db = Conexion.CrearContexto();
        var entidad = db.Insumo.Single(i => i.IdInsumo == insumo.IdInsumo);
        Assert.AreEqual("otro_usuario", entidad.UsuarioUltModificacion);
        Assert.IsNotNull(entidad.FechaUltModificacion);
    }

    [TestMethod]
    public void Actualizar_PuedeReactivarUnInsumoDadoDeBaja()
    {
        var insumo = DatosPrueba.NuevoInsumo();
        insumo.IdInsumo = Crear(insumo);
        _repo.Eliminar(insumo.IdInsumo, DatosPrueba.UsuarioAuditoria);

        insumo.Estado = 1;
        _repo.Actualizar(insumo, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(insumo.IdInsumo);
        Assert.IsNotNull(detalle);
        Assert.AreEqual((byte)1, detalle.Estado);
    }

    [TestMethod]
    public void Actualizar_Inexistente_DevuelveCeroFilas()
    {
        var insumo = DatosPrueba.NuevoInsumo();
        insumo.IdInsumo = DatosPrueba.IdInexistente;
        insumo.Estado = 1;

        int filas = _repo.Actualizar(insumo, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(0, filas);
    }

    // ---------- Eliminar (baja lógica) ----------

    [TestMethod]
    public void Eliminar_HaceBajaLogicaYNoBorraElRegistro()
    {
        int id = Crear(DatosPrueba.NuevoInsumo());

        int filas = _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(id);
        Assert.AreEqual(1, filas);
        Assert.IsNotNull(detalle, "El registro debe seguir existiendo.");
        Assert.AreEqual((byte)0, detalle.Estado);
    }

    [TestMethod]
    public void Eliminar_RegistraQuienLoDioDeBaja()
    {
        int id = Crear(DatosPrueba.NuevoInsumo());

        _repo.Eliminar(id, "quien_elimina");

        using var db = Conexion.CrearContexto();
        var entidad = db.Insumo.Single(i => i.IdInsumo == id);
        Assert.AreEqual("quien_elimina", entidad.UsuarioUltModificacion);
        Assert.IsNotNull(entidad.FechaUltModificacion);
    }

    [TestMethod]
    public void Eliminar_Inexistente_DevuelveCeroFilas()
    {
        int filas = _repo.Eliminar(DatosPrueba.IdInexistente, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(0, filas);
    }
}