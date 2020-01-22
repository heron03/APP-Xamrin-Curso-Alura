using System;
using System.Collections.Generic;
using System.Text;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

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
            this.Veiculos = new ListagemVeiculo().Veiculos;
        }
    }
}
 