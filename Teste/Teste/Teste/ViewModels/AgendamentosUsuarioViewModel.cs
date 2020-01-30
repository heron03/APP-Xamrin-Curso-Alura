using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Teste.Data;
using Teste.Models;
using Xamarin.Forms;

namespace Teste.ViewModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista
        {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }
        private Agendamento agendamentoSelecionado;

        public Agendamento AgendamentoSelecionado
        {
            get
            {
                return agendamentoSelecionado;
            }
            set
            {
                if (value != null)
                {
                    agendamentoSelecionado = value;
                    MessagingCenter.Send<Agendamento>(agendamentoSelecionado, "AgendamentoSelecionado");
                }
            }
        }

        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                var listaDB = dao.Lista;

                var query =
                    listaDB
                    .OrderBy(l => l.DataAgendamento)
                    .ThenBy(l => l.HoraAgendamento);

                this.Lista.Clear();
                foreach (var itemDB in query)
                {
                    this.Lista.Add(itemDB);
                }
            }
        }
    }
}
