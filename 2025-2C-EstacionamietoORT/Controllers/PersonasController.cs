using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2025_2C_EstacionamietoORT.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearPersonas (string nombre , string apellido , string dni , string email)
        {
            Persona persona = new Persona()
            { 
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Email = email
            };

            return View (persona);

        }
        
        public IActionResult FormGet()
        {
            return View();
        }

        public IActionResult FormPost()
        {
            return View();
        }

    }



}
