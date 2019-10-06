using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Activities
{
    public interface IUserActivityRepository
    {
        IQueryable<UserActivity> GetUserActivities();
        IQueryable<UserActivity> GetUserActivitiesById(int id);

    }
}
