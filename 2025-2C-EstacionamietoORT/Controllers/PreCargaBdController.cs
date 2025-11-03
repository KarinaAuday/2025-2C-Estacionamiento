using _2025_2C_EstacionamietoORT.Data;
using _2025_2C_EstacionamietoORT.Helpers;
using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace _2025_2C_EstacionamietoORT.Controllers
{
    public class PreCargaBdController : Controller
    {

        private readonly EstacionamientoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly List<string> roles = new List<string>() { Configs.EmpleadoRolName, Configs.ClienteRolName, Configs.AdminRolName };
        public PreCargaBdController(UserManager<Persona> userManager, RoleManager<Rol> roleManager, EstacionamientoContext context)
        {//Agrego usario y roles
            this._userManager = userManager;
            this._roleManager = roleManager;
            _context = context;
        }

       
        #region PreCargaClientes
        //private List<Cliente> clientes = new List<Cliente>
        //{
        //    new Cliente {  Nombre = "Juan", Apellido = "Pérez", Dni = "12345678" , Email ="charly@ort.edu.ar" , Cuit="22222222" },
        //    new Cliente {  Nombre = "Ana", Apellido = "Gómez", Dni = "87654321" ,Email ="Pepe@ort.edu.ar" , Cuit="3333333" },
        //    new Cliente { Nombre = "Luis", Apellido = "Martínez", Dni = "11223344" , Email ="Alber@ort.edu.ar" , Cuit="4444444"}

        //};
        private void inicializarClientes()
        {
            Cliente cliente1 = new Cliente
            {
                Nombre = "Juan Carlos",
                Apellido = "Baglietto",
                Dni = "97528788",
                Email = "Baglieto@gmail.com",
                Cuit = "2034444" ,
                UserName = "Baglietto",
            };
            _context.Add(cliente1);
            _context.SaveChanges();
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
            new Vehiculo(25656588,"Ford taunus" , "Verde"),
            new Vehiculo(96969696, "Renault Clio" , "Azul") ,
            new Vehiculo(33333333, "Mercedes benz" , "amarillo"),
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


        public IActionResult InicializarBD()
        {
            CrearRoles().Wait();
            inicializarClientes();
            crearVehiculos();
            TempData["PrecargaOK"] = "Base de datos inicializada con datos de prueba.";
            return RedirectToAction("Index", "Home");
           
        }

        private async Task CrearRoles()
        {
            foreach (var rolName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new Rol(rolName));
                }
            }
        }
    }
}