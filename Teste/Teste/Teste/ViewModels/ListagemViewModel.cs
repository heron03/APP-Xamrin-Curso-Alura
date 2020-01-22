using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {

        const string URL_GET_VEICULOS = "https://aluracar.herokuapp.com/";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado {
            get
            {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if ( value != null)
                {
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
                }
            }
        }

        public ListagemViewModel() {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        private bool aguarde;

        public bool Aguarde
        {
            get
            {
                return aguarde;
            }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var veiculoJson in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo {
                    nome = veiculoJson.nome,
                    preco = veiculoJson.preco
                });
            }
            Aguarde = false;
        }

    }
    class VeiculoJson
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}
 