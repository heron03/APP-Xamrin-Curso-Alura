﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Models;
using Teste.Views;
using Xamarin.Forms;

namespace Teste
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
            (usuario) =>
            {
                //MainPage = new NavigationPage(new VeiculoView());
                MainPage = new MasterDetailView(usuario);
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
