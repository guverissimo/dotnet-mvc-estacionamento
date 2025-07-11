using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoMVC.Models
{
    public class RegistroEstacionamento
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public decimal? Valor { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}