
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;
using CMPSAPP.Models;

namespace CMPSAPP.ViewModels
{
    public class StrainMonitorsChartViewModel : BaseViewModel
    {
        public Entry[] Entries;

        public StrainMonitorsChartViewModel()
        {
            Title = "时程曲线";

            Entries = new[]
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

        }

        public StrainMonitorsChartViewModel(StrainMonitor item)
        {
            Title = "时程曲线";

            Entries = new[]
             {
                 new Entry(212)
                 {
                     Label = item.No,
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

        }

        public Chart SinglePointTimeHistoryChart
        {
            get
            {
                return new LineChart() {
                    LabelTextSize = 30f,
                    Entries = Entries };
            }
        }

    }
}