using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using StravaVisualizer.Models.Map;

namespace StravaVisualizer.Models.Map
{
    public class Map : IMap
    {
        public IEnumerable<SummaryActivity> Activities { get; set; }
        public ICollection<Coordinate> Coordinates { get; set;}
        public ICollection<Pin> Pins { get; set; }
        IDictionary<GeoCoordinate, int> LocationsCount { get; set; }

        public Map()
        {
            Activities = null;
            Coordinates = new List<Coordinate>();
            Pins = new List<Pin>();
            LocationsCount = new Dictionary<GeoCoordinate, int>();
        }

        public ICollection<Coordinate> getCoordinates(IEnumerable<SummaryActivity> activities)
        {
            Activities = activities ?? throw new ArgumentNullException("Activities is null");
            extractCoordinates();
            return Coordinates;
        }

        public void extractCoordinates()
        {            
            foreach(SummaryActivity summary in Activities)
            {
                if (summary == null || summary.StartLatlng == null)
                    continue;          
                
                addCoordinate(summary);                
            }
        }

        public void addCoordinate(SummaryActivity summary)
        {
           

            float?[] latlongArray = summary.StartLatlng.ToArray();
            Coordinates.Add(new Coordinate(latlongArray[0], latlongArray[1]));
        }

        public ICollection<Coordinate> getCoordinatesByType(IEnumerable<SummaryActivity> activities, ActivityType type)
        {
            if (activities == null)
                throw new ArgumentNullException("Activities is null");

            var activitiesForType = from activity in activities
                                    where activity.Type == type
                                    select activity;

            Activities = activitiesForType;
            extractCoordinates();
            return Coordinates;
        }

        public void generatePinsByType(ActivityType type)
        {
            var ActivitiesByType = from activity in Activities
                                   where activity.Type == type
                                   select activity;
            
            foreach (SummaryActivity summary in ActivitiesByType)
            {
                if (summary == null || summary.StartLatlng == null)
                    continue;

                addCoordinateLocationsCount(summary);
                addCoordinate(summary);
            }

            foreach(var coordinate in LocationsCount.Keys)
            {
                Pin pin = new Pin();
                pin.Location = coordinate;
                pin.Text = Convert.ToString(LocationsCount[coordinate]);
                Pins.Add(pin);
            }
        }

        public void addCoordinateLocationsCount(SummaryActivity summary)
        {
            float?[] latlongArray = summary.StartLatlng.ToArray();
            double latitute = Convert.ToDouble(latlongArray[0]);
            double longitude = Convert.ToDouble(latlongArray[1]);

            GeoCoordinate coordinate = new GeoCoordinate(latitute, longitude);
            if (LocationsCount.ContainsKey(coordinate))
            {
                LocationsCount.TryGetValue(coordinate, out var count);
                count++;
                LocationsCount[coordinate] = count;
            }
            else
            {
                LocationsCount.Add(coordinate, 1);
            }
        }

       
    }
}
