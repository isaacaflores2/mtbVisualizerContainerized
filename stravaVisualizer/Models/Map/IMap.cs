using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Map
{
    public interface IMap
    {        
        ICollection<Coordinate> getCoordinates(IEnumerable<SummaryActivity> activities);
        ICollection<Coordinate> getCoordinatesByType(IEnumerable<SummaryActivity> activities, ActivityType type);
    }
}
