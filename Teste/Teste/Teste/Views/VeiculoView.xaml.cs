using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.Views
{



    public partial class VeiculoView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public VeiculoView()
        {
            InitializeComponent();

            
            this.Veiculos = new ListagemVeiculo().Veiculos;

            this.BindingContext = this;
        }

        private void veiculoViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}