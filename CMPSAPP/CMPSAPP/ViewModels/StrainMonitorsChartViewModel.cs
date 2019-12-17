
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
    public class StrainMonitorsChartViewModel : MonitorsBaseViewModel<StrainMonitorsChart>
    {
        public PlotModel LineModel { get; set; }
        //public ObservableCollection<StrainMonitorsChart> Items { get; set; }
        public List<StrainMonitorsChart> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        RestClient client;
        RestRequest request;

        public StrainMonitorsChartViewModel()
        {
            Title = "时程曲线";

            
        }

        public StrainMonitorsChartViewModel(Guid Id)
        {
            Title = "时程曲线";

            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/StrainMonitorsChart", Method.GET);
                request.AddParameter("Id", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    Items = JsonConvert.DeserializeObject<List<StrainMonitorsChart>>(v);
                }
                else
                {
                    Items = new List<StrainMonitorsChart>()
                    {
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS11mock",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS12mock",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                Items = new List<StrainMonitorsChart>()
                {
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS11throw",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS12throw",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                };
            }
            
            //Items = new ObservableCollection<StrainMonitorsChart>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Id));


            LineModel = CreateLineChart(Items);

            var leftAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = "应变",//显示标题内容
                //TitlePosition = 1,//显示标题位置

            };

            var bottomAxis = new DateTimeAxis()
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
            };
            LineModel.Axes.Add(leftAxis);
            LineModel.Axes.Add(bottomAxis);

        }

        private PlotModel CreateLineChart(List<StrainMonitorsChart> items)
        {
            var model = new PlotModel { Title = "时程曲线" };

            //var ls = new LineSeries
            //{
            //    StrokeThickness = .25,
            //};
            var ls = new LineSeries();


            for (int i = 0; i < items.Count; i++)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(items[i].MonitorTime), Convert.ToSingle(items[i].StrainValue)));        
            }
            ls.DataFieldX = "11,12,13,14";

            model.Series.Add(ls);
            return model;
        }

        async Task ExecuteLoadItemsCommand(Guid Id)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(Id, true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}