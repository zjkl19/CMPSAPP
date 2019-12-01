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
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class StrainMonitorsPage : ContentPage
    {
        StrainMonitorsViewModel viewModel;
        //public StrainMonitorsPage()
        //{
        //    InitializeComponent();
        //    BindingContext = viewModel = new StrainMonitorsViewModel();
        //}

        public StrainMonitorsPage(Guid cmprojectId)
        {
            InitializeComponent();
            BindingContext = viewModel = new StrainMonitorsViewModel(cmprojectId);
        }

        async void Return_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}