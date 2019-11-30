using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CMPSAPP.Services;
using CMPSAPP.Views;

namespace CMPSAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<RealDataStore>();
            DependencyService.Register<StrainMonitorsDataStore>();
            DependencyService.Register<CoordinateMonitorsDataStore>();

            MainPage = new AppShell();
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
