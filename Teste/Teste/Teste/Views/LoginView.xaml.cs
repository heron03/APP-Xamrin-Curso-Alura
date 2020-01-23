using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
        }
    }
}
