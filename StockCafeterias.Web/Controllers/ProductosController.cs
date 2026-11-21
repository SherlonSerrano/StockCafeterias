using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;
using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Web.Models;

namespace StockCafeterias.Web.Controllers;

public class ProductosController : Controller
{
    private readonly StockCafeteriasContext _context;

    public ProductosController(StockCafeteriasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? buscar, string estado = "todos")
    {
        var query = _context.Producto
            .AsNoTracking()
            .Include(p => p.IdCategoriaNavigation)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim();
            query = query.Where(p => p.Nombre.Contains(texto));
        }

        if (estado == "activos")
            query = query.Where(p => p.Estado == 1);
        else if (estado == "inactivos")
            query = query.Where(p => p.Estado == 0);

        ViewBag.Buscar = buscar;
        ViewBag.Estado = estado;

        var productos = await query.OrderBy(p => p.Nombre).ToListAsync();
        return View(productos);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var producto = await _context.Producto
            .AsNoTracking()
            .Include(p => p.IdCategoriaNavigation)
            .FirstOrDefaultAsync(p => p.IdProducto == id);

        if (producto == null) return NotFound();

        return View(producto);
    }

    public async Task<IActionResult> Create()
    {
        await CargarCategoriasAsync();
        return View(new ProductoFormViewModel { EstadoActivo = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductoFormViewModel vm)
    {
        if (vm.PrecioVenta < vm.CostoPromedio)
        {
            ModelState.AddModelError(nameof(vm.PrecioVenta), "El precio de venta no puede ser menor al costo promedio.");
        }

        if (!ModelState.IsValid)
        {
            await CargarCategoriasAsync(vm.IdCategoria);
            return View(vm);
        }

        byte[]? fotoBytes = null;
        if (vm.ArchivoFoto is { Length: > 0 })
        {
            using var ms = new MemoryStream();
            await vm.ArchivoFoto.CopyToAsync(ms);
            fotoBytes = ms.ToArray();
        }

        var producto = new Producto
        {
            Nombre = vm.Nombre.Trim(),
            IdCategoria = vm.IdCategoria,
            PrecioVenta = vm.PrecioVenta,
            CostoPromedio = vm.CostoPromedio,
            StockMaximo = vm.StockMaximo,
            Foto = fotoBytes,
            Estado = (byte)(vm.EstadoActivo ? 1 : 0),
            UsuarioRegistro = "web-admin",
            FechaRegistro = DateTime.Now
        };

        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Producto '{producto.Nombre}' registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var producto = await _context.Producto.FindAsync(id);
        if (producto == null) return NotFound();

        var vm = new ProductoFormViewModel
        {
            IdProducto = producto.IdProducto,
            Nombre = producto.Nombre,
            IdCategoria = producto.IdCategoria,
            PrecioVenta = producto.PrecioVenta,
            CostoPromedio = producto.CostoPromedio,
            StockMaximo = producto.StockMaximo,
            EstadoActivo = producto.Estado == 1,
            FotoActual = producto.Foto
        };

        await CargarCategoriasAsync(vm.IdCategoria);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductoFormViewModel vm)
    {
        if (id != vm.IdProducto) return NotFound();

        if (vm.PrecioVenta < vm.CostoPromedio)
        {
            ModelState.AddModelError(nameof(vm.PrecioVenta), "El precio de venta no puede ser menor al costo promedio.");
        }

        var producto = await _context.Producto.FindAsync(id);
        if (producto == null) return NotFound();

        if (!ModelState.IsValid)
        {
            vm.FotoActual = producto.Foto;
            await CargarCategoriasAsync(vm.IdCategoria);
            return View(vm);
        }

        if (vm.ArchivoFoto is { Length: > 0 })
        {
            using var ms = new MemoryStream();
            await vm.ArchivoFoto.CopyToAsync(ms);
            producto.Foto = ms.ToArray();
        }

        producto.Nombre = vm.Nombre.Trim();
        producto.IdCategoria = vm.IdCategoria;
        producto.PrecioVenta = vm.PrecioVenta;
        producto.CostoPromedio = vm.CostoPromedio;
        producto.StockMaximo = vm.StockMaximo;
        producto.Estado = (byte)(vm.EstadoActivo ? 1 : 0);
        producto.UsuarioUltModificacion = "web-admin";
        producto.FechaUltModificacion = DateTime.Now;

        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Producto '{producto.Nombre}' actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var producto = await _context.Producto
            .AsNoTracking()
            .Include(p => p.IdCategoriaNavigation)
            .FirstOrDefaultAsync(p => p.IdProducto == id);

        if (producto == null) return NotFound();

        return View(producto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _context.Producto.FindAsync(id);
        if (producto != null)
        {
            producto.Estado = 0;
            producto.UsuarioUltModificacion = "web-admin";
            producto.FechaUltModificacion = DateTime.Now;
            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = $"Producto '{producto.Nombre}' desactivado correctamente.";
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCategoriasAsync(int? seleccionada = null)
    {
        var categorias = await _context.CategoriaProducto
            .AsNoTracking()
            .Where(c => c.Estado == 1)
            .OrderBy(c => c.Nombre)
            .ToListAsync();

        ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre", seleccionada);
    }
}
