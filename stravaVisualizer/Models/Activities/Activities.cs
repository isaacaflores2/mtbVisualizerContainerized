using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace StravaVisualizer.Models.Activities
{
    public class Activities
    {        
        public List<SummaryActivity> Summaries { get; set; }
        public DateTime LastDownload { get; set; }
        public int UserId { get; set; }
    }
}
