using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class LoginController : Controller
    {
        private ILoginModels models;

        public LoginController(ILoginModels models)
        {
            this.models = models;
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginDTO dto){

            //Validar banco de dados model > repositorio > banco de dados
            var loginDTO = models.validarLogin(dto.email, dto.password);

            if(loginDTO != null)
            {
                //encontrou
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag("")
                return View("Login");
            }
        }
    }
}
