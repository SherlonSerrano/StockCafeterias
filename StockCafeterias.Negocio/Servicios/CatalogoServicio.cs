using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;

namespace StockCafeterias.Negocio.Servicios;

public class CatalogoServicio
{
    private readonly CatalogoRepositorio _repo;

    public CatalogoServicio(CatalogoRepositorio? repo = null)
    {
        _repo = repo ?? new CatalogoRepositorio();
    }

    public List<CategoriaItem> ListarCategorias() => _repo.ListarCategorias();

    public List<UnidadMedidaItem> ListarUnidadesMedida() => _repo.ListarUnidadesMedida();

    public List<RolItem> ListarRoles() => _repo.ListarRoles();

    public List<LocalItem> ListarLocales() => _repo.ListarLocales();
}
