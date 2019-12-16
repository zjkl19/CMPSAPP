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
    public class LeanMonitorsDataStore : IMonitorsDataStore<LeanMonitor>
    {
        List<LeanMonitor> items;
        RestClient client;
        RestRequest request;

        public LeanMonitorsDataStore()
        {
            items = new List<LeanMonitor>()
            {
                new LeanMonitor { Id = Guid.NewGuid(), No="Z1",Temperature=Convert.ToDecimal(20.01) },
                new LeanMonitor { Id = Guid.NewGuid(), No="Z2",Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public List<LeanMonitor> GetLeanMonitorsDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/LeanMonitor", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<LeanMonitor>>(v);
                }
                else
                {
                    items = new List<LeanMonitor>()
                    {
                        new LeanMonitor { Id = Guid.NewGuid(), No="Z11mock",Temperature=Convert.ToDecimal(20.01) },
                        new LeanMonitor { Id = Guid.NewGuid(), No="Z12mock",Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<LeanMonitor>()
                {
                       new LeanMonitor { Id = Guid.NewGuid(), No="Z11throw",Temperature=Convert.ToDecimal(20.01) },
                       new LeanMonitor { Id = Guid.NewGuid(), No="Z12throw",Temperature=Convert.ToDecimal(21.32) },                
                };
            }
            return items;
        }

        public async Task<LeanMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<LeanMonitor>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false)
        {
            return await Task.FromResult(GetLeanMonitorsDataByCMProjectId(cmprojectId));
        }
    }
}
