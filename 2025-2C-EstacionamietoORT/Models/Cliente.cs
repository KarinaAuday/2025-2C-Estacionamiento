namespace _2025_2C_EstacionamietoORT.Models
{
    public class Cliente : Persona
    {
        public string Cuit { get; set; }

        //Propiedad Navegacional
        public Direccion Direccion { get; set; }

        //Propiedad Navegacional
        public List<Telefono> Telefonos { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos { get; set; }
    }
}
