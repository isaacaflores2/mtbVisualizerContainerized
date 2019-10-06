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
            throw new NotImplementedException();

        }

        public IQueryable<UserActivity> GetUserActivitiesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
