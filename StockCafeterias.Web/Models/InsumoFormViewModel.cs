using System.ComponentModel.DataAnnotations;

namespace StockCafeterias.Web.Models;

public class InsumoFormViewModel
{
    public int IdInsumo { get; set; }

    [Required(ErrorMessage = "La descripción del insumo es obligatoria.")]
    [StringLength(100, ErrorMessage = "La descripción no puede exceder 100 caracteres.")]
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor a cero.")]
    [Display(Name = "Precio Unitario (S/)")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una unidad de medida.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una unidad de medida válida.")]
    [Display(Name = "Unidad de Medida")]
    public int IdUnidadMedida { get; set; }

    [Display(Name = "Stock Actual")]
    [Range(0, 999999.99, ErrorMessage = "El stock actual no puede ser negativo.")]
    public decimal StockActual { get; set; }

    [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
    [Range(0, 999999.99, ErrorMessage = "El stock mínimo no puede ser negativo.")]
    [Display(Name = "Stock Mínimo")]
    public decimal StockMinimo { get; set; }

    [Display(Name = "Insumo Activo")]
    public bool EstadoActivo { get; set; } = true;
}
