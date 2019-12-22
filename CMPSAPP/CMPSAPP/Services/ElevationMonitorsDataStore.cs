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
    public class ElevationMonitorsDataStore : IMonitorsDataStore<ElevationMonitor>
    {
        List<ElevationMonitor> items;
        RestClient client;
        RestRequest request;

        public ElevationMonitorsDataStore()
        {
            items = new List<ElevationMonitor>()
            {
                new ElevationMonitor { Id = Guid.NewGuid(), No="X1",Temperature=Convert.ToDecimal(20.01) },
                new ElevationMonitor { Id = Guid.NewGuid(), No="X2",Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public List<ElevationMonitor> GetElevationMonitorsDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/ElevationMonitor", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<ElevationMonitor>>(v);
                }
                else
                {
                    items = new List<ElevationMonitor>()
                    {
                        new ElevationMonitor { Id = Guid.NewGuid(), No="Z11mock",Temperature=Convert.ToDecimal(20.01) },
                        new ElevationMonitor { Id = Guid.NewGuid(), No="Z12mock",Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<ElevationMonitor>()
                {
                       new ElevationMonitor { Id = Guid.NewGuid(), No="Z11throw",Temperature=Convert.ToDecimal(20.01) },
                       new ElevationMonitor { Id = Guid.NewGuid(), No="Z12throw",Temperature=Convert.ToDecimal(21.32) },
                };
            }
            return items;
        }

        public async Task<ElevationMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ElevationMonitor>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false)
        {
            return await Task.FromResult(GetElevationMonitorsDataByCMProjectId(cmprojectId));
        }

        public async Task<IEnumerable<ElevationMonitor>> GetItemsAsync(Guid cmprojectId, string No, DateTime? StartDateTime, DateTime? EndDateTime, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
