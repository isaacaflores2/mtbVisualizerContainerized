using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models
{
    public interface IStravaClient
    {
        IEnumerable<SummaryActivity> getAllUserActivities(string accessToken, int id);
        IEnumerable<SummaryActivity> getUserActivitiesAfter(string accessToken, int id, DateTime afterDate);
    }
}
