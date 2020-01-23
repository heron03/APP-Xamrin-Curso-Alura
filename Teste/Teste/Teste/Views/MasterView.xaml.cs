using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Teste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teste.Views
{
    public partial class MasterView : ContentPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = this.ViewModel;
        }

        public MasterViewModel ViewModel { get; set; }
    }
}