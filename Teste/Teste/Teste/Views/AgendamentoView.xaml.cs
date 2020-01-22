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
                    this.ViewModel.SalvaAgendamentoAsync();
                }
                });
            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento",
                    "Agendamento Salvo com Sucesso", "ok");
                }
            );
            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento",
                    "Falha no Salvamento", "ok");
                }
            );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}

