using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CMPSAPP.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CMPSAPP.Services
{
    public class RealDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        RestClient client;// = new RestClient(MyApplication.url);
        RestRequest request;// = new RestRequest("api/APIassess/SummaryQueryProductValue", Method.GET);


        public RealDataStore()
        {
            try
            {
                client = new RestClient("http://192.168.1.107/");
                request = new RestRequest("api/APICMProject", Method.GET);
                var resp = client.Execute(request);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var v = resp.Content;
                    items = JsonConvert.DeserializeObject<List<Item>>(v);

                }
                else
                {
                    items = new List<Item>()
                    {
                        new Item { Id = Guid.NewGuid(), Name = "洪塘大桥real", ContractNo="HT02CB1900201" },
                        new Item { Id = Guid.NewGuid(), Name = "过溪桥real", ContractNo="HT02CB1900202" },
                        new Item { Id = Guid.NewGuid(), Name = "芝山大桥real", ContractNo="HT02CB1900203" },
                    };
                }

            }
            catch (Exception)
            {

                items = new List<Item>()
                    {
                        new Item { Id = Guid.NewGuid(), Name = "洪塘大桥realThrow", ContractNo="HT02CB1900201" },
                        new Item { Id = Guid.NewGuid(), Name = "过溪桥realThrow", ContractNo="HT02CB1900202" },
                        new Item { Id = Guid.NewGuid(), Name = "芝山大桥realThrow", ContractNo="HT02CB1900203" },
                    };
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}