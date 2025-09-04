using System.ComponentModel.DataAnnotations;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Estancia
    {
        public int Id { get; set; }

  

        public decimal Monto { get; private set; }

   
        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

    }
}
