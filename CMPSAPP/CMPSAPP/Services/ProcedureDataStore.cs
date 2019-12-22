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
    public class ProcedureDataStore : IMonitorsDataStore<Procedure>
    {
        List<Procedure> items;

        RestClient client;
        RestRequest request;

        public ProcedureDataStore()
        {
            items = new List<Procedure>()
            {
                new Procedure { Id = Guid.NewGuid() },
                new Procedure { Id = Guid.NewGuid() },
            };

        }

        public List<Procedure> GetProcedureDataByCMProjectId(Guid Id)
        {
            try
            {
                client = new RestClient(App.ServerURL);
                request = new RestRequest("api/Procedure/ListByCMProjectId", Method.GET);
                request.AddParameter("CMProjectId", Id);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<Procedure>>(v);
                }
                else
                {
                    items = new List<Procedure>()
                    {
                        new Procedure { Id = Guid.NewGuid() },
                        new Procedure { Id = Guid.NewGuid() },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<Procedure>()
                {
                        new Procedure { Id = Guid.NewGuid() },
                        new Procedure { Id = Guid.NewGuid() },
                };
            }
            return items;
        }

        public async Task<Procedure> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Procedure>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Procedure>> GetItemsAsync(Guid cmprojectId,bool forceRefresh = false)
        {
            //return await Task.FromResult(items);
            return await Task.FromResult(GetProcedureDataByCMProjectId(cmprojectId));
           
        }

        public async Task<IEnumerable<Procedure>> GetItemsAsync(Guid cmprojectId, string No, DateTime? StartDateTime, DateTime? EndDateTime, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}
