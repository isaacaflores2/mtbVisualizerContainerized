using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace StravaVisualizer.Models
{
    public class Map
    {
        public IEnumerable<SummaryActivity> Activities { get; set; }
        public IEnumerable<ActivityCoordinates> Coordinates { get; set;}

        public Map()
        {
            Activities = null;
            Coordinates = new List<ActivityCoordinates>();
        }

        public void extractCoordinates()
        {
            foreach(SummaryActivity summary in Activities)
            {
                if (summary == null || summary.StartLatlng == null)
                    continue;                

                float?[] latlongArray = summary.StartLatlng.ToArray();
                double latitute = Convert.ToDouble(latlongArray[0]);
                double longitude = Convert.ToDouble(latlongArray[0]);

                GeoCoordinate start = new GeoCoordinate(latitute, longitude);
                GeoCoordinate end = null;
                ActivityCoordinates activity = new ActivityCoordinates(start, end);
                Coordinates.Append(activity);
                
            }
        }
    }
}
