using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Telefono
    {
        public int Id { get; set; }
        public int CodArea { get; set; }

        public string Numero { get; set; }

        public bool Principal { get; set; }


        public TipoTelefono Tipo { get; set; }

        //Propiedades Relaciones
        public int ClienteId { get; set; }

        //Propiedad de Navegacion
        public Cliente Cliente { get; set; }

        public string NumeroCompleto { get { return $"({CodArea}) - {Numero}"; } }
    }
}
