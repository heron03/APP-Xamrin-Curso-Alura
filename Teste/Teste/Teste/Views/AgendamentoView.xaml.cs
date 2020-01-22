using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Teste.ViewModels;
using Xamarin.Forms;
namespace Teste.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",
                async (msg) =>
                {
                var confirma = await DisplayAlert("Salvar Agendamento",
                "Deseja mesmo enviar o agendamento ?",
                "Sim", "Não"
                );

                if (confirma)
                {
                    DisplayAlert("Agendamento",
                    string.Format(
                    @"Veiculo: {0}
                    Nome: {1}
                    Fone: {2}
                    E-mail: {3}
                    Data Agendamento: {4}
                    Hora Agendamento: {5}",
                    ViewModel.Agendamento.Veiculo.nome,
                    ViewModel.Agendamento.Nome,
                    ViewModel.Agendamento.Telefone,
                    ViewModel.Agendamento.Email,
                    ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                    ViewModel.Agendamento.HoraAgendamento), "OK");
                }
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}

