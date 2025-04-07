using Humanizer;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteModels models;
        private IEventoModels eventoModels;

        public ClienteController(IClienteModels models,
            IEventoModels eventoModels)
        {
            this.models = models;
            this.eventoModels = eventoModels;
        }

        public IActionResult Index()
        {
            ClienteDTO dto = new ClienteDTO();
            dto.id = 0;

            //obter as categorias e retornar para a View
            var listaEve =  eventoModels.getAll();
            ViewBag.listaEve = listaEve.Select(c=> new SelectListItem { 
                Value = c.id.ToString(),
                Text = c.DataEvento.ToString()
            });
            return View(dto);
        }

        public ActionResult Listar()
        {
            var lista = models.GetAll();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Salvar(ClienteDTO dto)
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

            //obter as categorias e retornar para a View
            var listaCat = eventoModels.getAll();
            ViewBag.listaCat = listaCat.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.DataEvento.ToString()
            });

            return View("Index", dto);

        }
    }
}
