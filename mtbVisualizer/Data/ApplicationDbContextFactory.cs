using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MtbVisualizer.Data;
using System;

namespace mtbVisualizer.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()            
                .UseSqlServer("Server=localhost,5433;Database=master;User=sa;Password=Pass@word;")
                .Options);
        }
    }
}
