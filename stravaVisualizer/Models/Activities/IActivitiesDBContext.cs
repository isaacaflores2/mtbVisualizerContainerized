using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.Activities
{
    public interface IActivitiesDBContext
    {
        IQueryable<Activities> Activities { get; }
        T AddActivities<T>(T entity) where T : IEnumerable<T>;
        Activities FindActivitiesByType(ActivityType type);
    }
}
