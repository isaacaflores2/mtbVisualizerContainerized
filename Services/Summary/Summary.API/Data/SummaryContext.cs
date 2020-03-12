using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Summary.API.Models;

namespace Summary.API.Data
{
    public class SummaryContext : DbContext
    {
        public SummaryContext() : base()
        {
        }

        public SummaryContext(DbContextOptions<SummaryContext> options)
            : base(options)
        {
        }

        public DbSet<User> SummaryUsers { get; set; }

        public DbSet<MonthSummaryActivity> MonthSummaryActivities { get; set; }        
    }
}
