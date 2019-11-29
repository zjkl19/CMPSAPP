using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMPSAPP.Models;

namespace CMPSAPP.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid(), Name = "洪塘大桥", ContractNo="This is an item description." },
                new Item { Id = Guid.NewGuid(), Name = "过溪桥", ContractNo="This is an item description." },
                new Item { Id = Guid.NewGuid(), Name = "Third item", ContractNo="This is an item description." },
                new Item { Id = Guid.NewGuid(), Name = "Fourth item", ContractNo="This is an item description." },
                new Item { Id = Guid.NewGuid(), Name = "Fifth item", ContractNo="This is an item description." },
                new Item { Id = Guid.NewGuid(), Name = "Sixth item", ContractNo="This is an item description." }
            };
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