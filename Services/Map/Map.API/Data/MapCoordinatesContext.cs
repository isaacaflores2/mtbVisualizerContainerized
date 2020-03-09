using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Map.API.Models;
using Microsoft.EntityFrameworkCore;
using MtbVisualizer.Data;
using MtbVisualizer.Models.Activities;

namespace Map.API.Data
{
    public class MapCoordinatesContext : DbContext
    {
        public MapCoordinatesContext(DbContextOptions<MapCoordinatesContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Coordinates> StartCoordinates { get; set; }

        public void SaveChanges()
        {
            SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        public void Add<T>(T entity)
        {
            Add<T>(entity);
        }
    }
}
