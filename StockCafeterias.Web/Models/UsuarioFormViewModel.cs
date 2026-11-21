using System.ComponentModel.DataAnnotations;

namespace StockCafeterias.Web.Models;

public class UsuarioFormViewModel
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "Los nombres son obligatorios.")]
    [StringLength(100, ErrorMessage = "Los nombres no pueden exceder 100 caracteres.")]
    [Display(Name = "Nombres")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios.")]
    [StringLength(100, ErrorMessage = "Los apellidos no pueden exceder 100 caracteres.")]
    [Display(Name = "Apellidos")]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder 50 caracteres.")]
    [RegularExpression(@"^\S+$", ErrorMessage = "El nombre de usuario no puede contener espacios.")]
    [Display(Name = "Nombre de Usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [StringLength(128, MinimumLength = 12, ErrorMessage = "La contraseña debe tener entre 12 y 128 caracteres.")]
    [Display(Name = "Contraseña")]
    public string? Password { get; set; }

    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [StringLength(100)]
    [Display(Name = "Correo Electrónico")]
    public string? Email { get; set; }

    [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe tener exactamente 8 dígitos numéricos.")]
    [Display(Name = "DNI")]
    public string? Dni { get; set; }

    [StringLength(15)]
    [Display(Name = "Teléfono")]
    public string? Telefono { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Ingreso")]
    public DateOnly FechaIngreso { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Required(ErrorMessage = "Debe seleccionar un rol.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol válido.")]
    [Display(Name = "Rol")]
    public int IdRol { get; set; }

    [Display(Name = "Local Asignado")]
    public int? IdLocal { get; set; }

    [Display(Name = "Usuario Activo")]
    public bool EstadoActivo { get; set; } = true;
}
