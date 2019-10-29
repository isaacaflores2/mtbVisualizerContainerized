using Microsoft.EntityFrameworkCore;
using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Data
{
    public interface IMtbVisualizerDbContext
    {
        DbSet<StravaUser> StravaUsers { get; set; }
        DbSet<VisualActivity> VisualActivities { get; set; }
        void Add<T>(T entity) where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
