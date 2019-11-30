using CMPSAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    public class StrainMonitorsDataStore : IStrainMonitorsStore<StrainMonitor>
    {
        readonly List<StrainMonitor> items;

        public StrainMonitorsDataStore()
        {
            items = new List<StrainMonitor>()
            {
                new StrainMonitor { Id = Guid.NewGuid(), No="TS11",StrainValue=Convert.ToDecimal(129.11),Temperature=Convert.ToDecimal(20.01) },
                new StrainMonitor { Id = Guid.NewGuid(), No="TS12",StrainValue=Convert.ToDecimal(132.11),Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public async Task<StrainMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<StrainMonitor>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
