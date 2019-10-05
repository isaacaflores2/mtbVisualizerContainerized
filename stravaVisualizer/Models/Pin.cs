using GeoCoordinatePortable;

namespace StravaVisualizer.Models
{
    public class Pin
    {
        public Coordinate Location { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }
    }
}