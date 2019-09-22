using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace StravaVisualizer.Models
{
    public struct ActivityCoordinates
    {
        public GeoCoordinate Start { get; set; }
        public GeoCoordinate End { get; set; }
        public ICollection<GeoCoordinate> Route { get; set; }

        public ActivityCoordinates(GeoCoordinate start, GeoCoordinate end)
        {
            Start = start;
            End = end;
            Route = null; 
        }
    }
}
