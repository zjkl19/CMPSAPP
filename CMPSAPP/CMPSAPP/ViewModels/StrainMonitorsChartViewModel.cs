
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;

namespace CMPSAPP.ViewModels
{
    public class StrainMonitorsChartViewModel : BaseViewModel
    {
        public Entry[] Entries;
        public StrainMonitorsChartViewModel()
        {
            Title = "时程曲线";

            this.Entries = new[]
             {
                 new Entry(212)
                 {
                     Label = "S1",
                     ValueLabel = "212",
                     Color = SKColor.Parse("#2c3e50")
                 },
                 new Entry(248)
                 {
                     Label = "S2",
                     ValueLabel = "248",
                     Color = SKColor.Parse("#77d065")
                 },
                 new Entry(128)
                 {
                     Label = "S3",
                     ValueLabel = "128",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(256)
                 {
                     Label = "S4",
                     ValueLabel = "256",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(514)
                 {
                     Label = "S5",
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