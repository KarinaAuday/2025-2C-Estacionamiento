using _2025_2C_EstacionamietoORT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2025_2C_EstacionamietoORT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Pruebas1()
        {
            return View();
        }

        public IActionResult Pruebas2(int num , string nombre , string apellido)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Apellido = apellido;
            return View(num);
        }


        public IActionResult Pruebas3()
        {
            List<string> ciudades = new List<string> { "Buenos Aires", "Paris", "Madrid", "Rio de Janeiro" };
            ViewBag.lasCiudades = ciudades;
            return View(ciudades);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
