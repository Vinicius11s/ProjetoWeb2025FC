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

            if (ModelState.IsValid)
            {
                // executar model (salvar)
                ViewBag.classe = "text-success";
                ViewBag.mensagem = "Dados salvos com sucesso!";
            }
            else
            {
                ViewBag.classe = "text-danger";
                ViewBag.mensagem = "Não foi possível salvar os dados!";
            }

            return View("Index", dto);

        }
    }
}
