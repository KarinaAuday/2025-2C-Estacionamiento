using _2025_2C_EstacionamietoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_EstacionamietoORT.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = ErrorMsg.Required)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = ErrorMsg.NoValido)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
