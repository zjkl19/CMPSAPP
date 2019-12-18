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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcedurePage : ContentPage
    {
        ProcedureViewModel viewModel;
        public ProcedurePage()
        {
            InitializeComponent();
        }

        public ProcedurePage(ProcedureViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Procedure;
            if (item == null)
                return;
            await Navigation.PushAsync(new ProcedureDetailPage(new ProcedureDetailViewModel(item.Id)));

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}