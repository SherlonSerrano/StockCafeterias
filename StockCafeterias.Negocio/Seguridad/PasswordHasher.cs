using System.Security.Cryptography;

namespace StockCafeterias.Negocio.Seguridad;

public static class PasswordHasher
{
    private const int Iteraciones = 600_000;
    private const int TamanoSal = 16;
    private const int TamanoHash = 32;
    private const string Algoritmo = "PBKDF2-SHA256";

    public static string CrearHash(string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        byte[] sal = RandomNumberGenerator.GetBytes(TamanoSal);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            sal,
            Iteraciones,
            HashAlgorithmName.SHA256,
            TamanoHash);

        return $"{Algoritmo}${Iteraciones}$" +
               $"{Convert.ToBase64String(sal)}$" +
               $"{Convert.ToBase64String(hash)}";
    }

    public static bool Verificar(string password, string hashGuardado)
    {
        if (string.IsNullOrEmpty(password) ||
            string.IsNullOrWhiteSpace(hashGuardado))
            return false;

        string[] partes = hashGuardado.Split('$');

        if (partes.Length != 4 ||
            partes[0] != Algoritmo ||
            !int.TryParse(partes[1], out int iteraciones) ||
            iteraciones < 100_000 ||
            iteraciones > 1_000_000)
            return false;

        try
        {
            byte[] sal = Convert.FromBase64String(partes[2]);
            byte[] hashOriginal = Convert.FromBase64String(partes[3]);

            if (sal.Length != TamanoSal ||
                hashOriginal.Length != TamanoHash)
                return false;

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(
                password,
                sal,
                iteraciones,
                HashAlgorithmName.SHA256,
                TamanoHash);

            return CryptographicOperations.FixedTimeEquals(
                hashCalculado,
                hashOriginal);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
