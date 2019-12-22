using CMPSAPP.ViewModels;
using CMPSAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CMPSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonitorsQueryNavigationPage : ContentPage
    {
        MonitorsQueryNavigationViewModel viewModel;
        int monitorsType;
        public MonitorsQueryNavigationPage()
        {
            InitializeComponent();
        }

        //public MonitorsQueryNavigationPage(MonitorsQueryNavigationViewModel viewModel)
        //{
        //    InitializeComponent();

        //    BindingContext = this.viewModel = viewModel;
        //}

        public MonitorsQueryNavigationPage(MonitorsQueryNavigationViewModel viewModel,int monitorsType=1)
        {
            InitializeComponent();

            this.monitorsType = monitorsType;
            BindingContext = this.viewModel = viewModel;
        }

        async void OnMonitorsQueryButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var q = (MonitorsQuery)thisClickedButton.CommandParameter;
            if(monitorsType==1)
            {
                await Navigation.PushAsync(new StrainMonitorsPage(new StrainMonitorsViewModel(q.Id, q.No, q.StartDateTime, q.EndDateTime)));
            }
            else
            {
                await Navigation.PushAsync(new CoordinateMonitorsPage(new CoordinateMonitorsViewModel(q.Id, q.No, q.StartDateTime, q.EndDateTime)));
            }
        }
    }
}