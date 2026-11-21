using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;
using StockCafeterias.Web.Models;

namespace StockCafeterias.Web.Controllers;

public class HomeController : Controller
{
    private readonly StockCafeteriasContext _context;

    public HomeController(StockCafeteriasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            ViewBag.TotalProductos = await _context.Producto.CountAsync(p => p.Estado == 1);
            ViewBag.TotalInsumos = await _context.Insumo.CountAsync(i => i.Estado == 1);
            ViewBag.TotalUsuarios = await _context.Usuario.CountAsync(u => u.Estado == 1);
            ViewBag.TotalLocales = await _context.Local.CountAsync(l => l.Estado == 1);
        }
        catch
        {
            ViewBag.TotalProductos = 0;
            ViewBag.TotalInsumos = 0;
            ViewBag.TotalUsuarios = 0;
            ViewBag.TotalLocales = 0;
            ViewBag.ErrorConexion = "No se pudo conectar con SQL Server. Verifique la cadena de conexión en appsettings.json.";
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
