using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StockCafeterias.Web.Models;

public class ProductoFormViewModel
{
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
    [Display(Name = "Nombre del Producto")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe seleccionar una categoría.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría válida.")]
    [Display(Name = "Categoría")]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio.")]
    [Range(0.01, 999999.99, ErrorMessage = "El precio de venta debe ser mayor a cero.")]
    [Display(Name = "Precio de Venta (S/)")]
    public decimal PrecioVenta { get; set; }

    [Required(ErrorMessage = "El costo promedio es obligatorio.")]
    [Range(0, 999999.99, ErrorMessage = "El costo promedio no puede ser negativo.")]
    [Display(Name = "Costo Promedio (S/)")]
    public decimal CostoPromedio { get; set; }

    [Required(ErrorMessage = "El stock máximo es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El stock máximo debe ser mayor a cero.")]
    [Display(Name = "Stock Máximo")]
    public int StockMaximo { get; set; }

    [Display(Name = "Producto Activo")]
    public bool EstadoActivo { get; set; } = true;

    [Display(Name = "Fotografía (opcional)")]
    public IFormFile? ArchivoFoto { get; set; }

    public byte[]? FotoActual { get; set; }
}
