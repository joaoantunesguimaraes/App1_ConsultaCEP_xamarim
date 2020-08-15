using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1_ConsultaCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Nova Instancia da Classe MainPage() 
            //Mudar de Página 
            //App.Current.MainPage = new NovaPagina();


            MainPage = new MainPage();


            MainPage = new App1_ConsultaCEP.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
