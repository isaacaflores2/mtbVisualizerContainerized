using IO.Swagger.Model;
using Microsoft.EntityFrameworkCore;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Data
{
    public interface IUserActivityDbContext
    {
        DbSet<UserActivity> UserActivities { get; }
        DbSet<SummaryActivity> Summaries { get; }
        void SaveChanges();

    }
}
