using CMPSAPP.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    public class CoordinateMonitorsChartDataStore : IMonitorsDataStore<CoordinateMonitorsChart>
    {
        List<CoordinateMonitorsChart> items;

        RestClient client;
        RestRequest request;

        public CoordinateMonitorsChartDataStore()
        {
            items = new List<CoordinateMonitorsChart>()
            {
                new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS11",Temperature=Convert.ToDecimal(20.01) },
                new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS12",Temperature=Convert.ToDecimal(21.32) },
            };

        }

        public List<CoordinateMonitorsChart> GetCoordinateMonitorsChartDataById(Guid Id)
        {
            try
            {
                //client = new RestClient("http://218.66.5.89:8310/");
                //client = new RestClient(App.ServerURL);
                //request = new RestRequest("api/APICoordinateMonitor", Method.GET);
                //request.AddParameter("CMProjectId", Id);
                //var resp = client.Execute(request);
                //if (resp.StatusCode == HttpStatusCode.OK)
                //{
                //    var v = resp.Content;
                //    items = JsonConvert.DeserializeObject<List<CoordinateMonitorsChart>>(v);
                //}
                //else
                //{
                    items = new List<CoordinateMonitorsChart>()
                    {
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS11mock",Temperature=Convert.ToDecimal(20.01) },
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS12mock",Temperature=Convert.ToDecimal(21.32) },
                    };
                //}

            }
            catch (Exception)
            {

                items = new List<CoordinateMonitorsChart>()
                {
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS11throw",Temperature=Convert.ToDecimal(20.01) },
                        new CoordinateMonitorsChart { Id = Guid.NewGuid(), No="TS12throw",Temperature=Convert.ToDecimal(21.32) },
                };
            }
            return items;
        }

        public async Task<CoordinateMonitorsChart> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CoordinateMonitorsChart>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<CoordinateMonitorsChart>> GetItemsAsync(Guid Id,bool forceRefresh = false)
        {
            //return await Task.FromResult(items);
            return await Task.FromResult(GetCoordinateMonitorsChartDataById(Id));
           
        }
    }
}
