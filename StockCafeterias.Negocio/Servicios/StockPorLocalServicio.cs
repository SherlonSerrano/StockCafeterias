
using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;

namespace StockCafeterias.Negocio.Servicios;

public class StockPorLocalServicio
{
    private readonly StockPorLocalRepositorio _repositorio;

    public StockPorLocalServicio(
        StockPorLocalRepositorio? repositorio = null)
    {
        _repositorio = repositorio
            ?? new StockPorLocalRepositorio();
    }

    public List<StockPorLocalListado> Consultar(
        int? idLocal = null,
        bool soloStockBajo = false)
    {
        if (idLocal.HasValue && idLocal.Value <= 0)
        {
            throw new ArgumentException(
                "El local seleccionado no es válido.");
        }

        var registros = _repositorio.Consultar(idLocal);

        if (soloStockBajo)
        {
            registros = registros
                .Where(x => x.CantidadActual <= x.StockMinimo)
                .ToList();
        }

        return registros;
    }
}
