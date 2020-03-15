using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Map.API.Data
{
    public class MapCoordinatesContextFactory : IDesignTimeDbContextFactory<MapCoordinatesContext>
    {
        public MapCoordinatesContext CreateDbContext(string[] args)
        {
            return new MapCoordinatesContext(new DbContextOptionsBuilder<MapCoordinatesContext>()            
                .UseSqlServer("Server=localhost,5433;Database=master;User=sa;Password=Pass@word;")
                .Options);
        }
    }
}
