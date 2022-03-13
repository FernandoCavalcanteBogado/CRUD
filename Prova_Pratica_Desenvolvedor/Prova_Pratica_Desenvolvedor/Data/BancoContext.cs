using Microsoft.EntityFrameworkCore;
using Prova_Pratica_Desenvolvedor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova_Pratica_Desenvolvedor.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<PedidoModel> Pedidos { get; set; }
    }
}
