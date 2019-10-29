using IO.Swagger.Model;
using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Models.Map
{
    public interface IMap
    {        
        ICollection<Coordinate> getCoordinates(IEnumerable<VisualActivity> activities);
        ICollection<Coordinate> getCoordinatesByType(IEnumerable<VisualActivity> activities, ActivityType type);
    }
}
