using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2025_2C_EstacionamietoORT.Data
{
    public class EstacionamientoContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public EstacionamientoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehiculo> Vehiculo { get; set; } = default!;
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Rol> Rol { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ////Modifico la Entidad Identity User para que guarde en Las tablas que yo quiero
            builder.Entity<IdentityUser<int>>().ToTable("Personas");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            //Relacion usuario-Roles
            builder.Entity<IdentityUserRole<int>>().ToTable("UsuarioRoles");

            builder.Entity<Vehiculo>().HasIndex(v => v.Patente).IsUnique(); //Patente unica
        }
    }
}
