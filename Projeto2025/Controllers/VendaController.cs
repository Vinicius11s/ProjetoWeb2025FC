using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto2025.DTOs;
using AutoMapper;

namespace Projeto2025.Controllers
{
    public class VendaController : Controller
    {
        private  IVendaModels vendaModels;
        private  IServicoModels servicoModels;
        private  IEventoModels eventoModels;
        private  IFormaPagamentoModels formaPagamentoModels;

        public VendaController(IVendaModels vendaModels, IServicoModels servicoModels,
                                IEventoModels eventoModels,IFormaPagamentoModels formaPagamentoModels)
        {
            this.vendaModels = vendaModels;
            this.servicoModels = servicoModels;
            this.eventoModels = eventoModels;
            this.formaPagamentoModels = formaPagamentoModels;
        }

        private IEnumerable<SelectListItem> carregaListaServicos()
        {
            var lista = servicoModels.GetAll();
            return lista.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.NomeServico
            });
        }
        private IEnumerable<SelectListItem> carregaListaEventos()
        {
            var lista = eventoModels.GetAll();
            return lista.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.Descricao // ou outra descrição útil do evento
            });
        }
        private IEnumerable<SelectListItem> carregaListaFormaPagamento()
        {
            var lista = formaPagamentoModels.GetAll();
            return lista.Select(f => new SelectListItem
            {
                Value = f.id.ToString(),
                Text = f.Descricao
            });
        }

        public IActionResult Index()
        {
            var servicos = servicoModels.GetAll();
            var eventos = eventoModels.GetAll();

            ViewBag.listaServicos = servicos.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.NomeServico
            });

            ViewBag.listaEventos = eventos.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.Descricao
            });

            ViewBag.listaPagamentos = carregaListaFormaPagamento();

            // 🔽 ViewBags extras para o JS calcular automaticamente
            ViewBag.servicosComValores = servicos.Select(s => new { id = s.id, valor = s.ValorPorPessoa });
            ViewBag.eventosComQtdPessoas = eventos.Select(e => new { id = e.id, quantidadePessoas = e.QuantidadePessoas });

            VendaDTO venda = new VendaDTO
            {
                Itens = new List<ItemVendaDTO> { new ItemVendaDTO() }
            };

            return View(venda);
        }

        [HttpPost]
        public IActionResult Salvar(VendaDTO venda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Você pode fazer o cálculo aqui se ainda não tiver feito no front
                    vendaModels.save(venda);

                    ViewBag.mensagem = "Venda salva com sucesso!";
                    ViewBag.classe = "alert-success";
                }
                else
                {
                    ViewBag.mensagem = "Dados inválidos!";
                    ViewBag.classe = "alert-danger";
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensagem = "Erro ao salvar: " + ex.Message;
                ViewBag.classe = "alert-danger";
            }

            var servicos = servicoModels.GetAll();
            var eventos = eventoModels.GetAll();

            ViewBag.listaServicos = servicos.Select(s => new SelectListItem
            {
                Value = s.id.ToString(),
                Text = s.NomeServico
            });

            ViewBag.listaEventos = eventos.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.Descricao
            });

            ViewBag.listaPagamentos = carregaListaFormaPagamento();

            ViewBag.servicosComValores = servicos.Select(s => new { id = s.id, valor = s.ValorPorPessoa });
            ViewBag.eventosComQtdPessoas = eventos.Select(e => new { id = e.id, quantidadePessoas = e.QuantidadePessoas });

            return View("Index", venda);
        }
        public IActionResult Listar()
        {
            var lista = vendaModels.getAll();
            return View(lista);
        }
    }
}
    

