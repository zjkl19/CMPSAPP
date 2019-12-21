
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts;
using CMPSAPP.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace CMPSAPP.ViewModels
{
    public class CoordinateMonitorsChartViewModel : MonitorsBaseViewModel<CoordinateMonitorsChart>
    {
        public PlotModel LineModelX { get; set; }
        public PlotModel LineModelY { get; set; }
        public PlotModel LineModelZ { get; set; }
        //public ObservableCollection<CoordinateMonitorsChart> Items { get; set; }
        public List<CoordinateMonitorsChart> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        RestClient client;
        RestRequest request;

        public CoordinateMonitorsChartViewModel()
        {
            Title = "时程曲线";

        }

        public CoordinateMonitorsChartViewModel(Guid Id)
        {
            Title = "时程曲线";

            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/CoordinateMonitorsChart", Method.GET);
                request.AddParameter("Id", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    Items = JsonConvert.DeserializeObject<List<CoordinateMonitorsChart>>(v);
                }
                else
                {
                    Items = new List<CoordinateMonitorsChart>()
                    {
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS11mock",Temperature=Convert.ToDecimal(20.01) },
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS12mock",Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                Items = new List<CoordinateMonitorsChart>()
                {
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS11throw",Temperature=Convert.ToDecimal(20.01) },
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS12throw",Temperature=Convert.ToDecimal(21.32) },
                };
            }

            //Items = new ObservableCollection<CoordinateMonitorsChart>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Id));


            LineModelX = CreateLineChartX(Items);
            LineModelY = CreateLineChartY(Items);
            LineModelZ = CreateLineChartZ(Items);

            var listLeftAxis = new List<LinearAxis>();
            listLeftAxis.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "坐标",//显示标题内容
                //TitlePosition = 1,//显示标题位置
            });
            listLeftAxis.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "坐标",
            });
            listLeftAxis.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "坐标",
            });

            //var leftAxis = new LinearAxis()
            //{
            //    Position = AxisPosition.Left,
            //    Title = "坐标",//显示标题内容
            //    //TitlePosition = 1,//显示标题位置
            //};

            var listbottomAxis = new List<DateTimeAxis>();
            listbottomAxis.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd hh:mm",
                //Minimum = DateTimeAxis.ToDouble(DateTime.Now),
                //Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(1)),
                Title = "时间",
                //TitlePosition = 0,
                IntervalLength = 60,
                MinorIntervalType = DateTimeIntervalType.Seconds,
                IntervalType = DateTimeIntervalType.Seconds,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                Angle = -45,
            });
            listbottomAxis.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd hh:mm",
                Title = "时间",
                IntervalLength = 60,
                MinorIntervalType = DateTimeIntervalType.Seconds,
                IntervalType = DateTimeIntervalType.Seconds,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                Angle = -45,
            });
            listbottomAxis.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd hh:mm",
                Title = "时间",
                IntervalLength = 60,
                MinorIntervalType = DateTimeIntervalType.Seconds,
                IntervalType = DateTimeIntervalType.Seconds,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
                Angle = -45,
            });

            //var bottomAxis = new DateTimeAxis()
            //{
            //    Position = AxisPosition.Bottom,
            //    StringFormat = "yyyy-MM-dd hh:mm",
            //    //Minimum = DateTimeAxis.ToDouble(DateTime.Now),
            //    //Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(1)),
            //    Title = "时间",
            //    //TitlePosition = 0,
            //    IntervalLength = 60,
            //    MinorIntervalType = DateTimeIntervalType.Seconds,
            //    IntervalType = DateTimeIntervalType.Seconds,
            //    MajorGridlineStyle = LineStyle.Solid,
            //    MinorGridlineStyle = LineStyle.None,
            //};
            LineModelX.Axes.Add(listLeftAxis[0]);
            LineModelX.Axes.Add(listbottomAxis[0]);
            LineModelY.Axes.Add(listLeftAxis[1]);
            LineModelY.Axes.Add(listbottomAxis[1]);
            LineModelZ.Axes.Add(listLeftAxis[2]);
            LineModelZ.Axes.Add(listbottomAxis[2]);

        }

        private PlotModel CreateLineChartX(List<CoordinateMonitorsChart> items)
        {
            var model = new PlotModel { Title = "时程曲线" };


            var ls = new LineSeries { Title = "X坐标值", MarkerType = MarkerType.Circle, Smooth = true };

            for (int i = 0; i < items.Count; i++)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(items[i].MonitorTime), Convert.ToSingle(items[i].XValue)));
            }

            model.Series.Add(ls);
            return model;
        }
        private PlotModel CreateLineChartY(List<CoordinateMonitorsChart> items)
        {
            var model = new PlotModel { Title = "时程曲线" };


            var ls = new LineSeries { Title = "Y坐标值", MarkerType = MarkerType.Circle, Smooth = true };


            for (int i = 0; i < items.Count; i++)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(items[i].MonitorTime), Convert.ToSingle(items[i].XValue)));
            }

            model.Series.Add(ls);

            return model;
        }
        private PlotModel CreateLineChartZ(List<CoordinateMonitorsChart> items)
        {
            var model = new PlotModel { Title = "时程曲线" };

            var ls = new LineSeries { Title = "Z坐标值", MarkerType = MarkerType.Circle, Smooth = true };


            for (int i = 0; i < items.Count; i++)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(items[i].MonitorTime), Convert.ToSingle(items[i].ZValue)));
            }

            model.Series.Add(ls);
            return model;
        }

    }
}