using Map.API.Models;
using MtbVis.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Map.API.Data
{
    public interface ICoordinatesRepository
    {        
        User GetUserById(int id);
        IEnumerable<Coordinates> GetCoordinatesById(int id);
        void Add<T>(T entity) where T : class;
        bool Contains(Coordinates coordinates);
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
