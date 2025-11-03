using _2025_2C_EstacionamietoORT.Data;
using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _2025_2C_EstacionamietoORT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Configuro la Base de Datos
            //builder.Services.AddDbContext<Data.EstacionamientoContext>(options =>
            //options.UseInMemoryDatabase("EstacionamientoDB"));

            //Configuro SQL Server
            builder.Services.AddDbContext<EstacionamientoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EstacionamientoDBCS")));
            #region Identity
            builder.Services.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<EstacionamientoContext>();
            #endregion
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
            }
         );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
