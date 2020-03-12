using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Summary.API.Data
{
    public class SummaryContextFactory : IDesignTimeDbContextFactory<SummaryContext>
    {
        public SummaryContext CreateDbContext(string[] args)
        {
            return new SummaryContext(new DbContextOptionsBuilder<SummaryContext>()            
                .UseSqlServer("Server=localhost,5433;Database=master;User=sa;Password=Pass@word;")
                .Options);
        }
    }
}
