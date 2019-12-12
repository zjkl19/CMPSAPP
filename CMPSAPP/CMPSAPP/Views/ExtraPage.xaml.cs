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
    public partial class ExtraPage : ContentPage
    {
        ExtraViewModel viewModel;
        public ExtraPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExtraViewModel();
        }
    }
}