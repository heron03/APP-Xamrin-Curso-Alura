using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.ViewModels;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.Views
{
    public partial class VeiculoView : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }
        readonly Usuario usuario;
        public VeiculoView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            await this.ViewModel.GetVeiculos();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (veiculo) =>
                {
                    Navigation.PushAsync(new DetalheView(veiculo, usuario));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículos. Por favor tente novamente mais tarde.", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}
