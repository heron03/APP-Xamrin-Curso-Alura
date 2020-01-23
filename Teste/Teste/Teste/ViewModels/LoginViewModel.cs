using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                await FazerLogin();
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario)
                        && !string.IsNullOrEmpty(senha);
            });
        }

        private static async Task FazerLogin()
        {
            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                  {
                        new KeyValuePair<string, string>("email", "joao@alura.com.br"),
                        new KeyValuePair<string, string>("senha", "alura123")
                      });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                await cliente.PostAsync("/login", camposFormulario);
                MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
            }
        }
    }
}
