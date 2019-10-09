using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Activities
{
    public interface IUserActivityRepository
    {
        IQueryable<StravaUser> GetUserActivities();
        StravaUser GetUserActivitiesById(int id);
        void Add(StravaUser userActivity);
        void SaveChanges();

    }
}
