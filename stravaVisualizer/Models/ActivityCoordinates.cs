using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace StravaVisualizer.Models
{
    public struct ActivityCoordinates
    {
        public Coordinate Start { get; set; }
        public Coordinate End { get; set; }
        public ICollection<Coordinate> Route { get; set; }

        public ActivityCoordinates(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
            Route = null; 
        }
    }
}
