using MtbVisualizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MtbVisualizer.ViewModels
{
    public class ActivityCoordinates
    {            
        public int Id { get; set; }
        public int UserID { get; set; }
        public long ActvityID { get; set; }
        public string ActivityType { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public static ICollection<Coordinate> ConvertToCoordinates(ICollection<ActivityCoordinates> activityCoordinates)
        {
            if (activityCoordinates == null || activityCoordinates.Count == 0)
            {
                return null;
            }

            var coordinates = extractCoordinates(activityCoordinates);

            return coordinates;
        }

        private static ICollection<Coordinate> extractCoordinates(ICollection<ActivityCoordinates> activityCoordinates)
        {
            var coordinates = new LinkedList<Coordinate>();
            foreach (var a in activityCoordinates)
            {
                if (a == null)
                    continue;

                coordinates.AddLast(new Coordinate(a.Latitude, a.Longitude));
            }

            return coordinates;
        }

        public static ICollection<ActivityCoordinates> GetActivityCoordinatesByType(ICollection<ActivityCoordinates> activityCoordinates, string type)
        {
            var activityCoordinatesByType = (from activity in activityCoordinates
                                             where activity.ActivityType == type
                                             select activity).ToList();

            return activityCoordinatesByType;
        }
    }
}
