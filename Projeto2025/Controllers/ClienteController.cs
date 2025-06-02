using Humanizer;
using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.Configuration;
using Projeto2025.DTOs;

namespace Projeto2025.Controllers
{
public class ClienteController : Controller
{
    private IClienteModels models;
    private IEventoModels eventoModels;

    public ClienteController(IClienteModels models, IEventoModels eventoModels){
        this.models = models;
        this.eventoModels = eventoModels;
    }
        
    [SessionAuthorize]
    public IEnumerable<SelectListItem> carregaListaEvento()
    {
        var listaEve = eventoModels.GetAll();

        return listaEve.Select(e => new SelectListItem
        {
            Value = e.id.ToString(),
            Text = e.Descricao
        });
    }  

    [SessionAuthorize]
    public IActionResult Index()
    {
        ClienteDTO dto = new ClienteDTO();
        dto.id = 0;

        ViewBag.listaEve = carregaListaEvento();
        return View(dto);
    }

    [SessionAuthorize]
    public ActionResult Listar()
    {
        var lista = models.GetAll();
        return View(lista);
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
        //controller vai pra model > repositorio e depois retorna
        var objDTO = this.models.GetCliente(id);

        ViewBag.listaEve = carregaListaEvento();

        return View("Index", objDTO);
    }

    [HttpPost]
    [SessionAuthorize]
    public IActionResult Salvar(ClienteDTO dto)
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

        ViewBag.listaEve = carregaListaEvento();
        return View("Index", dto);

    }           
}
}
