
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace CMPSAPP.ViewModels
{
    public class ExtraViewModel : BaseViewModel
    {
        public Entry[] Entries;
        public ExtraViewModel()
        {
            Title = "关于";

            this.Entries = new[]
             {
                 new Entry(212)
                 {
                     Label = "UWP",
                     ValueLabel = "212",
                     Color = SKColor.Parse("#2c3e50")
                 },
                 new Entry(248)
                 {
                     Label = "Android",
                     ValueLabel = "248",
                     Color = SKColor.Parse("#77d065")
                 },
                 new Entry(128)
                 {
                     Label = "iOS",
                     ValueLabel = "128",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(256)
                 {
                     Label = "\u3059\u306a",
                     ValueLabel = "256",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(514)
                 {
                     Label = "Test",
                     ValueLabel = "514",
                     Color = SKColor.Parse("#3498db")
            } };
            
            var chart = new LineChart() { Entries = Entries };


            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://www.fjjky.com")));
        }

        public Chart Chart1
        {
            get
            {
                return new LineChart() {
                    LabelTextSize = 30f,
                    Entries = Entries };
            }
        }

        public ICommand OpenWebCommand { get; }
    }
}