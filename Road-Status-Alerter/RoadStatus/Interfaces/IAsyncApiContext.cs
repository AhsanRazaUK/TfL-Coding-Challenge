using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadStatus.Interfaces
{
    public interface IAsyncApiContext
    {
        Task<IEnumerable<T>> GetObjectsAsync<T>(string baseUri, string actionString);
    }
}
