
using StockCafeterias.Windows.Formularios;

namespace StockCafeterias.Windows
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Mostrar primero el formulario de login.
            using var login = new FrmLogin();

            // Si no inicia sesión correctamente,
            // no se abre el menú principal.
            if (login.ShowDialog() != DialogResult.OK ||
                login.UsuarioActual is null)
            {
                return;
            }

            // Abrir el menú después de autenticar.
            Application.Run(new FrmMenuPrincipal(login.UsuarioActual));
        }
    }
}
