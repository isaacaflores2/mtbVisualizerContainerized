using IO.Swagger.Model;
using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Data
{
    public interface IStravaVisualizerRepository
    {
        IQueryable<StravaUser> GetUserActivities();
        StravaUser GetStravaUserById(int id);
        void Add<T>(T entity) where T : class;
        bool Contains(VisualActivity activity);
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
