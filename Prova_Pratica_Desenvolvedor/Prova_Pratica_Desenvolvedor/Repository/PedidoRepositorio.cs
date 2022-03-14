using Prova_Pratica_Desenvolvedor.Data;
using Prova_Pratica_Desenvolvedor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prova_Pratica_Desenvolvedor.Repository
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PedidoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public PedidoModel ListarPorId(int id)
        {
            return _bancoContext.Pedidos.FirstOrDefault(x => x.id == id);
        }
        public List<PedidoModel> BuscarTodos()
        {
            return _bancoContext.Pedidos.ToList();
        }
        public PedidoModel Adicionar(PedidoModel pedido)
        {
            _bancoContext.Pedidos.Add(pedido);
            _bancoContext.SaveChanges();
            return pedido;
        }

        public PedidoModel Atualizar(PedidoModel pedido)
        {
            PedidoModel pedidoDB = ListarPorId(pedido.id);

            if (pedidoDB == null) throw new Exception("Houve um erro na atualização do pedido");

            pedidoDB.nome_produto = pedido.nome_produto;
            pedidoDB.valor = pedido.valor;
            pedidoDB.date = pedido.date;

            _bancoContext.Pedidos.Update(pedidoDB);
            _bancoContext.SaveChanges();

            return pedidoDB;
        }

        public bool Apagar(int id)
        {
            PedidoModel pedidoDB = ListarPorId(id);

            if (pedidoDB == null) throw new Exception("Houve um erro ao excluir o pedido");

            _bancoContext.Pedidos.Remove(pedidoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
