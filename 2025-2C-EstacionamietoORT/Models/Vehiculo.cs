using _2025_2C_EstacionamietoORT.Helpers;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]{6,7}$", ErrorMessage = "La patente debe tener entre 6 y 7 caracteres alfanuméricos.")]
        public int Patente { get; set; }

        [Required(ErrorMessage = ErrorMsg.Required)]
        [Display(Name = "Marca Auto")]
        public string Marca { get; set; }



        public string Color { get; set; }


        public int AnioFabricacion { get; set; } = DateTime.Now.Year;

        List<ClienteVehiculo> ClienteVehiculos { get; set; }

    }
}
