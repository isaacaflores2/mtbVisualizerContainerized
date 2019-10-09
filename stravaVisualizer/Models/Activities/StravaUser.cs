using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace StravaVisualizer.Models.Activities
{
    public class StravaUser
    {
        [Key]
        public int UserId { get; set; }
        public List<VisualActivity> VisualActivities { get; set; }
        public DateTime LastDownload { get; set; }
        
    }
}
