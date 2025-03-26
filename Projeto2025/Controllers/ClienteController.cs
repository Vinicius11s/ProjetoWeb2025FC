using Microsoft.AspNetCore.Mvc;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ClienteDTO dto = new ClienteDTO();
            dto.id = 0;
            return View(dto);
        }
             
        [HttpPost]
        public IActionResult Salvar(ClienteDTO dto) {
            try
            {
                if (ModelState.IsValid)
                {
                    // executar model (salvar)
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
                ViewBag.mensagem = "Erro ao salvar os dados! " + ex.Message;
                throw;
            }
         
            return View("Index", dto);
        }
    }
}
