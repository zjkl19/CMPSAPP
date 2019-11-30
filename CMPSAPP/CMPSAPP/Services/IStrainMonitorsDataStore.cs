using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    public interface IStrainMonitorsDataStore<T>
    {
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
