using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace StravaVisualizer.Models.Activities
{
    public class ActivitiesDBContext : IActivitiesDBContext<SummaryActivity>
    {
        public IQueryable<Activities> Activities => throw new NotImplementedException();

        public T AddActivities<T>(T entity) where T : IEnumerable<T>
        {            
            throw new NotImplementedException();
        }

        public Activities FindActivitiesByType(ActivityType type)
        {
            throw new NotImplementedException();
        }
    }
}
