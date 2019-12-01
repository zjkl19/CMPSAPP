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
    public class StrainMonitorsDataStore : IStrainMonitorsDataStore<StrainMonitor>
    {
        List<StrainMonitor> items;

        RestClient client;
        RestRequest request;

        public StrainMonitorsDataStore()
        {
            items = new List<StrainMonitor>()
            {
                new StrainMonitor { Id = Guid.NewGuid(), No="TS11",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                new StrainMonitor { Id = Guid.NewGuid(), No="TS12",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
            };

        }

        public List<StrainMonitor> GetStrainMonitorsDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient("http://192.168.1.107/");
                request = new RestRequest("api/APIStrainMonitor", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<StrainMonitor>>(v);
                }
                else
                {
                    items = new List<StrainMonitor>()
                    {
                        new StrainMonitor { Id = Guid.NewGuid(), No="TS11mock",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitor { Id = Guid.NewGuid(), No="TS12mock",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<StrainMonitor>()
                {
                        new StrainMonitor { Id = Guid.NewGuid(), No="TS11throw",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                        new StrainMonitor { Id = Guid.NewGuid(), No="TS12throw",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
                };
            }
            return items;
        }

        public async Task<StrainMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<StrainMonitor>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<StrainMonitor>> GetItemsAsync(Guid cmprojectId,bool forceRefresh = false)
        {
            //return await Task.FromResult(items);
            return await Task.FromResult(GetStrainMonitorsDataByCMProjectId(cmprojectId));
           
        }
    }
}
