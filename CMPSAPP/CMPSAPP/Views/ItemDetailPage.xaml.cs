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

        async void OnStrainMonitorButton_Clicked(object sender, EventArgs e)
        {

            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new StrainMonitorsPage(cmprojectId));
        }

        async void OnCoordinateMonitorButton_Clicked(object sender, EventArgs e)
        {
            var thisClickedButton = sender as Button;
            var cmprojectId = (Guid)thisClickedButton.CommandParameter;
            await Navigation.PushAsync(new CoordinateMonitorsPage(cmprojectId));
        }

        async void OnElevationMonitorButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ElevationMonitorsPage());
        }

    }
}