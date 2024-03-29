﻿using System;
using System.Collections.Generic;
using System.IO;
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
    public class SQLite_android : ISQLite
    {
        private const string fileNameDB = "Agendamento.db3";
        public SQLiteConnection PegarConexao()
        {
            var pathDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, fileNameDB);
            return new SQLiteConnection(pathDB);
        }
    }
}