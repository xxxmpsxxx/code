using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CallForCode.App.Services;
using CallForCode.App.Views;

namespace CallForCode.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Models.Login>(this, "LoginSuccess", (x) =>
            {
                MainPage = new AppShell();
            });
        }

        protected override void OnSleep()
        {
            MessagingCenter.Unsubscribe<Models.Login>(this, "LoginSuccess");
        }

        protected override void OnResume()
        {
        }
    }
}
