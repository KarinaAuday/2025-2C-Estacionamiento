using System.ComponentModel.DataAnnotations;
using _2025_2C_EstacionamietoORT.Helpers;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Persona
    {
      
        public int Id { get; set; }

        [Required (ErrorMessage = ErrorMsg.Required)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMsg.StringLength)]
        [RegularExpression (@"^[a-zA-Z]+$" , ErrorMessage = ErrorMsg.SoloLetras)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMsg.StringLength)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [Display(Name = "Documento Nacional de Identidad")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El campo {0} debe tener 8 dígitos.")]
        public string Dni { get; set; }
        [Required(ErrorMessage = ErrorMsg.Required)]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = ErrorMsg.Required)]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        public DateTime FechaAlta   { get; set; }

       // public string Direccion { get; set; }

    }
}
