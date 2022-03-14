using Microsoft.AspNetCore.Mvc;
using Prova_Pratica_Desenvolvedor.Models;
using Prova_Pratica_Desenvolvedor.Repository;
using Prova_Pratica_Desenvolvedor.ViewModels;
using System;
using System.Collections.Generic;

namespace Prova_Pratica_Desenvolvedor.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }
        public IActionResult Index()
        {
            List<PedidoModel> pedidos = _pedidoRepositorio.BuscarTodos();
            List<PedidoViewModel> pedidosViewModel = DTOPedidos(pedidos);
            return View(pedidosViewModel);
        }
        public List<PedidoViewModel> DTOPedidos(List<PedidoModel> model)
        {
            List<PedidoViewModel> viewModels = new List<PedidoViewModel>();
            foreach (var item in model)
            {
                PedidoViewModel pedido = new PedidoViewModel();
                pedido.id = item.id;
                pedido.nome_produto = item.nome_produto;
                pedido.valor = item.valor;
                pedido.date = item.date.Date;

                if (item.date.Date > DateTime.Now.AddDays(3).Date)
                {
                    pedido.cor = "validos";
                }
                else if (item.date.Date == DateTime.Now.AddDays(-3).Date)
                {
                    pedido.cor = "vencendo";
                }
                else if (item.date.Date < DateTime.Now.Date)
                {
                    pedido.cor = "vencidos";
                }
                else if (item.date.Date >= DateTime.Now.Date && item.date.Date < DateTime.Now.AddDays(-2).Date)
                {
                    pedido.cor = "padrao";
                }
                viewModels.Add(pedido);

            }
            return viewModels;
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            PedidoModel pedido = _pedidoRepositorio.ListarPorId(id);
            return View(pedido);
        }
        public IActionResult Descontar(int id)
        {
            PedidoModel pedido = _pedidoRepositorio.ListarPorId(id);
            pedido.valor = pedido.valor * 0.9M;
            return View(pedido);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            PedidoModel pedido = _pedidoRepositorio.ListarPorId(id);
            return View(pedido);
        }

        public IActionResult Apagar(int id)
        {
            _pedidoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(PedidoModel pedido)
        {
            _pedidoRepositorio.Adicionar(pedido);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(PedidoModel pedido)
        {
            _pedidoRepositorio.Atualizar(pedido);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Descontar(PedidoModel pedido)
        {
            _pedidoRepositorio.Atualizar(pedido);
            return RedirectToAction("Index");
        }
    }
}
