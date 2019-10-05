using System;
using System.Collections.Generic;
using System.Text;

namespace StravaVisualizerTest.Doubles
{
    public partial class LatLng : List<float?>
    {      
        public LatLng(float? lat, float? lng)
        {
            base.Add(lat);
            base.Add(lng);           
        }

    }
}
