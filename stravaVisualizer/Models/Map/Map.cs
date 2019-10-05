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
        public IDictionary<Coordinate, int> NumVisits { get; set; }

        public Map()
        {
            Activities = null;
            Coordinates = new List<Coordinate>();
            Pins = new List<Pin>();
            NumVisits = new Dictionary<Coordinate, int>();
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

        public void getUniqueCoordinatesByType(IEnumerable<SummaryActivity> activities, ActivityType type)
        {
            if (activities == null)
                throw new ArgumentNullException("Activities is null");

            var activitiesForType = from activity in activities
                                   where activity.Type == type
                                   select activity;
            Activities = activitiesForType;

            foreach (SummaryActivity summary in Activities)
            {
                if (summary == null || summary.StartLatlng == null)
                    continue;

                updateNumVisits(summary);
                addCoordinate(summary);
            }

            foreach(var coordinate in NumVisits.Keys)
            {
                Pin pin = new Pin();
                pin.Location = coordinate;
                pin.Text = Convert.ToString(NumVisits[coordinate]);
                Pins.Add(pin);
            }
        }

        public void updateNumVisits(SummaryActivity summary)
        {
            float?[] latlongArray = summary.StartLatlng.ToArray();                        
            var coordinate = new Coordinate(latlongArray[0], latlongArray[1]);
            
            if (NumVisits.ContainsKey(coordinate))
            {
                NumVisits.TryGetValue(coordinate, out var count);
                count++;
                NumVisits[coordinate] = count;
            }
            else
            {
                NumVisits.Add(coordinate, 1);
            }
        }

       
    }
}
