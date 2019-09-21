using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    public class Map
    {
        IList<SummaryActivity> Activities { get; set; }
        IList<ActivityCoordinates> Coordinates { get; set;}

        public void extractCoordinates()
        {
            
        }
    }
}
