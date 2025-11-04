using Microsoft.EntityFrameworkCore;
using _2025_2C_EstacionamietoORT.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales del modelo pueden ir aquí
            modelBuilder.Entity<Estancia>().Property(est => est.Monto).HasPrecision(38, 18);
            #region Identity table names
            //Modificar los nombres de las tablas de Identity
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");
            
            #endregion 


        }
    }
}
