using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class ServicoController : Controller
    {
        private IServicoModels models;
        public ServicoController(IServicoModels models)
        {
            this.models = models;
        }
        public IActionResult Index()
        {
            ServicoDTO dto = new ServicoDTO();
            dto.id = 0;
            return View(dto);
        }
        public ActionResult Listar()
        {
            var lista = models.GetAll();
            return View(lista);
        }
        [HttpPost]
        public IActionResult Salvar(ServicoDTO dto)
        {
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
