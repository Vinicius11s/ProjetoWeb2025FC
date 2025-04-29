using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class TipoEventoController : Controller
    {
        private ITipoEventoModels models;
        private IEventoModels eventoModels;
        public TipoEventoController(ITipoEventoModels models,
            IEventoModels eventoModels)
        {
            this.models = models;
            this.eventoModels = eventoModels;
        }

        public IEnumerable<SelectListItem> carregaListaTipoEvento()
        {
            var listaTipoEve = eventoModels.GetAll();
            return listaTipoEve.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.DataEvento.ToString()
            });
        }
        public IActionResult Index()
        {
            TipoEventoDTO dto = new TipoEventoDTO();
            dto.id = 0;

            ViewBag.listaEve = carregaListaTipoEvento();

            return View(dto);
        }
        public ActionResult Listar()
        {
            var lista = models.GetAll();
            return View(lista);
        }
        [HttpPost]
        public IActionResult Salvar(TipoEventoDTO dto)
        {
            try
            {
                if (ModelState.IsValid) //modelo valido ?
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

            ViewBag.listaEve = carregaListaTipoEvento();
            return View("Index", dto);

        }
        public IActionResult Excluir(int id)
        {
            try
            {
                this.models.delete(id);
                ViewBag.mensagem = "Exclusão efetuada com sucesso !";
                ViewBag.classe = "alert-sucess";
            }
            catch (Exception)
            {
                ViewBag.mensagem = "Ops.. ocorreu um erro ao excluir o item";
                ViewBag.classe = "alert-danger";
            }
            var lista = models.GetAll();
            return View("Listar", lista);
        }
        public IActionResult PreAlterar(int id)
        {
            //controller vai pra model > repositorio e depois retorna
            var objDTO = this.models.GetTipoEvento(id);

            ViewBag.listaEve = carregaListaTipoEvento();

            return View("Index", objDTO);

        }
    }
}

