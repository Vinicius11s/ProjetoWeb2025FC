using Humanizer;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto2025.Configuration;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioModels models;
        public UsuarioController(IUsuarioModels models)
        {
            this.models = models;
        }
        public IActionResult Login(){
            return View();
        }
        public IActionResult Logout()
        {
            //limpar sessão
            HttpContext.Session.Remove("nome_usuario");
            HttpContext.Session.Remove("codigo_usuario");
            HttpContext.Session.Clear();

            //redirecionar para login
            return RedirectToAction("Login", "Usuario");
        }
        [HttpPost]
        public IActionResult Logar(UsuarioDTO dto){

            //validar Banco de dados
            //model=>repositorio=>banco de dados
            var usuarioDto = models.validarLogin(
                            dto.email, dto.password);

            if (usuarioDto != null)
            {
                //encontrou

                //inserir os dados na sessão
                HttpContext.Session.SetString(
                    "nome_usuario", usuarioDto.Nome);
                HttpContext.Session.SetInt32(
                    "codigo_usuario", usuarioDto.id);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //não encontrou
                ViewBag.mensagem = "Dados inválidos";
                return View("Login");
            }
        }
        public IActionResult Index(){
            UsuarioDTO dto = new UsuarioDTO();
            dto.id = 0;

            return View(dto);
        }
        [HttpPost]
        public IActionResult Salvar(UsuarioDTO dto) {
            try
            {
                if (ModelState.IsValid)
                {
                    // executar model (salvar)
                    dto = this.models.save(dto);
                    ViewBag.classe = "alert-success";
                    ViewBag.mensagem = "Dados salvos com sucesso!";
                }
                else
                {
                    ViewBag.classe = "alert-danger";
                    ViewBag.mensagem = "Não foi possível salvar os dados!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.classe = "alert-danger";
                ViewBag.mensagem = "Erro ao salvar os dados! " +
                    ex.Message;
            }

            return View("Index", dto);     
        }     
    }
}
