using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Map.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Map.API.Data
{
    public class CoordinatesRepository: ICoordinatesRepository
    {
        private readonly MapCoordinatesContext context;

        public CoordinatesRepository(MapCoordinatesContext context)
        {            
            this.context = context;
        }
        
        public User GetUserById(int id)
        {   
            var userActivityForId = context.Users
                .Where(user => user.UserId == id)
                .Include(user => user.StartCoordinates)
                .FirstOrDefault();

            return userActivityForId;
        }

        public IEnumerable<Coordinates> GetCoordinatesById(int id)
        {
            return null;
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

        public bool Contains(Coordinates coordinates)
        {
            return context.StartCoordinates.Contains(coordinates);
        }
    }
}
