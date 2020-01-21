using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Teste.Models
{
    public class Veiculo
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;
        
        public bool temFreioABS { get; set; }
        public bool temMP3 { get; set; }
        public bool temArCondicionado { get; set; }

        public string PrecoFormatado
        {
            get
            {
                return string.Format("R$ {0}", preco);
            }
        }

        public FormattedString VeiculoLabel
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                        new Span { Text = nome },
                        new Span { Text = " - " },
                        new Span { Text = PrecoFormatado, FontAttributes = FontAttributes.Bold } }
                };
            }
            set { }
        }

         public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",preco
                + (temFreioABS ? FREIO_ABS : 0) + (temArCondicionado ? Veiculo.AR_CONDICIONADO : 0) + (temMP3 ? Veiculo.MP3_PLAYER : 0));
            }
            set { }
        }
    }
}
                