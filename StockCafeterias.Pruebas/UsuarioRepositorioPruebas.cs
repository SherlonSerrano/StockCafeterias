using StockCafeterias.Datos;
using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Pruebas;

[TestClass]
public class UsuarioRepositorioPruebas
{
    private readonly UsuarioRepositorio _repo = new();
    private readonly List<int> _creados = new();

    private int Crear(Usuario usuario)
    {
        int id = _repo.Insertar(usuario, DatosPrueba.UsuarioAuditoria);
        _creados.Add(id);
        return id;
    }

    // El borrado es lógico: se desactivan los usuarios creados por las pruebas
    [TestCleanup]
    public void Limpiar()
    {
        foreach (int id in _creados)
            _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);
        _creados.Clear();
    }

    // ---------- Listar ----------

    [TestMethod]
    public void Listar_SinFiltros_DevuelveLosUsuariosDeLaBase()
    {
        var lista = _repo.Listar();

        Assert.IsTrue(lista.Count > 0, "Debe haber usuarios (datos de prueba cargados).");
        Assert.IsTrue(lista.Any(u => u.NombreUsuario == "admin"));
        Assert.IsTrue(lista.All(u => !string.IsNullOrEmpty(u.Rol)));
    }

    [TestMethod]
    public void Listar_PorNombreUsuario_EncuentraAlUsuario()
    {
        string token = DatosPrueba.Token();
        int id = Crear(DatosPrueba.NuevoUsuario(token));

        var lista = _repo.Listar(buscar: token);

        Assert.AreEqual(1, lista.Count);
        Assert.AreEqual(id, lista[0].IdUsuario);
    }

    [TestMethod]
    public void Listar_PorNombresOApellidos_EncuentraAlUsuario()
    {
        string token = DatosPrueba.Token();
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.Nombres = "Nom" + token;
        usuario.Apellidos = "Ape" + token;
        int id = Crear(usuario);

        var porNombres = _repo.Listar(buscar: "Nom" + token);
        var porApellidos = _repo.Listar(buscar: "Ape" + token);

        Assert.AreEqual(id, porNombres.Single().IdUsuario);
        Assert.AreEqual(id, porApellidos.Single().IdUsuario);
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
        int id = Crear(DatosPrueba.NuevoUsuario(token));
        _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);

        var activos = _repo.Listar(buscar: token, estado: 1);
        var inactivos = _repo.Listar(buscar: token, estado: 0);

        Assert.AreEqual(0, activos.Count);
        Assert.AreEqual(1, inactivos.Count);
        Assert.AreEqual((byte)0, inactivos[0].Estado);
    }

    [TestMethod]
    public void Listar_MuestraNombreDelRolYDelLocal()
    {
        string token = DatosPrueba.Token();
        Crear(DatosPrueba.NuevoUsuario(token));

        var fila = _repo.Listar(buscar: token).Single();

        Assert.AreEqual("Encargado de Local", fila.Rol);
        Assert.AreEqual("Cafeteria Jockey Plaza", fila.Local);
    }

    [TestMethod]
    public void Listar_UsuarioSinLocal_TraeLocalNulo()
    {
        string token = DatosPrueba.Token();
        var usuario = DatosPrueba.NuevoUsuario(token);
        usuario.IdRol = DatosPrueba.IdRolAdmin;
        usuario.IdLocal = null;
        Crear(usuario);

        var fila = _repo.Listar(buscar: token).Single();

        Assert.IsNull(fila.IdLocal);
        Assert.IsNull(fila.Local);
    }

    // ---------- ObtenerPorId ----------

    [TestMethod]
    public void ObtenerPorId_Existente_DevuelveSusDatos()
    {
        var nuevo = DatosPrueba.NuevoUsuario();
        int id = Crear(nuevo);

        var detalle = _repo.ObtenerPorId(id);

        Assert.IsNotNull(detalle);
        Assert.AreEqual(id, detalle.IdUsuario);
        Assert.AreEqual(nuevo.Nombres, detalle.Nombres);
        Assert.AreEqual(nuevo.Apellidos, detalle.Apellidos);
        Assert.AreEqual(nuevo.NombreUsuario, detalle.NombreUsuario);
        Assert.AreEqual(nuevo.Email, detalle.Email);
        Assert.AreEqual(nuevo.Dni, detalle.Dni);
        Assert.AreEqual(nuevo.Telefono, detalle.Telefono);
        Assert.AreEqual(nuevo.FechaNacimiento, detalle.FechaNacimiento);
        Assert.AreEqual(nuevo.FechaIngreso, detalle.FechaIngreso);
        Assert.AreEqual(nuevo.IdRol, detalle.IdRol);
        Assert.AreEqual(nuevo.IdLocal, detalle.IdLocal);
        Assert.AreEqual((byte)1, detalle.Estado);
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
        int id = Crear(DatosPrueba.NuevoUsuario());

        Assert.IsTrue(id > 0);
    }

    [TestMethod]
    public void Insertar_GuardaLaFoto()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.Foto = new byte[] { 1, 2, 3, 4, 5, 250, 251 };
        int id = Crear(usuario);

        var detalle = _repo.ObtenerPorId(id);

        Assert.IsNotNull(detalle);
        CollectionAssert.AreEqual(usuario.Foto, detalle.Foto);
    }

    [TestMethod]
    public void Insertar_SoloConDatosObligatorios_AceptaOpcionalesNulos()
    {
        var usuario = new Usuario
        {
            Nombres = "Minimo",
            Apellidos = "Obligatorio",
            NombreUsuario = "t_" + DatosPrueba.Token(),
            PasswordHash = "HASH_PRUEBA",
            FechaIngreso = new DateOnly(2025, 2, 1),
            IdRol = DatosPrueba.IdRolAdmin
        };
        int id = Crear(usuario);

        var detalle = _repo.ObtenerPorId(id);

        Assert.IsNotNull(detalle);
        Assert.IsNull(detalle.Email);
        Assert.IsNull(detalle.Dni);
        Assert.IsNull(detalle.Telefono);
        Assert.IsNull(detalle.FechaNacimiento);
        Assert.IsNull(detalle.Foto);
        Assert.IsNull(detalle.IdLocal);
    }

    [TestMethod]
    public void Insertar_GuardaElUsuarioQueLoRegistro()
    {
        int id = Crear(DatosPrueba.NuevoUsuario());

        using var db = Conexion.CrearContexto();
        var entidad = db.Usuario.Single(u => u.IdUsuario == id);

        Assert.AreEqual(DatosPrueba.UsuarioAuditoria, entidad.UsuarioRegistro);
    }

    [TestMethod]
    public void Insertar_NombreUsuarioRepetido_LanzaError50010()
    {
        var primero = DatosPrueba.NuevoUsuario();
        Crear(primero);

        var repetido = DatosPrueba.NuevoUsuario();
        repetido.NombreUsuario = primero.NombreUsuario;

        var error = DatosPrueba.EsperarErrorSql(
            () => _repo.Insertar(repetido, DatosPrueba.UsuarioAuditoria));

        Assert.AreEqual(50010, error.Number);
    }

    [TestMethod]
    public void Insertar_DniRepetido_LanzaError50011()
    {
        var primero = DatosPrueba.NuevoUsuario();
        Crear(primero);

        var repetido = DatosPrueba.NuevoUsuario();
        repetido.Dni = primero.Dni;

        var error = DatosPrueba.EsperarErrorSql(
            () => _repo.Insertar(repetido, DatosPrueba.UsuarioAuditoria));

        Assert.AreEqual(50011, error.Number);
    }

    [TestMethod]
    public void Insertar_ConRolInexistente_FallaPorLlaveForanea()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdRol = DatosPrueba.IdInexistente;

        DatosPrueba.EsperarErrorSql(() => _repo.Insertar(usuario, DatosPrueba.UsuarioAuditoria));
    }

    // ---------- Actualizar ----------

    [TestMethod]
    public void Actualizar_CambiaLosDatos()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdUsuario = Crear(usuario);

        usuario.Nombres = "Cambiado";
        usuario.Apellidos = "Nuevo Apellido";
        usuario.Email = "cambiado@prueba.com";
        usuario.Dni = DatosPrueba.DniUnico();
        usuario.Telefono = "911222333";
        usuario.FechaNacimiento = new DateOnly(1990, 1, 20);
        usuario.FechaIngreso = new DateOnly(2025, 5, 5);
        usuario.IdRol = DatosPrueba.IdRolAdmin;
        usuario.IdLocal = null;
        usuario.Estado = 1;
        int filas = _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(usuario.IdUsuario);
        Assert.AreEqual(1, filas);
        Assert.IsNotNull(detalle);
        Assert.AreEqual("Cambiado", detalle.Nombres);
        Assert.AreEqual("Nuevo Apellido", detalle.Apellidos);
        Assert.AreEqual("cambiado@prueba.com", detalle.Email);
        Assert.AreEqual(usuario.Dni, detalle.Dni);
        Assert.AreEqual("911222333", detalle.Telefono);
        Assert.AreEqual(new DateOnly(1990, 1, 20), detalle.FechaNacimiento);
        Assert.AreEqual(new DateOnly(2025, 5, 5), detalle.FechaIngreso);
        Assert.AreEqual(DatosPrueba.IdRolAdmin, detalle.IdRol);
        Assert.IsNull(detalle.IdLocal);
    }

    [TestMethod]
    public void Actualizar_NoCambiaElNombreDeUsuarioNiLaClave()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        string nombreUsuarioOriginal = usuario.NombreUsuario;
        string hashOriginal = usuario.PasswordHash;
        usuario.IdUsuario = Crear(usuario);

        usuario.NombreUsuario = "intento_cambio";
        usuario.PasswordHash = "intento_cambio";
        usuario.Estado = 1;
        _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        using var db = Conexion.CrearContexto();
        var entidad = db.Usuario.Single(u => u.IdUsuario == usuario.IdUsuario);
        Assert.AreEqual(nombreUsuarioOriginal, entidad.NombreUsuario);
        Assert.AreEqual(hashOriginal, entidad.PasswordHash);
    }

    [TestMethod]
    public void Actualizar_SinFoto_ConservaLaFotoActual()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.Foto = new byte[] { 9, 8, 7 };
        usuario.IdUsuario = Crear(usuario);

        usuario.Foto = null;
        usuario.Estado = 1;
        _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(usuario.IdUsuario);
        Assert.IsNotNull(detalle);
        CollectionAssert.AreEqual(new byte[] { 9, 8, 7 }, detalle.Foto);
    }

    [TestMethod]
    public void Actualizar_ConNuevaFoto_ReemplazaLaAnterior()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.Foto = new byte[] { 1, 1, 1 };
        usuario.IdUsuario = Crear(usuario);

        usuario.Foto = new byte[] { 2, 2, 2, 2 };
        usuario.Estado = 1;
        _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(usuario.IdUsuario);
        Assert.IsNotNull(detalle);
        CollectionAssert.AreEqual(new byte[] { 2, 2, 2, 2 }, detalle.Foto);
    }

    [TestMethod]
    public void Actualizar_DniDeOtroUsuario_LanzaError50011()
    {
        var otro = DatosPrueba.NuevoUsuario();
        Crear(otro);

        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdUsuario = Crear(usuario);
        usuario.Dni = otro.Dni;
        usuario.Estado = 1;

        var error = DatosPrueba.EsperarErrorSql(
            () => _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria));

        Assert.AreEqual(50011, error.Number);
    }

    [TestMethod]
    public void Actualizar_ConSuPropioDni_NoDaError()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdUsuario = Crear(usuario);
        usuario.Estado = 1;

        int filas = _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(1, filas);
    }

    [TestMethod]
    public void Actualizar_RegistraUsuarioYFechaDeModificacion()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdUsuario = Crear(usuario);
        usuario.Estado = 1;

        _repo.Actualizar(usuario, "otro_usuario");

        using var db = Conexion.CrearContexto();
        var entidad = db.Usuario.Single(u => u.IdUsuario == usuario.IdUsuario);
        Assert.AreEqual("otro_usuario", entidad.UsuarioUltModificacion);
        Assert.IsNotNull(entidad.FechaUltModificacion);
    }

    [TestMethod]
    public void Actualizar_Inexistente_DevuelveCeroFilas()
    {
        var usuario = DatosPrueba.NuevoUsuario();
        usuario.IdUsuario = DatosPrueba.IdInexistente;
        usuario.Estado = 1;

        int filas = _repo.Actualizar(usuario, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(0, filas);
    }

    // ---------- Eliminar (baja lógica) ----------

    [TestMethod]
    public void Eliminar_HaceBajaLogicaYNoBorraElRegistro()
    {
        int id = Crear(DatosPrueba.NuevoUsuario());

        int filas = _repo.Eliminar(id, DatosPrueba.UsuarioAuditoria);

        var detalle = _repo.ObtenerPorId(id);
        Assert.AreEqual(1, filas);
        Assert.IsNotNull(detalle, "El registro debe seguir existiendo.");
        Assert.AreEqual((byte)0, detalle.Estado);
    }

    [TestMethod]
    public void Eliminar_Inexistente_DevuelveCeroFilas()
    {
        int filas = _repo.Eliminar(DatosPrueba.IdInexistente, DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(0, filas);
    }

    // ---------- CambiarPassword ----------

    [TestMethod]
    public void CambiarPassword_ActualizaElHash()
    {
        int id = Crear(DatosPrueba.NuevoUsuario());
        string nuevoHash = "NUEVO_HASH_" + DatosPrueba.Token();

        int filas = _repo.CambiarPassword(id, nuevoHash, DatosPrueba.UsuarioAuditoria);

        using var db = Conexion.CrearContexto();
        var entidad = db.Usuario.Single(u => u.IdUsuario == id);
        Assert.AreEqual(1, filas);
        Assert.AreEqual(nuevoHash, entidad.PasswordHash);
    }

    [TestMethod]
    public void CambiarPassword_RegistraQuienHizoElCambio()
    {
        int id = Crear(DatosPrueba.NuevoUsuario());

        _repo.CambiarPassword(id, "OTRO_HASH", "quien_cambia");

        using var db = Conexion.CrearContexto();
        var entidad = db.Usuario.Single(u => u.IdUsuario == id);
        Assert.AreEqual("quien_cambia", entidad.UsuarioUltModificacion);
        Assert.IsNotNull(entidad.FechaUltModificacion);
    }

    [TestMethod]
    public void CambiarPassword_Inexistente_DevuelveCeroFilas()
    {
        int filas = _repo.CambiarPassword(DatosPrueba.IdInexistente, "HASH", DatosPrueba.UsuarioAuditoria);

        Assert.AreEqual(0, filas);
    }
}