using MtbVisualizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mtbVisualizer.Services
{
    public interface IMapCoordinatesService
    {
        Task<IEnumerable<ActivityCoordinates>> GetActivityCoordinates(String accessToken, int id);
    }
}
