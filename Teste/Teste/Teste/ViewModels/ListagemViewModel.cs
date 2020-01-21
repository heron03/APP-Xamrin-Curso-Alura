using System;
using System.Collections.Generic;
using System.Text;
using Teste.Models;

namespace Teste.ViewModels
{
    class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemViewModel() {
            this.Veiculos = new ListagemVeiculo().Veiculos;
        }
    }
}
 