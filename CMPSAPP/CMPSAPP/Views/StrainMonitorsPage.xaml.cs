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
        public StrainMonitorsPage()
        {
            InitializeComponent();
        }

        async void Return_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}