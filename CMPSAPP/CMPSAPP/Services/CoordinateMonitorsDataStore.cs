using CMPSAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    public class CoordinateMonitorsDataStore : IMonitorsDataStore<CoordinateMonitor>
    {
        readonly List<CoordinateMonitor> items;

        public CoordinateMonitorsDataStore()
        {
            items = new List<CoordinateMonitor>()
            {
                new CoordinateMonitor { Id = Guid.NewGuid(), No="Z1",TheoryZValue=Convert.ToDecimal(18.21),Temperature=Convert.ToDecimal(20.01) },
                new CoordinateMonitor { Id = Guid.NewGuid(), No="Z2",TheoryZValue=Convert.ToDecimal(19.64),Temperature=Convert.ToDecimal(21.32) },
            };
        }

        public async Task<CoordinateMonitor> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CoordinateMonitor>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
