using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.Configuration;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
    public class FormaPagamentoController : Controller
    {
        private IFormaPagamentoModels models;
        public FormaPagamentoController(IFormaPagamentoModels models)
        {
            this.models = models;
        }
        [SessionAuthorize]
        public IEnumerable<SelectListItem> carregaListaFormaPagamento()
        {
            var listaFormas = models.GetAll();
            return listaFormas.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.Descricao.ToString()//colocarDescricao
            });
        }
        [SessionAuthorize]
        public IActionResult Index()
        {
            FormaPagamentoDTO dto = new FormaPagamentoDTO();
            dto.id = 0;

            ViewBag.listaForma = carregaListaFormaPagamento();

            return View(dto);
        }
        [SessionAuthorize]
        public ActionResult Listar()
        {
            var lista = models.GetAll();
            return View(lista);
        }
        [SessionAuthorize]
        [HttpPost]
        public IActionResult Salvar(FormaPagamentoDTO dto)
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

            ViewBag.listaEve = carregaListaFormaPagamento();
            return View("Index", dto);

        }
        [SessionAuthorize]
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
        [SessionAuthorize]
        public IActionResult PreAlterar(int id)
        {
            var objDTO = this.models.GetFormaPagamento(id);
            return View("Index", objDTO);
        }
    }
}
