using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace StravaVisualizer.Models.Activities
{
    public class UserActivity
    {        
        public List<SummaryActivity> Activities { get; set; }
        public DateTime LastDownload { get; set; }
        public int UserId { get; set; }
    }
}
