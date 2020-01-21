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
        public AgendamentoView(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
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
