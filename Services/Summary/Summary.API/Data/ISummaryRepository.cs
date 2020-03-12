using Summary.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Summary.API.Data
{
    public interface ISummaryRepository
    {        
        User GetUserById(int id);
        void Add<T>(T entity) where T : class;
        bool Contains(MonthSummaryActivity activity);
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
