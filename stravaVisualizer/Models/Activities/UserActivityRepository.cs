using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Microsoft.EntityFrameworkCore;
using StravaVisualizer.Data;

namespace StravaVisualizer.Models.Activities
{
    public class UserActivityRepository: IUserActivityRepository
    {
        private readonly IUserActivityDbContext userActivityDbContext;

        public UserActivityRepository(IUserActivityDbContext userActivityDbContext)
        {
            this.userActivityDbContext = userActivityDbContext;
        }

        
        public IQueryable<UserActivity> GetUserActivities()
        {
            return userActivityDbContext.UserActivities;

        }

        public UserActivity GetUserActivitiesById(int id)
        {
            var userActivityForId = (from userActivity in userActivityDbContext.UserActivities
                                    where userActivity.UserId == id
                                    select userActivity).First();

            return userActivityForId;
        }

        public void Add(UserActivity userActivity)
        {
            if (userActivity == null)
                throw new ArgumentNullException(nameof(userActivity) + ": Cannot be null ");

            userActivityDbContext.UserActivities.Add(userActivity);
            userActivityDbContext.
        }
    }
}
