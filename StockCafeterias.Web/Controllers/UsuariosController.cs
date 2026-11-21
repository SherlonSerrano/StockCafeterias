using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;
using StockCafeterias.Entidades.Modelos;
using StockCafeterias.Negocio.Seguridad;
using StockCafeterias.Web.Models;

namespace StockCafeterias.Web.Controllers;

public class UsuariosController : Controller
{
    private readonly StockCafeteriasContext _context;

    public UsuariosController(StockCafeteriasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? buscar, string estado = "todos")
    {
        var query = _context.Usuario
            .AsNoTracking()
            .Include(u => u.IdRolNavigation)
            .Include(u => u.IdLocalNavigation)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim();
            query = query.Where(u =>
                u.Nombres.Contains(texto) ||
                u.Apellidos.Contains(texto) ||
                u.NombreUsuario.Contains(texto));
        }

        if (estado == "activos")
            query = query.Where(u => u.Estado == 1);
        else if (estado == "inactivos")
            query = query.Where(u => u.Estado == 0);

        ViewBag.Buscar = buscar;
        ViewBag.Estado = estado;

        var usuarios = await query
            .OrderBy(u => u.Apellidos)
            .ThenBy(u => u.Nombres)
            .ToListAsync();

        return View(usuarios);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuario
            .AsNoTracking()
            .Include(u => u.IdRolNavigation)
            .Include(u => u.IdLocalNavigation)
            .FirstOrDefaultAsync(u => u.IdUsuario == id);

        if (usuario == null) return NotFound();

        return View(usuario);
    }

    public async Task<IActionResult> Create()
    {
        await CargarCatalogosAsync();
        return View(new UsuarioFormViewModel
        {
            FechaIngreso = DateOnly.FromDateTime(DateTime.Today),
            EstadoActivo = true
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UsuarioFormViewModel vm)
    {
        if (string.IsNullOrWhiteSpace(vm.Password))
        {
            ModelState.AddModelError(nameof(vm.Password), "La contraseña es obligatoria para un usuario nuevo.");
        }

        var nombreUsuarioLimpio = vm.NombreUsuario?.Trim() ?? string.Empty;
        if (!string.IsNullOrEmpty(nombreUsuarioLimpio) &&
            await _context.Usuario.AnyAsync(u => u.NombreUsuario == nombreUsuarioLimpio))
        {
            ModelState.AddModelError(nameof(vm.NombreUsuario), "El nombre de usuario ya se encuentra registrado.");
        }

        var dniLimpio = string.IsNullOrWhiteSpace(vm.Dni) ? null : vm.Dni.Trim();
        if (dniLimpio != null && await _context.Usuario.AnyAsync(u => u.Dni == dniLimpio))
        {
            ModelState.AddModelError(nameof(vm.Dni), "Ya existe un usuario registrado con ese DNI.");
        }

        if (!ModelState.IsValid)
        {
            await CargarCatalogosAsync(vm.IdRol, vm.IdLocal);
            return View(vm);
        }

        var usuario = new Usuario
        {
            Nombres = vm.Nombres.Trim(),
            Apellidos = vm.Apellidos.Trim(),
            NombreUsuario = nombreUsuarioLimpio,
            PasswordHash = PasswordHasher.CrearHash(vm.Password!),
            Email = string.IsNullOrWhiteSpace(vm.Email) ? null : vm.Email.Trim(),
            Dni = dniLimpio,
            Telefono = string.IsNullOrWhiteSpace(vm.Telefono) ? null : vm.Telefono.Trim(),
            FechaNacimiento = vm.FechaNacimiento,
            FechaIngreso = vm.FechaIngreso,
            IdRol = vm.IdRol,
            IdLocal = vm.IdLocal is > 0 ? vm.IdLocal : null,
            Estado = (byte)(vm.EstadoActivo ? 1 : 0),
            UsuarioRegistro = "web-admin",
            FechaRegistro = DateTime.Now
        };

        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Usuario '{usuario.NombreUsuario}' registrado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null) return NotFound();

        var vm = new UsuarioFormViewModel
        {
            IdUsuario = usuario.IdUsuario,
            Nombres = usuario.Nombres,
            Apellidos = usuario.Apellidos,
            NombreUsuario = usuario.NombreUsuario,
            Email = usuario.Email,
            Dni = usuario.Dni,
            Telefono = usuario.Telefono,
            FechaNacimiento = usuario.FechaNacimiento,
            FechaIngreso = usuario.FechaIngreso,
            IdRol = usuario.IdRol,
            IdLocal = usuario.IdLocal,
            EstadoActivo = usuario.Estado == 1
        };

        await CargarCatalogosAsync(vm.IdRol, vm.IdLocal);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UsuarioFormViewModel vm)
    {
        if (id != vm.IdUsuario) return NotFound();

        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null) return NotFound();

        // En edición, la contraseña es opcional (solo se valida si el usuario escribe una nueva).
        if (string.IsNullOrWhiteSpace(vm.Password))
        {
            ModelState.Remove(nameof(vm.Password));
        }

        var dniLimpio = string.IsNullOrWhiteSpace(vm.Dni) ? null : vm.Dni.Trim();
        if (dniLimpio != null &&
            await _context.Usuario.AnyAsync(u => u.Dni == dniLimpio && u.IdUsuario != id))
        {
            ModelState.AddModelError(nameof(vm.Dni), "Ya existe otro usuario registrado con ese DNI.");
        }

        if (!ModelState.IsValid)
        {
            vm.NombreUsuario = usuario.NombreUsuario;
            await CargarCatalogosAsync(vm.IdRol, vm.IdLocal);
            return View(vm);
        }

        usuario.Nombres = vm.Nombres.Trim();
        usuario.Apellidos = vm.Apellidos.Trim();
        usuario.Email = string.IsNullOrWhiteSpace(vm.Email) ? null : vm.Email.Trim();
        usuario.Dni = dniLimpio;
        usuario.Telefono = string.IsNullOrWhiteSpace(vm.Telefono) ? null : vm.Telefono.Trim();
        usuario.FechaNacimiento = vm.FechaNacimiento;
        usuario.FechaIngreso = vm.FechaIngreso;
        usuario.IdRol = vm.IdRol;
        usuario.IdLocal = vm.IdLocal is > 0 ? vm.IdLocal : null;
        usuario.Estado = (byte)(vm.EstadoActivo ? 1 : 0);

        if (!string.IsNullOrWhiteSpace(vm.Password))
        {
            usuario.PasswordHash = PasswordHasher.CrearHash(vm.Password);
        }

        usuario.UsuarioUltModificacion = "web-admin";
        usuario.FechaUltModificacion = DateTime.Now;

        await _context.SaveChangesAsync();

        TempData["MensajeExito"] = $"Usuario '{usuario.NombreUsuario}' actualizado correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var usuario = await _context.Usuario
            .AsNoTracking()
            .Include(u => u.IdRolNavigation)
            .Include(u => u.IdLocalNavigation)
            .FirstOrDefaultAsync(u => u.IdUsuario == id);

        if (usuario == null) return NotFound();

        return View(usuario);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario != null)
        {
            usuario.Estado = 0;
            usuario.UsuarioUltModificacion = "web-admin";
            usuario.FechaUltModificacion = DateTime.Now;
            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = $"Usuario '{usuario.NombreUsuario}' desactivado correctamente.";
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCatalogosAsync(int? rolSeleccionado = null, int? localSeleccionado = null)
    {
        var roles = await _context.Rol
            .AsNoTracking()
            .Where(r => r.Estado == 1)
            .OrderBy(r => r.IdRol)
            .ToListAsync();

        var locales = await _context.Local
            .AsNoTracking()
            .Where(l => l.Estado == 1)
            .OrderBy(l => l.Nombre)
            .ToListAsync();

        ViewBag.Roles = new SelectList(roles, "IdRol", "Nombre", rolSeleccionado);
        ViewBag.Locales = new SelectList(locales, "IdLocal", "Nombre", localSeleccionado);
    }
}
