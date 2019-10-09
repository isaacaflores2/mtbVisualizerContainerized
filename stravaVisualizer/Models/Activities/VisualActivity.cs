using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Activities
{
    public class VisualActivity
    {
        [Key]
        public long? Id { get; set; }

        public float? StartLat { get; set; }
        public float? StartLong { get; set; }

        public float? EndLat { get; set; }
        public float? EndLong { get; set; }

        public string TrailName { get; set; }
        
        public SummaryActivity Summary { get; set;}

        public VisualActivity(SummaryActivity summaryActivity) : this()
        {
            Summary = summaryActivity;
            if(Summary.StartLatlng != null)
            {
                StartLat = Summary.StartLatlng[0];
                StartLong = Summary.StartLatlng[1];
            }
            if(Summary.EndLatlng != null)
            {
                EndLat = Summary.EndLatlng[0];
                EndLong = Summary.EndLatlng[1];
            }
            
            Id = Summary.Id;
        }

        private VisualActivity()
        {               
            TrailName = null;
        }
    }
}
