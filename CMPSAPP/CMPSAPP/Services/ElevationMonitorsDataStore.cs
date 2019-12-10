using CMPSAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    public class ElevationMonitorsDataStore : IMonitorsDataStore<ElevationMonitor>
    {
        readonly List<ElevationMonitor> items;

        public ElevationMonitorsDataStore()
        {
            items = new List<ElevationMonitor>()
            {
                new ElevationMonitor { Id = Guid.NewGuid(), No="LZ1",ElevationValue=Convert.ToDecimal(8.9223),Temperature=Convert.ToDecimal(20.01) },
                new ElevationMonitor { Id = Guid.NewGuid(), No="LZ2",ElevationValue=Convert.ToDecimal(9.2165),Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public async Task<ElevationMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ElevationMonitor>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
