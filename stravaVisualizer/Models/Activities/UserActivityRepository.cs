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
        private readonly IStravaVisualizerDbContext userActivityDbContext;

        public UserActivityRepository(IStravaVisualizerDbContext userActivityDbContext)
        {
            this.userActivityDbContext = userActivityDbContext;
        }

        
        public IQueryable<StravaUser> GetUserActivities()
        {
            return userActivityDbContext.StravaUsers;

        }

        public StravaUser GetUserActivitiesById(int id)
        {
            var userActivityForId = (from userActivity in userActivityDbContext.StravaUsers
                                    where userActivity.UserId == id
                                    select userActivity).First();

            return userActivityForId;
        }

        public void Add(StravaUser userActivity)
        {
            if (userActivity == null)
                throw new ArgumentNullException(nameof(userActivity) + ": Cannot be null ");

            userActivityDbContext.StravaUsers.Add(userActivity);
            userActivityDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
