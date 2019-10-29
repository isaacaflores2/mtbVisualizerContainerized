using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Microsoft.EntityFrameworkCore;
using MtbVisualizer.Data;
using MtbVisualizer.Models.Activities;

namespace MtbVisualizer.Data
{
    public class StravaVisualizerRepository: IStravaVisualizerRepository
    {
        private readonly IMtbVisualizerDbContext stravaVisualizerDbContext;

        public StravaVisualizerRepository(IMtbVisualizerDbContext context)
        {
            this.stravaVisualizerDbContext = context;
        }

        
        public IQueryable<StravaUser> GetUserActivities()
        {
            return stravaVisualizerDbContext.StravaUsers;

        }

        public StravaUser GetStravaUserById(int id)
        {
            //var userActivityForId = (from user in stravaVisualizerDbContext.StravaUsers
            //                        where user.UserId == id
            //                        select user).FirstOrDefault();

            var userActivityForId = stravaVisualizerDbContext.StravaUsers
                .Where(user => user.UserId == id)
                .Include(user => user.VisualActivities)
                .FirstOrDefault();

            return userActivityForId;
        }
        

        public void SaveChanges()
        {
            stravaVisualizerDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await stravaVisualizerDbContext.SaveChangesAsync();
        }

        public void Add<T>(T entity) where T : class
        {
            stravaVisualizerDbContext.Add<T>(entity);
        }

        public bool Contains(VisualActivity activity)
        {
            return stravaVisualizerDbContext.VisualActivities.Contains(activity);
        }
    }
}
