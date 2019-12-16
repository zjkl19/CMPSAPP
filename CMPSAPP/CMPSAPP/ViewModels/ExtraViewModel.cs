
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;

namespace CMPSAPP.ViewModels
{
    public class ExtraViewModel : BaseViewModel
    {
        public PlotModel PieModel { get; set; }

        public IEnumerable<Entry> Entries;
        public ExtraViewModel()
        {
            Title = "关于";

            PieModel = CreatePieChart();

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

        public PlotModel CreateAreaChart()
        {
            var plotModel1 = new PlotModel { Title = "AreaSeries with crossing lines" };
            var areaSeries1 = new AreaSeries();
            areaSeries1.Points.Add(new DataPoint(0, 50));
            areaSeries1.Points.Add(new DataPoint(10, 140));
            areaSeries1.Points.Add(new DataPoint(20, 60));
            areaSeries1.Points2.Add(new DataPoint(0, 60));
            areaSeries1.Points2.Add(new DataPoint(5, 80));
            areaSeries1.Points2.Add(new DataPoint(20, 70));
            plotModel1.Series.Add(areaSeries1);
            return plotModel1;
        }
        private PlotModel CreatePieChart()
        {
            var model = new PlotModel { Title = "World population by continent" };

            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0
            };

            // http://www.nationsonline.org/oneworld/world_population.htm
            // http://en.wikipedia.org/wiki/Continent
            ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Asia", 4157));
            ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = false });
            model.Series.Add(ps);
            return model;
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