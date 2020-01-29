using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Models;

namespace Teste.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;
        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<Agendamento>();
        }

        public void Salvar (Agendamento agendamento)
        {
            conexao.Insert(agendamento);
        }
    }
}
