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
    public class StrainMonitorsChartDataStore : IMonitorsDataStore<StrainMonitorsChart>
    {
        List<StrainMonitorsChart> items;

        RestClient client;
        RestRequest request;

        public StrainMonitorsChartDataStore()
        {
            items = new List<StrainMonitorsChart>()
            {
                new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS11",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS12",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
            };

        }

        public List<StrainMonitorsChart> GetStrainMonitorsChartDataById(Guid Id)
        {
            try
            {
                //client = new RestClient("http://218.66.5.89:8310/");
                //client = new RestClient(App.ServerURL);
                //request = new RestRequest("api/APIStrainMonitor", Method.GET);
                //request.AddParameter("CMProjectId", Id);
                //var resp = client.Execute(request);
                //if (resp.StatusCode == HttpStatusCode.OK)
                //{
                //    var v = resp.Content;
                //    items = JsonConvert.DeserializeObject<List<StrainMonitorsChart>>(v);
                //}
                //else
                //{
                    items = new List<StrainMonitorsChart>()
                    {
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS11mock",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS12mock",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                    };
                //}

            }
            catch (Exception)
            {

                items = new List<StrainMonitorsChart>()
                {
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS11throw",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitorsChart { Id = Guid.NewGuid(), No="TS12throw",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                };
            }
            return items;
        }

        public async Task<StrainMonitorsChart> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<StrainMonitorsChart>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<StrainMonitorsChart>> GetItemsAsync(Guid Id,bool forceRefresh = false)
        {
            //return await Task.FromResult(items);
            return await Task.FromResult(GetStrainMonitorsChartDataById(Id));
           
        }

        public async Task<IEnumerable<StrainMonitorsChart>> GetItemsAsync(Guid cmprojectId, string No, DateTime? StartDateTime, DateTime? EndDateTime, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
