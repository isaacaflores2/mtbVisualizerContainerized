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
        UserActivity GetUserActivitiesById(int id);
        void Add(UserActivity userActivity);
        void SaveChanges();

    }
}
