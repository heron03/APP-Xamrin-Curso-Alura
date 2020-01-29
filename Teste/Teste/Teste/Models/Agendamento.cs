using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
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

        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;       
            this.Telefone = telefone;       
            this.Email = email;       
            this.Modelo = modelo;
            this.Preco = preco;
        }

    }
}
