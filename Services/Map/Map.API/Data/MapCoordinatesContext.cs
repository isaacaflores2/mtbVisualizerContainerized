using System;
using System.Threading.Tasks;
using Map.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Map.API.Data
{
    public class MapCoordinatesContext : DbContext
    {
        public MapCoordinatesContext() : base()
        {
        }

        public MapCoordinatesContext(DbContextOptions<MapCoordinatesContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Coordinates> StartCoordinates { get; set; }        
    }
}
