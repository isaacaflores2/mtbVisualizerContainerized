
using IO.Swagger.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtbVis.Common
{
    public class Coordinates
    {
        [Key]        
        public int Id { get; set; }
        public int? UserID { get; set; }
        public long? ActvityID { get; set; }
        public string? ActivityType { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

        public Coordinates()
        {
        }

        public Coordinates(int? userId, long? actvitiyId, string? activityType, float? latitude, float? longitude)
        {
            UserID = userId;
            ActvityID = actvitiyId;
            ActivityType = activityType;
            Latitude = latitude;
            Longitude = longitude;
        }
        
        public Coordinates(SummaryActivity summaryActivity)
        {
            UserID = summaryActivity.Athlete.Id;
            ActvityID = summaryActivity.Id;
            ActivityType = summaryActivity.Type.ToString();

            if (summaryActivity.StartLatlng != null)
            {
                Latitude = summaryActivity.StartLatlng[0];
                Longitude = summaryActivity.StartLatlng[1];
            }               
        }
    }
}
