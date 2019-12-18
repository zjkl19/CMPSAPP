using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CMPSAPP.Services;
using CMPSAPP.Views;

namespace CMPSAPP
{
    public partial class App : Application
    {
        //public static readonly string ServerURL = @"http://218.66.5.89:8310/";
        public static readonly string ServerURL = @"http://192.168.1.107/";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ProcedureDataStore>();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<RealDataStore>();

            DependencyService.Register<StrainMonitorsDataStore>();
            DependencyService.Register<StrainMonitorsChartDataStore>();

            DependencyService.Register<CoordinateMonitorsDataStore>();
            DependencyService.Register<ElevationMonitorsDataStore>();
            DependencyService.Register<LeanMonitorsDataStore>();
            DependencyService.Register<CableForceMonitorsDataStore>();

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
