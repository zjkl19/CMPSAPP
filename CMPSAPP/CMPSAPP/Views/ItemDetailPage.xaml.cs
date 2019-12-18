using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CMPSAPP.Models;
using CMPSAPP.ViewModels;

namespace CMPSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Item 1",
                ContractNo = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void OnProcedureButton_Clicked(object sender, EventArgs e)
        {

            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new ProcedurePage(new ProcedureViewModel(cmprojectId)));
        }

        async void OnStrainMonitorButton_Clicked(object sender, EventArgs e)
        {

            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new StrainMonitorsPage(new StrainMonitorsViewModel(cmprojectId)));
        }

        async void OnCoordinateMonitorButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new CoordinateMonitorsPage(new CoordinateMonitorsViewModel(cmprojectId)));
        }

        async void OnElevationMonitorButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new ElevationMonitorsPage(new ElevationMonitorsViewModel(cmprojectId)));
        }

        async void OnLeanMonitorButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new LeanMonitorsPage(new LeanMonitorsViewModel(cmprojectId)));
        }

        async void OnCableForceMonitorButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new CableForceMonitorsPage(new CableForceMonitorsViewModel(cmprojectId)));
        }

    }
}