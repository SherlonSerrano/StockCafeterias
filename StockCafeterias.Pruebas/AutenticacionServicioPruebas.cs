using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Negocio.Seguridad;
using StockCafeterias.Negocio.Servicios;

namespace StockCafeterias.Pruebas;

[TestClass]
[TestCategory("Unitarias")]
public class AutenticacionServicioPruebas
{
    private const string NombreUsuario = "prueba_unitaria_pa3";
    private const string Contrasena = "PruebaUnit#2026!";

    private static UsuarioCredenciales CrearCredenciales()
    {
        return new UsuarioCredenciales
        {
            IdUsuario = 1,
            NombreCompleto = "Usuario Prueba",
            NombreUsuario = NombreUsuario,
            PasswordHash = PasswordHasher.CrearHash(Contrasena),
            IdRol = 3,
            Rol = "Invitado",
            IdLocal = null
        };
    }

    [TestMethod]
    public void Login_ContrasenaCorrecta_PermiteAcceso()
    {
        var credenciales = CrearCredenciales();

        var servicio = new AutenticacionServicio(
            nombre => nombre == NombreUsuario
                ? credenciales
                : null);

        var usuario = servicio.IniciarSesion(
            NombreUsuario,
            Contrasena);

        Assert.IsNotNull(usuario);
        Assert.AreEqual(NombreUsuario, usuario.NombreUsuario);
        Assert.AreEqual("Invitado", usuario.Rol);
        Assert.AreEqual(3, usuario.IdRol);
    }

    [TestMethod]
    public void Login_ContrasenaIncorrecta_RechazaAcceso()
    {
        var credenciales = CrearCredenciales();

        var servicio = new AutenticacionServicio(
            nombre => nombre == NombreUsuario
                ? credenciales
                : null);

        var usuario = servicio.IniciarSesion(
            NombreUsuario,
            "ContrasenaIncorrecta123!");

        Assert.IsNull(usuario);
    }

    [TestMethod]
    public void Login_UsuarioInexistente_RechazaAcceso()
    {
        var servicio = new AutenticacionServicio(
            nombre => null);

        var usuario = servicio.IniciarSesion(
            "usuario_que_no_existe_pa3",
            Contrasena);

        Assert.IsNull(usuario);
    }
}
