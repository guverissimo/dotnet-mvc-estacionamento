using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoMVC.Models
{
    public class ConfiguracaoEstacionamento
    {
        public int Id { get; set; }
        public decimal ValorInicial { get; set; } = 0;
        public decimal ValorPorHora { get; set; } = 0;
        public decimal ValorMensalidade { get; set; } = 0;
    }
}