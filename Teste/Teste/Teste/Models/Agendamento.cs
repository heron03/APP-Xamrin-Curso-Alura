using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Models
{
    public class Agendamento
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TimeSpan HoraAgendamento { get; set; }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

    }
}
