using _2025_2C_EstacionamietoORT.Data;
using _2025_2C_EstacionamietoORT.Helpers;
using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _2025_2C_EstacionamietoORT.Controllers
{
    public class PreCargaBdController : Controller
    {

        private readonly EstacionamientoContext _context;
        private readonly RoleManager<Rol> _roleManager;
        private readonly UserManager<Persona> _userManager;
        private List<string> roles = new List<string>
        {
            Configs.Admin,
            Configs.Empleado,
            Configs.Cliente
        };
        public PreCargaBdController(EstacionamientoContext context, UserManager<Persona> userManager, RoleManager<Rol> roleManager)
        {
            _context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        #region PreCargaClientes
        //private List<Cliente> clientes = new List<Cliente>
        //{
        //    new Cliente {  Nombre = "Juan", Apellido = "Pérez", Dni = "12345678" , Email ="charly@ort.edu.ar" , Cuit="22222222" },
        //    new Cliente {  Nombre = "Ana", Apellido = "Gómez", Dni = "87654321" ,Email ="Pepe@ort.edu.ar" , Cuit="3333333" },
        //    new Cliente { Nombre = "Luis", Apellido = "Martínez", Dni = "11223344" , Email ="Alber@ort.edu.ar" , Cuit="4444444"}

        //};
        private async Task inicializarClientes()
        {
            Cliente cliente1 = new Cliente
            {
                Nombre = "Juan Carlos",
                Apellido = "Baglietto",
                Dni = "97528788",
                Email = "Baglieto@gmail.com",
                Cuit = "2034444",           
            };
            cliente1.UserName = cliente1.Email;
            await _userManager.CreateAsync(cliente1, Configs.passwordGenerica);
            await _userManager.AddToRoleAsync(cliente1, Configs.Cliente);

            Direccion direccion1 = new Direccion
            {
                Calle = "Calle Falsa",
                Altura = 123,
                CodigoPostal = 1111,
                Localidad = "Ciudad",
                Provincia = "Provincia",
                ClienteId = cliente1.Id
            };
            _context.Add(direccion1);
            _context.SaveChanges();
        }
        #endregion PrecargaClientes

        #region Lista de Vehiculos
        private List<Vehiculo> vehiculos = new List<Vehiculo>()
        {
            new Vehiculo(2034444,"Ford taunus" , "Verde"),
            new Vehiculo(8484848, "Renault Clio" , "Azul") ,
            new Vehiculo(5647866, "Mercedes benz" , "amarillo"),
        };
        #endregion

        //private void PreCargaClientes()
        //{
        //    foreach (var cliente in clientes)
        //    {
        //        // var clienteExistente = _context.Cliente.FirstOrDefault(c => c.Dni == cliente.Dni);
        //        // if (clienteExistente == null)
        //        // {
        //        _context.Cliente.Add(cliente);
        //        // }
        //    }
        //    _context.SaveChanges();
        //}

        private void crearVehiculos()
        {
            foreach (var vehiculo in vehiculos)
            {
                // var vehiculoExistente = _context.Vehiculo.FirstOrDefault(v => v.Patente == vehiculo.Patente);
                // if (vehiculoExistente == null)
                // {
                _context.Vehiculo.Add(vehiculo);
                // }
            }
            _context.SaveChanges();
        }


        public async Task<IActionResult> InicializarBD()
        {
            cargarRoles();
            await inicializarClientes();
            crearVehiculos();
            TempData["PrecargaOK"] = "Base de datos inicializada con datos de prueba.";
            return RedirectToAction("Index", "Home");

        }

        private void cargarRoles()
        {
            foreach (var rolNombre in roles)
            {
                _roleManager.CreateAsync(new Rol(rolNombre));

            }
            _context.SaveChanges();
        }
    }
}