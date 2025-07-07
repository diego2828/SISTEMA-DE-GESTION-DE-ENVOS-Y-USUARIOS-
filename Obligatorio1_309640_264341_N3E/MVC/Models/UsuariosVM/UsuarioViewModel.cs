using System.ComponentModel.DataAnnotations;

namespace MVC.Models.UsuariosVM
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "El Rol es obligatorio.")]
        public int RolId { get; set; }
    }
}
