using Microsoft.EntityFrameworkCore;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Data
{
    public interface IStravaVisualizerDbContext
    {
        DbSet<StravaUser> StravaUsers { get; set; }
        DbSet<VisualActivity> VisualActivities { get; set; }
        void SaveChanges();

    }
}
