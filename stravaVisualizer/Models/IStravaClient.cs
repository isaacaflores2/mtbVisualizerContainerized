using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    interface IStravaClient
    {
        IEnumerable<SummaryActivity> requesAllUserActivities(string accessToken, int id);
        IEnumerable<SummaryActivity> requesUserActivitiesAfter(string accessToken, int id, DateTime afterDate);
    }
}
