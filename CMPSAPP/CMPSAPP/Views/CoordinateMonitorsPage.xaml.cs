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

        public CoordinateMonitorsPage(Guid cmprojectId)
        {
            InitializeComponent();
            BindingContext = viewModel = new CoordinateMonitorsViewModel(cmprojectId);
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
    }
}