using _2025_2C_EstacionamietoORT.Data;
using _2025_2C_EstacionamietoORT.Models;
using _2025_2C_EstacionamietoORT.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace _2025_2C_EstacionamietoORT.Controllers
{
    public class AccountController : Controller
    {
        private readonly EstacionamientoContext _context;
        private readonly UserManager<Persona> _userManager;
        private readonly SignInManager<Persona> _signInManager;
        private readonly RoleManager<Rol> _roleManager;
        public AccountController(EstacionamientoContext context, UserManager<Persona> userManager, SignInManager<Persona> signInManager, RoleManager<Rol> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrar([Bind("Email , Password ,ConfirmPassword")] RegistrarUsuario RegistrarUsuarioModel)
        {
            if (ModelState.IsValid)
            {
                Cliente clienteNuevo = new Cliente();
                clienteNuevo.UserName = RegistrarUsuarioModel.Email;
                clienteNuevo.Email = RegistrarUsuarioModel.Email;
                var resultadoCrearCli = await _userManager.CreateAsync(clienteNuevo, RegistrarUsuarioModel.Password);


                if (resultadoCrearCli.Succeeded)
                {
                    var resultadoAddRole = await _userManager.AddToRoleAsync(clienteNuevo, "Cliente");
                    if (resultadoAddRole.Succeeded)
                    {
                        await _signInManager.SignInAsync(clienteNuevo, isPersistent: false);
                        return RedirectToAction("Edit", "Clientes", new { id = clienteNuevo.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se pudo asignar el rol al usuario.");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { mensajeError = "Usuario duplicado o error al crear el usuairo" });

                }


            }
            return View(RegistrarUsuarioModel);
        }

        public IActionResult IniciarSesion(string returnUrl)
        {
            //ViewBag y viewData
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(LoginVM loginViewModel)
        {

            //Retorna a la URL que quise acceder antes de inciar sesion
            if (ModelState.IsValid)
            {
                string returnUrl = TempData["ReturnUrl"] as string;

                // tempData guarda info por fuera del bloque de codigo, o sea a la vista y al proximo return generando una cookie temporal


                //metodo asincronico para password adato asincronico todo
                //le paso directamente el email (username)
                //recordarme lo defino para ver si defini que sea persistente o no
                var resultado = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                //me devuelve un signinresult
                if (resultado.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                //agrego un errror si no pudo procesar
                ModelState.AddModelError(String.Empty, "Inicio de Sesión inválida");
            }
            return View(loginViewModel);
        }


        public async Task<IActionResult> CerrarSesion()
        {
            //Aca cierro sesion, le dice al browser que elimine esa cookie
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Solo puede listar si esta logueado como Admin  
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListarRoles()
        {
            //2 formas de obtener los Roles Exsitentes
            var roles = _roleManager.Roles.ToList();
            var roles2 = _context.Roles.ToList();
            return View(roles);
        }

        public IActionResult AccesoDenegado(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}

