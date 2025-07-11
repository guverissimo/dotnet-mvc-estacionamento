using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoMVC.Context
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options)
        : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<RegistroEstacionamento> RegistroEstacionamento { get; set; }
        public DbSet<ConfiguracaoEstacionamento> ConfiguracaoEstacionamentos { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👇 Aqui está o seed inicial da configuração
            modelBuilder.Entity<ConfiguracaoEstacionamento>().HasData(
                new ConfiguracaoEstacionamento
                {
                    Id = 1,
                    ValorPorHora = 0,
                    ValorMensalidade = 0,
                    ValorInicial = 0,
                }
            );
        }
    }
}