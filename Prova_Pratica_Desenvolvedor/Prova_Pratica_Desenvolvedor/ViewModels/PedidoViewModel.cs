using System;

namespace Prova_Pratica_Desenvolvedor.ViewModels
{
    public class PedidoViewModel
    {
        public int id { get; set; }
        public string nome_produto { get; set; }
        public decimal valor { get; set; }
        public DateTime date { get; set; }
        public string cor { get; set; }

    }
}
