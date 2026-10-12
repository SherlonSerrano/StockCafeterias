using StockCafeterias.Datos.Repositorios;
using StockCafeterias.Entidades.Listados;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Negocio.Servicios;

public class InsumoServicio
{
    private readonly InsumoRepositorio _repo;

    public InsumoServicio(InsumoRepositorio? repo = null)
    {
        _repo = repo ?? new InsumoRepositorio();
    }

    public List<InsumoListado> Listar(string? buscar = null, byte? estado = null)
    {
        return _repo.Listar(string.IsNullOrWhiteSpace(buscar) ? null : buscar.Trim(), estado);
    }

    public InsumoDetalle? ObtenerPorId(int idInsumo)
    {
        if (idInsumo <= 0)
            throw new ArgumentException("El identificador del insumo no es válido.");

        return _repo.ObtenerPorId(idInsumo);
    }

    public int Guardar(Insumo insumo, string usuario)
    {
        Validar(insumo);

        if (string.IsNullOrWhiteSpace(usuario))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        insumo.Descripcion = insumo.Descripcion.Trim();

        if (insumo.IdInsumo == 0)
        {
            insumo.IdInsumo = _repo.Insertar(insumo, usuario.Trim());
            return insumo.IdInsumo;
        }

        _repo.Actualizar(insumo, usuario.Trim());
        return insumo.IdInsumo;
    }

    public int Eliminar(int idInsumo, string usuario)
    {
        if (idInsumo <= 0)
            throw new ArgumentException("El identificador del insumo no es válido.");

        if (string.IsNullOrWhiteSpace(usuario))
            throw new ArgumentException("El usuario que realiza la operación es requerido.");

        return _repo.Eliminar(idInsumo, usuario.Trim());
    }

    private static void Validar(Insumo i)
    {
        if (i == null)
            throw new ArgumentNullException(nameof(i), "Los datos del insumo no pueden ser nulos.");

        if (string.IsNullOrWhiteSpace(i.Descripcion))
            throw new ArgumentException("La descripción del insumo es obligatoria.");

        if (i.Descripcion.Trim().Length > 100)
            throw new ArgumentException("La descripción del insumo no puede exceder los 100 caracteres.");

        if (i.IdUnidadMedida <= 0)
            throw new ArgumentException("Debe seleccionar una unidad de medida válida.");

        if (i.Precio <= 0)
            throw new ArgumentException("El precio del insumo debe ser mayor a cero.");

        if (i.StockMinimo < 0)
            throw new ArgumentException("El stock mínimo no puede ser negativo.");
    }
}
