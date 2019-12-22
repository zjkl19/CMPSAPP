using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMPSAPP.Services
{
    /// <summary>
    /// 一般数据提取的接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonDataStore<T>
    {
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetItemsAsync(Guid cmprojectId, bool forceRefresh = false);
    }
}
