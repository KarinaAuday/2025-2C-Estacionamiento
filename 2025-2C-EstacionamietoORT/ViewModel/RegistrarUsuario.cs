using System.ComponentModel.DataAnnotations;

namespace _2025_2C_EstacionamietoORT.ViewModel
{
    public class RegistrarUsuario
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La clave es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "La confirmación de la clave es obligatoria")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La clave y la confirmación de la clave no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
