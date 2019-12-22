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
    public class CoordinateMonitorsDataStore : IMonitorsDataStore<CoordinateMonitor>
    {
        List<CoordinateMonitor> items;
        RestClient client;
        RestRequest request;

        public CoordinateMonitorsDataStore()
        {
            items = new List<CoordinateMonitor>()
            {
                new CoordinateMonitor { Id = Guid.NewGuid(), No="Z1",TheoryZValue=Convert.ToDecimal(18.21),Temperature=Convert.ToDecimal(20.01) },
                new CoordinateMonitor { Id = Guid.NewGuid(), No="Z2",TheoryZValue=Convert.ToDecimal(19.64),Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public List<CoordinateMonitor> GetCoordinateMonitorsDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/CoordinateMonitor", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<CoordinateMonitor>>(v);
                }
                else
                {
                    items = new List<CoordinateMonitor>()
                    {
                        new CoordinateMonitor { Id = Guid.NewGuid(), No="Z11mock",ZValue=Convert.ToDecimal(19.61),Temperature=Convert.ToDecimal(20.01) },
                        new CoordinateMonitor { Id = Guid.NewGuid(), No="Z12mock",ZValue=Convert.ToDecimal(13.16),Temperature=Convert.ToDecimal(21.32) },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<CoordinateMonitor>()
                {
                       new CoordinateMonitor { Id = Guid.NewGuid(), No="Z11throw",ZValue=Convert.ToDecimal(19.61),Temperature=Convert.ToDecimal(20.01) },
                       new CoordinateMonitor { Id = Guid.NewGuid(), No="Z12throw",ZValue=Convert.ToDecimal(13.16),Temperature=Convert.ToDecimal(21.32) },                
                };
            }
            return items;
        }

        public async Task<CoordinateMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CoordinateMonitor>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false)
        {
            return await Task.FromResult(GetCoordinateMonitorsDataByCMProjectId(cmprojectId));
        }

        public async Task<IEnumerable<CoordinateMonitor>> GetItemsAsync(Guid cmprojectId, string No, DateTime? StartDateTime, DateTime? EndDateTime, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
