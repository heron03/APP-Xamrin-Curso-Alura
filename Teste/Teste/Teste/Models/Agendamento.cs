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
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public bool Confirmado { get; set;
        }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento { get; set; }

        public string dataFormatada
        {
            get
            {
                return DataAgendamento.Add(HoraAgendamento).ToString("dd/MM/yyyy HH:mm");
            }
        }

        public Agendamento()
        {

        }
        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento)
            : this(nome, telefone, email, modelo, preco)
        {
            this.DataAgendamento = dataAgendamento;
            this.HoraAgendamento = horaAgendamento;
        }

        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }
        public Agendamento(string nome, string fone, string email, string modelo, decimal preco, DateTime dataAgendamento, TimeSpan horaAgendamento, bool confirmado)
        : this(nome, fone, email, modelo, preco, dataAgendamento, horaAgendamento)
        {
            this.Confirmado = confirmado;
        }

    }
}
