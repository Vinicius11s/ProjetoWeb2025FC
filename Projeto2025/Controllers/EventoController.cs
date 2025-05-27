using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class EventoController : Controller
    {
        private IEventoModels models;
        private ITipoEventoModels tipoEventoModels;
        private IClienteModels clienteModels;
        public EventoController(IEventoModels models, ITipoEventoModels tipoEventoModels, IClienteModels clienteModels)
        {
            this.models = models;
            this.tipoEventoModels = tipoEventoModels;
            this.clienteModels = clienteModels;
        }
        public IEnumerable<SelectListItem> carregaListaTipoEvento()
        {
            var listaEve = tipoEventoModels.GetAll();
            return listaEve.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.Descricao.ToString()
            });
        }

        public IEnumerable<SelectListItem> carregaListaClientes()
        {
            var listaCli = clienteModels.GetAll();
            return listaCli.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.NomeCompleto.ToString()
            });
        }
        public IActionResult Index()
        {
            EventoDTO dto = new EventoDTO();
            dto.id = 0;

            // Obter todos os tipos de evento
            var tiposEvento = tipoEventoModels.GetAll();
            var clientes = clienteModels.GetAll();

            // Preencher o ViewBag com os tipos de evento
            ViewBag.TiposEvento = new SelectList(tiposEvento, "id", "Descricao"); // Certifique-se de que a propriedade "Descricao" existe no modelo TipoEvento
            ViewBag.Clientes = new SelectList(clientes, "id", "NomeCompleto");

            return View(dto);
        }
        public ActionResult Listar()
        {
            var lista = models.GetAll();
            return View(lista);
        }
        public ActionResult Excluir(int id)
        {

            try
            {
                this.models.delete(id);
                ViewBag.mensagem = "Exclusão efetuada com sucesso!";
                ViewBag.classe = "alert-success";
            }
            catch (Exception ex)
            {

                ViewBag.mensagem = "Não foi possível excluir o item!";
                ViewBag.classe = "alert-danger";
            }

            var lista = models.GetAll();
            return View("Listar", lista);
        }
        public IActionResult PreAlterar(int id)
        {
            var objDTO = this.models.GetEvento(id);

            ViewBag.listaEve = carregaListaTipoEvento();

            return View("Index", objDTO);
        }
        [HttpPost]
        public IActionResult Salvar(EventoDTO dto)
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
