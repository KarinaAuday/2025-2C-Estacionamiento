namespace _2025_2C_EstacionamietoORT.Models
{
    public class ClienteVehiculo
    {
        public int Id { get; set; }
        //Propiedades Relaciones

        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }

        //propiedad de Navegacion
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public bool ResponsablePrincipal { get; set; }

       


    }
}
