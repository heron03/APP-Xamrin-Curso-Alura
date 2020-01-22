using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }

        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
                {
                    MessagingCenter.Send(veiculo, "Proximo");
                });
        }
       
        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            }
        }

        public string TextoMP3
        {
            get
            {
                return string.Format("Radio MP3 - R$ {0}", Veiculo.MP3_PLAYER);
            }
        }

        public string TextoAr
        {
            get
            {
                return string.Format("Ar - R$ {0}", Veiculo.AR_CONDICIONADO);
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public bool TemFreioABS
        {
            get
            {
                return Veiculo.temFreioABS;
            }
            set
            {
                Veiculo.temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMP3
        {
            get
            {
                return Veiculo.temMP3;
            }
            set
            {
                Veiculo.temMP3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.temArCondicionado;
            }
            set
            {
                Veiculo.temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public ICommand ProximoCommand { get; set; }
    }
}
