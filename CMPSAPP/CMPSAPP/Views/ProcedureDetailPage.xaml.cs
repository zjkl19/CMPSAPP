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
    public partial class ProcedureDetailPage : ContentPage
    {
        ProcedureDetailViewModel viewModel;

        public ProcedureDetailPage(ProcedureDetailViewModel viewModel)
        {
            InitializeComponent();

            //BindingContext = this.viewModel = viewModel;

            WebView webView = new WebView
            {
                
                Source = new UrlWebViewSource
                {
                    Url = viewModel.SurveyPointURL,
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = new StackLayout
            {
                Children =
            {
                webView
            }
            };
        }

    }
}