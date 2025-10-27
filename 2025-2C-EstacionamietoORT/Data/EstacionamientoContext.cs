using Microsoft.EntityFrameworkCore;
using _2025_2C_EstacionamietoORT.Models;

namespace _2025_2C_EstacionamietoORT.Data
{
    public class EstacionamientoContext : DbContext
    {
        public EstacionamientoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehiculo> Vehiculo { get; set; } = default!;
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<_2025_2C_EstacionamietoORT.Models.Persona> Persona { get; set; }
    }
}
