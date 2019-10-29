using System.Collections.Generic;

namespace MtbVisualizer.Models
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
