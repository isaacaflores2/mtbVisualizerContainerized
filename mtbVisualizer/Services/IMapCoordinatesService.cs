using MtbVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mtbVisualizer.Services
{
    interface IMapCoordinatesService
    {
        Task<IEnumerable<ActivityCoordinates>> GetActivityCoordinates(String accessToken, int id);
    }
}
