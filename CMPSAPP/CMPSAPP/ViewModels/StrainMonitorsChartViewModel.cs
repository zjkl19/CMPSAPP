
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

namespace CMPSAPP.ViewModels
{
    public class StrainMonitorsChartViewModel : MonitorsBaseViewModel<StrainMonitorsChart>
    {
        //public ObservableCollection<StrainMonitorsChart> Items { get; set; }
        public List<StrainMonitorsChart> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public IEnumerable<Entry> Entries;

        RestClient client;
        RestRequest request;

        public StrainMonitorsChartViewModel()
        {
            Title = "时程曲线";

            //Entries = new[]
            // {
            //     new Entry(212)
            //     {
            //         Label = "S1",
            //         ValueLabel = "212",
            //         Color = SKColor.Parse("#2c3e50")
            //     },
            //     new Entry(248)
            //     {
            //         Label = "S2",
            //         ValueLabel = "248",
            //         Color = SKColor.Parse("#77d065")
            //     },
            //     new Entry(128)
            //     {
            //         Label = "S3",
            //         ValueLabel = "128",
            //         Color = SKColor.Parse("#b455b6")
            //     },
            //     new Entry(256)
            //     {
            //         Label = "S4",
            //         ValueLabel = "256",
            //         Color = SKColor.Parse("#b455b6")
            //     },
            //     new Entry(514)
            //     {
            //         Label = "S5",
            //         ValueLabel = "514",
            //         Color = SKColor.Parse("#3498db")
            //} };

            //var chart = new LineChart() { Entries = Entries };

        }

        public StrainMonitorsChartViewModel(Guid Id)
        {
            Title = "时程曲线";

            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/APIStrainMonitorsChart", Method.GET);
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

            var lst = new List<Entry>();

            for (int i = 0; i < Items.Count; i++)
            {
                lst.Add(new Entry(Convert.ToSingle(Items[i].StrainValue))
                {
                    //Label = Items[i].MonitorTime.ToString("u"),
                    Label = Convert.ToString(i+1),
                    ValueLabel = Items[i].StrainValue.ToString(),
                    Color = SKColor.Parse("#2c3e50")
                });
            }

            Entries = lst.AsQueryable();

        }

        public Chart SinglePointTimeHistoryChart
        {
            get
            {

                return new LineChart() {
                    LabelTextSize = 30f,
                    //LabelOrientation = Microcharts.Orientation.Vertical,
                    Entries = Entries };
            }
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