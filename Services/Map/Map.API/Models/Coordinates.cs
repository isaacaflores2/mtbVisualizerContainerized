
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Map.API.Models
{
    public class Coordinates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? UserID;
        public long? ActvityID;
        public string? ActivityType;
        public float? Latitude;
        public float? Longitude;

        public Coordinates(int? userId, long? actvitiyId, string? activityType, float? latitude, float? longitude)
        {
            UserID = userId;
            ActvityID = actvitiyId;
            ActivityType = activityType;
            Latitude = latitude;
            Longitude = longitude;
        }        
    }
}
