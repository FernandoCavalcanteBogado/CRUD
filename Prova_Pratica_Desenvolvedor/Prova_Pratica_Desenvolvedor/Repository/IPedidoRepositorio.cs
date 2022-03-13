using Prova_Pratica_Desenvolvedor.Models;
using System.Collections.Generic;

namespace Prova_Pratica_Desenvolvedor.Repository
{
    public interface IPedidoRepositorio
    {
        PedidoModel ListarPorId(int id);
        List<PedidoModel> BuscarTodos();
        PedidoModel Adicionar(PedidoModel pedido);
        PedidoModel Atualizar(PedidoModel pedido);
        bool Apagar(int id);
    }
}
