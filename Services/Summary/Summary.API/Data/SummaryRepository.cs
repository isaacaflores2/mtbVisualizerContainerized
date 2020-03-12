using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Summary.API.Models;

namespace Summary.API.Data
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly SummaryContext context;

        public SummaryRepository(SummaryContext context)
        {
            this.context = context;
        }

        public User GetUserById(int id)
        {
            var userActivityForId = context.Users
                .Where(user => user.UserId == id)
                .Include(user => user.MonthSummaries)
                .FirstOrDefault();

            return userActivityForId;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add<T>(entity);
        }

        public bool Contains(MonthSummaryActivity activity)
        {
            return context.MonthSummaryActivities.Contains(activity);
        }
    }      
}
