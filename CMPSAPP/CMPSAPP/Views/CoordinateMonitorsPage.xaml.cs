using CMPSAPP.Models;
using CMPSAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CMPSAPP.Views
{
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class CoordinateMonitorsPage : ContentPage
    {
        CoordinateMonitorsViewModel viewModel;
        //public CoordinateMonitorsPage()
        //{
        //    InitializeComponent();
        //    BindingContext = viewModel = new CoordinateMonitorsViewModel();
        //}

        public CoordinateMonitorsPage(CoordinateMonitorsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        //async void Return_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PopModalAsync();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as CoordinateMonitor;
            if (item == null)
                return;
            await Navigation.PushAsync(new CoordinateMonitorsChartPage(new CoordinateMonitorsChartViewModel(item.Id)));

        }
    }
}