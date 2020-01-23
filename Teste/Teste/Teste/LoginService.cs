using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste.Models;
using Xamarin.Forms;

namespace Teste
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {

            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                try
                {
                    var resultado = await cliente.PostAsync("/login", camposFormulario);
                    if (resultado.IsSuccessStatusCode)
                    {
                        var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                        var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);

                        MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorreto"), "FalhaLogin");
                    }
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                        Por favor verifique a sua conexão e tente novamente mais tarde."),
                        "FalhaLogin");
                }
            }
        }
    }
    
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
