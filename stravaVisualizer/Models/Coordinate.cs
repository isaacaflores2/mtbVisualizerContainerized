using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    public struct Coordinate
    {
        public float? Latitude;
        public float? Longitude;

        public Coordinate(float? latitude, float? longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        
    }
}
