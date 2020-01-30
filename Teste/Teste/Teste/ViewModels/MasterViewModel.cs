using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Teste.Media;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    public class MasterViewModel : BaseViewModel
	{
        public string Nome
        {
            get
            {
                return this.usuario.nome;
            }
            set
            {
                this.usuario.nome = value;
            }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set
            {
                this.usuario.email = value;
            }
        }

        public string DataNascimento
        {
            get { return usuario.dataNascimento; }
            set { usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return usuario.telefone; }
            set { usuario.telefone = value; }
        }

        private bool editando;
        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        private ImageSource fotoPerfil = "perfil.png";

        public ImageSource FotoPerfil
        {
            get
            {
                return fotoPerfil;
            }
            private set
            {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand TirarFoto { get; private set; }
        public ICommand MeusAgendamentos { get; private set; }
        public ICommand NovoAgendamento
        {
            get; private set;
        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;

            DefinirComandos(usuario);

            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada",
            (bytes) =>
            {
                FotoPerfil = ImageSource.FromStream(
                    () => new MemoryStream(bytes));
            });
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });

            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });

            TirarFoto = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            MeusAgendamentos = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "MeusAgendamentos");
            });

            NovoAgendamento = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "NovoAgendamento");
            });
        }
    }
}