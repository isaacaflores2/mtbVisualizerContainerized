using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Map
{
    public interface IMap
    {        
        ICollection<ActivityCoordinates> getCoordinates(IEnumerable<SummaryActivity> activities);
    }
}
