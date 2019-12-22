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
        public MonitorsQueryNavigationPage()
        {
            InitializeComponent();
        }

        public MonitorsQueryNavigationPage(MonitorsQueryNavigationViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnStrainMonitorQueryButton_Clicked(object sender, EventArgs e)
        {

            var thisClickedButton = sender as Button;
            var q = (MonitorsQueryViewModel)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new StrainMonitorsPage(new StrainMonitorsViewModel(q.Id,q.No,q.StartDateTime,q.EndDateTime)));
        }
    }
}