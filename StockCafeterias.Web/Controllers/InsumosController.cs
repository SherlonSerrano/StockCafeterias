using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;
using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Web.Models;

namespace StockCafeterias.Web.Controllers;

public class InsumosController : Controller
{
    private readonly StockCafeteriasContext _context;

    public InsumosController(StockCafeteriasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? buscar, string estado = "todos")
    {
        var query = _context.Insumo
            .AsNoTracking()
            .Include(i => i.IdUnidadMedidaNavigation)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim();
            query = query.Where(i => i.Descripcion.Contains(texto));
        }

        if (estado == "activos")
            query = query.Where(i => i.Estado == 1);
        else if (estado == "inactivos")
            query = query.Where(i => i.Estado == 0);

        ViewBag.Buscar = buscar;
        ViewBag.Estado = estado;

        var insumos = await query.OrderBy(i => i.Descripcion).ToListAsync();
        return View(insumos);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var insumo = await _context.Insumo
            .AsNoTracking()
            .Include(i => i.IdUnidadMedidaNavigation)
            .FirstOrDefaultAsync(i => i.IdInsumo == id);

        if (insumo == null) return NotFound();

        return View(insumo);
    }

    public async Task<IActionResult> Create()
    {
        await CargarUnidadesAsync();
        return View(new InsumoFormViewModel { EstadoActivo = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InsumoFormViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            await CargarUnidadesAsync(vm.IdUnidadMedida);
            return View(vm);
        }

        var insumo = new Insumo
        {
            Descripcion = vm.Descripcion.Trim(),
            Precio = vm.Precio,
            IdUnidadMedida = vm.IdUnidadMedida,
            StockActual = 0,
            StockMinimo = vm.StockMinimo,
            Estado = (byte)(vm.EstadoActivo ? 1 : 0),
            UsuarioRegistro = "web-admin",
            FechaRegistro = DateTime.Now
        };

        _context.Insumo.Add(insumo);
        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Insumo '{insumo.Descripcion}' registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var insumo = await _context.Insumo.FindAsync(id);
        if (insumo == null) return NotFound();

        var vm = new InsumoFormViewModel
        {
            IdInsumo = insumo.IdInsumo,
            Descripcion = insumo.Descripcion,
            Precio = insumo.Precio,
            IdUnidadMedida = insumo.IdUnidadMedida,
            StockActual = insumo.StockActual,
            StockMinimo = insumo.StockMinimo,
            EstadoActivo = insumo.Estado == 1
        };

        await CargarUnidadesAsync(vm.IdUnidadMedida);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, InsumoFormViewModel vm)
    {
        if (id != vm.IdInsumo) return NotFound();

        var insumo = await _context.Insumo.FindAsync(id);
        if (insumo == null) return NotFound();

        if (!ModelState.IsValid)
        {
            vm.StockActual = insumo.StockActual;
            await CargarUnidadesAsync(vm.IdUnidadMedida);
            return View(vm);
        }

        insumo.Descripcion = vm.Descripcion.Trim();
        insumo.Precio = vm.Precio;
        insumo.IdUnidadMedida = vm.IdUnidadMedida;
        insumo.StockMinimo = vm.StockMinimo;
        insumo.Estado = (byte)(vm.EstadoActivo ? 1 : 0);
        insumo.UsuarioUltModificacion = "web-admin";
        insumo.FechaUltModificacion = DateTime.Now;

        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Insumo '{insumo.Descripcion}' actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var insumo = await _context.Insumo
            .AsNoTracking()
            .Include(i => i.IdUnidadMedidaNavigation)
            .FirstOrDefaultAsync(i => i.IdInsumo == id);

        if (insumo == null) return NotFound();

        return View(insumo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var insumo = await _context.Insumo.FindAsync(id);
        if (insumo != null)
        {
            insumo.Estado = 0;
            insumo.UsuarioUltModificacion = "web-admin";
            insumo.FechaUltModificacion = DateTime.Now;
            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = $"Insumo '{insumo.Descripcion}' desactivado correctamente.";
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarUnidadesAsync(int? seleccionada = null)
    {
        var unidades = await _context.UnidadMedida
            .AsNoTracking()
            .Where(u => u.Estado == 1)
            .OrderBy(u => u.Nombre)
            .ToListAsync();

        ViewBag.Unidades = new SelectList(unidades, "IdUnidadMedida", "Nombre", seleccionada);
    }
}
