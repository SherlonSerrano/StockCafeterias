
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockCafeterias.Negocio.Seguridad;

namespace StockCafeterias.Pruebas;

[TestClass]
public class PasswordHasherPruebas
{
    [TestMethod]
    public void CrearHash_ContrasenaCorrecta_SeVerifica()
    {
        string clave = "PruebaPA3_Segura!2026";

        string hash = PasswordHasher.CrearHash(clave);

        Assert.AreNotEqual(clave, hash);
        Assert.IsTrue(PasswordHasher.Verificar(clave, hash));
    }

    [TestMethod]
    public void Verificar_ContrasenaIncorrecta_DevuelveFalse()
    {
        string hash = PasswordHasher.CrearHash(
            "PruebaPA3_Segura!2026");

        bool resultado = PasswordHasher.Verificar(
            "ContrasenaIncorrecta123", hash);

        Assert.IsFalse(resultado);
    }

    [TestMethod]
    public void CrearHash_MismaContrasena_GeneraHashesDiferentes()
    {
        string clave = "PruebaPA3_Segura!2026";

        string hash1 = PasswordHasher.CrearHash(clave);
        string hash2 = PasswordHasher.CrearHash(clave);

        Assert.AreNotEqual(hash1, hash2);

        Assert.IsTrue(PasswordHasher.Verificar(clave, hash1));
        Assert.IsTrue(PasswordHasher.Verificar(clave, hash2));
    }

    [TestMethod]
    public void Verificar_HashInvalido_DevuelveFalse()
    {
        bool resultado = PasswordHasher.Verificar(
            "PruebaPA3_Segura!2026",
            "HASH_TEMP_000");

        Assert.IsFalse(resultado);
    }
}
