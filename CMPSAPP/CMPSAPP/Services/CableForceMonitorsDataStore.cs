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
    public class CableForceMonitorsDataStore : IMonitorsDataStore<CableForceMonitor>
    {
        List<CableForceMonitor> items;
        RestClient client;
        RestRequest request;

        public CableForceMonitorsDataStore()
        {
            items = new List<CableForceMonitor>()
            {
                new CableForceMonitor { Id = Guid.NewGuid(), No="X1",Temperature=Convert.ToDecimal(20.01) },
                new CableForceMonitor { Id = Guid.NewGuid(), No="X2",Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public List<CableForceMonitor> GetCableForceMonitorsDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/CableForceMonitor", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<CableForceMonitor>>(v);
                }
                else
                {
                    items = new List<CableForceMonitor>()
                    {
                        new CableForceMonitor { Id = Guid.NewGuid(), No="Z11mock",Temperature=Convert.ToDecimal(20.01) },
                        new CableForceMonitor { Id = Guid.NewGuid(), No="Z12mock",Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<CableForceMonitor>()
                {
                       new CableForceMonitor { Id = Guid.NewGuid(), No="Z11throw",Temperature=Convert.ToDecimal(20.01) },
                       new CableForceMonitor { Id = Guid.NewGuid(), No="Z12throw",Temperature=Convert.ToDecimal(21.32) },
                };
            }
            return items;
        }

        public async Task<CableForceMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CableForceMonitor>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false)
        {
            return await Task.FromResult(GetCableForceMonitorsDataByCMProjectId(cmprojectId));
        }
    }
}
