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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CableForceMonitorsPage : ContentPage
    {
        CableForceMonitorsViewModel viewModel;
        public CableForceMonitorsPage(CableForceMonitorsViewModel viewModel)
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
    }
}