using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;

using Xamarin.Forms;

namespace Teste.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo { 
            get{return Agendamento.Veiculo;}
            set{Agendamento.Veiculo = value;} 
        }

        public string Nome { 
            get{return Agendamento.Nome;}
            set{Agendamento.Nome = value;} 
        }

        public string Telefone { 
            get{return Agendamento.Telefone;}
            set{Agendamento.Telefone = value;} 
        }

        public string Email { 
            get{return Agendamento.Email;}
            set{Agendamento.Email = value;} 
        }

        public TimeSpan HoraAgendamento { 
            get{return Agendamento.HoraAgendamento;}
            set{Agendamento.HoraAgendamento = value;} 
        }

        public DateTime DataAgendamento {
            get{return Agendamento.DataAgendamento;}
            set{Agendamento.DataAgendamento = value;} 
        }

        public AgendamentoView(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            InitializeComponent();
            this.BindingContext = this;
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
                string.Format(
                @"Nome: {0}
                Telefone: {1}
                E-mail: {2}
                Data Agendamento: {3}
                Hora Agendamento:{4}",
                Nome, Telefone, Email, DataAgendamento.ToString("dd/MM/yyy"), HoraAgendamento), "OK");
        }
    }
}
