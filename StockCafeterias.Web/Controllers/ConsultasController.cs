using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos.Contexto;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Web.Models;

namespace StockCafeterias.Web.Controllers;

public class ConsultasController : Controller
{
    private readonly StockCafeteriasContext _context;

    public ConsultasController(StockCafeteriasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> StockPorLocal(
        int? idLocal,
        string? buscar,
        string estadoFiltro = "todos",
        int pagina = 1)
    {
        const int tamanoPagina = 10;

        var locales = await _context.Local
            .AsNoTracking()
            .Where(l => l.Estado == 1)
            .OrderBy(l => l.Nombre)
            .ToListAsync();

        ViewBag.Locales = new SelectList(locales, "IdLocal", "Nombre", idLocal);

        var todos = await _context.Database
            .SqlQueryRaw<StockPorLocalListado>(
                "EXEC sp_ReporteStockPorLocal @IdLocal",
                new SqlParameter("@IdLocal", (object?)idLocal ?? DBNull.Value))
            .ToListAsync();

        if (!string.IsNullOrWhiteSpace(buscar))
        {
            var texto = buscar.Trim();
            todos = todos
                .Where(x => x.Insumo.Contains(texto, StringComparison.OrdinalIgnoreCase)
                         || x.Local.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (estadoFiltro == "bajo")
        {
            todos = todos
                .Where(x => x.CantidadActual > 0 && x.CantidadActual <= x.StockMinimo)
                .ToList();
        }
        else if (estadoFiltro == "sinstock")
        {
            todos = todos
                .Where(x => x.CantidadActual <= 0)
                .ToList();
        }

        int totalRegistros = todos.Count;
        int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalRegistros / (double)tamanoPagina));
        pagina = Math.Clamp(pagina, 1, totalPaginas);

        var porLocal = todos
            .GroupBy(x => x.Local)
            .OrderBy(g => g.Key)
            .ToList();

        var vm = new StockPorLocalConsultaViewModel
        {
            IdLocal = idLocal,
            Buscar = buscar,
            EstadoFiltro = estadoFiltro,
            PaginaActual = pagina,
            TotalPaginas = totalPaginas,
            TamanoPagina = tamanoPagina,
            TotalRegistros = totalRegistros,
            TotalNormal = todos.Count(x => x.CantidadActual > x.StockMinimo),
            TotalStockBajo = todos.Count(x => x.CantidadActual > 0 && x.CantidadActual <= x.StockMinimo),
            TotalSinStock = todos.Count(x => x.CantidadActual <= 0),
            Registros = todos.Skip((pagina - 1) * tamanoPagina).Take(tamanoPagina).ToList(),
            GraficoEtiquetas = porLocal.Select(g => g.Key).ToList(),
            GraficoNormal = porLocal.Select(g => g.Count(x => x.CantidadActual > x.StockMinimo)).ToList(),
            GraficoStockBajo = porLocal.Select(g => g.Count(x => x.CantidadActual > 0 && x.CantidadActual <= x.StockMinimo)).ToList(),
            GraficoSinStock = porLocal.Select(g => g.Count(x => x.CantidadActual <= 0)).ToList()
        };

        return View(vm);
    }

    public async Task<IActionResult> AlertasPorPeriodo(
        DateTime? fechaInicio,
        DateTime? fechaFin,
        int? idLocal,
        string tipoAlerta = "todos",
        int pagina = 1)
    {
        const int tamanoPagina = 10;

        var inicio = (fechaInicio ?? DateTime.Today.AddMonths(-3)).Date;
        var fin = (fechaFin ?? DateTime.Today).Date;
        if (fin < inicio) fin = inicio;

        var locales = await _context.Local
            .AsNoTracking()
            .Where(l => l.Estado == 1)
            .OrderBy(l => l.Nombre)
            .ToListAsync();

        ViewBag.Locales = new SelectList(locales, "IdLocal", "Nombre", idLocal);

        var resumen = await _context.Database
            .SqlQueryRaw<AlertaPeriodoResumen>(
                "EXEC sp_ReporteAlertasPorPeriodo @FechaInicio, @FechaFin",
                new SqlParameter("@FechaInicio", inicio),
                new SqlParameter("@FechaFin", fin))
            .ToListAsync();

        var finExclusivo = fin.AddDays(1);
        var query = _context.Alerta
            .AsNoTracking()
            .Include(a => a.IdStockLocalNavigation)
                .ThenInclude(sl => sl.IdLocalNavigation)
            .Include(a => a.IdStockLocalNavigation)
                .ThenInclude(sl => sl.IdInsumoNavigation)
            .Where(a => a.FechaAlerta >= inicio && a.FechaAlerta < finExclusivo);

        if (idLocal.HasValue && idLocal.Value > 0)
        {
            query = query.Where(a => a.IdStockLocalNavigation.IdLocal == idLocal.Value);
        }

        if (tipoAlerta is "B" or "S")
        {
            query = query.Where(a => a.TipoAlerta == tipoAlerta);
        }

        var todasAlertas = await query
            .OrderByDescending(a => a.FechaAlerta)
            .Select(a => new AlertaDetalleItem
            {
                IdAlerta = a.IdAlerta,
                Local = a.IdStockLocalNavigation.IdLocalNavigation.Nombre,
                Insumo = a.IdStockLocalNavigation.IdInsumoNavigation.Descripcion,
                TipoAlerta = a.TipoAlerta == "S" ? "Sin stock" : "Stock bajo",
                FechaAlerta = a.FechaAlerta,
                Resuelta = a.Resuelta == 1
            })
            .ToListAsync();

        int totalRegistros = todasAlertas.Count;
        int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalRegistros / (double)tamanoPagina));
        pagina = Math.Clamp(pagina, 1, totalPaginas);


        var localesGrafico = todasAlertas
            .Select(a => a.Local)
            .Distinct()
            .OrderBy(x => x)
            .ToList();


        var vm = new AlertasPorPeriodoConsultaViewModel
        {
            FechaInicio = inicio,
            FechaFin = fin,
            IdLocal = idLocal,
            TipoAlerta = tipoAlerta,
            PaginaActual = pagina,
            TotalPaginas = totalPaginas,
            TamanoPagina = tamanoPagina,
            TotalRegistros = totalRegistros,
            TotalStockBajo = todasAlertas.Count(x => x.TipoAlerta == "Stock bajo"),
            TotalSinStock = todasAlertas.Count(x => x.TipoAlerta == "Sin stock"),
            TotalResueltas = todasAlertas.Count(x => x.Resuelta),
            Registros = todasAlertas.Skip((pagina - 1) * tamanoPagina).Take(tamanoPagina).ToList(),
            ResumenProcedimiento = resumen,
            GraficoLocales = localesGrafico,

            GraficoStockBajo = localesGrafico.Select(loc =>
                todasAlertas.Count(a =>
                    a.Local == loc && a.TipoAlerta == "Stock bajo")).ToList(),

            GraficoSinStock = localesGrafico.Select(loc =>
                todasAlertas.Count(a =>
                    a.Local == loc && a.TipoAlerta == "Sin stock")).ToList()

        };

        return View(vm);
    }


    public async Task<IActionResult> MovimientosPorPeriodo(
        DateTime? fechaInicio,
        DateTime? fechaFin,
        string? insumo,
        string? local,
        string tipoMovimiento = "todos",
        int pagina = 1)
    {
        const int tamanoPagina = 10;

        // Fechas del reporte
        var inicio = (fechaInicio ??
            DateTime.Today.AddMonths(-3)).Date;

        var fin = (fechaFin ?? DateTime.Today).Date;

        if (fin < inicio)
            fin = inicio;

        var finExclusivo = fin.AddDays(1);

        // Consultar la vista de movimientos
        var movimientos = await _context.VwMovimientosDetallado
            .AsNoTracking()
            .Where(m =>
                m.FechaMovimiento >= inicio &&
                m.FechaMovimiento < finExclusivo)
            .OrderByDescending(m => m.FechaMovimiento)
            .ThenByDescending(m => m.IdMovimiento)
            .ToListAsync();

        // Filtrar por insumo
        if (!string.IsNullOrWhiteSpace(insumo))
        {
            movimientos = movimientos
                .Where(m => m.Insumo.Contains(
                    insumo.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Filtrar por cafetería
        if (!string.IsNullOrWhiteSpace(local))
        {
            movimientos = movimientos
                .Where(m => m.Local.Contains(
                    local.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Filtrar por tipo de movimiento
        if (tipoMovimiento is "Envio" or "Ajuste" or "Merma")
        {
            movimientos = movimientos
                .Where(m => m.TipoMovimiento == tipoMovimiento)
                .ToList();
        }

        // Calcular indicadores
        int totalRegistros = movimientos.Count;
        int totalEnvios = movimientos.Count(
            m => m.TipoMovimiento == "Envio");
        int totalAjustes = movimientos.Count(
            m => m.TipoMovimiento == "Ajuste");
        int totalMermas = movimientos.Count(
            m => m.TipoMovimiento == "Merma");

        // Calcular paginación
        int totalPaginas = Math.Max(1,
            (int)Math.Ceiling(
                totalRegistros / (double)tamanoPagina));

        pagina = Math.Clamp(pagina, 1, totalPaginas);

        var vm = new MovimientosPorPeriodoConsultaViewModel
        {
            FechaInicio = inicio,
            FechaFin = fin,
            Insumo = insumo,
            Local = local,
            TipoMovimiento = tipoMovimiento,

            PaginaActual = pagina,
            TotalPaginas = totalPaginas,
            TamanoPagina = tamanoPagina,

            TotalRegistros = totalRegistros,
            TotalEnvios = totalEnvios,
            TotalAjustes = totalAjustes,
            TotalMermas = totalMermas,

            Registros = movimientos
                .Skip((pagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .ToList(),

            GraficoTipos = new List<string>
        {
            "Envio", "Ajuste", "Merma"
        },

            GraficoMovimientos = new List<int>
        {
            totalEnvios, totalAjustes, totalMermas
        }
        };

        return View(vm);
    }

}
