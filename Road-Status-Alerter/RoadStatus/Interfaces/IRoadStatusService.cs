using RoadStatus.Models;
using System.Threading.Tasks;

namespace RoadStatus.Interfaces
{
    public interface IRoadStatusService
    {
        Task<string> GetRoadStatusAsync(ApiSettings settings, string roadName);
    }
}