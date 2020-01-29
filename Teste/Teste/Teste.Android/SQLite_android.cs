using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Teste.Data;
using Teste.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace Teste.Droid
{
    class SQLite_android : ISQLite
    {
        public SQLiteConnection PegarConexao()
        {
            return new SQLite.SQLiteConnection("Agendamento.db3");
        }
    }
}