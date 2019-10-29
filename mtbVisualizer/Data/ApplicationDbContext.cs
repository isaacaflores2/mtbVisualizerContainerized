using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MtbVisualizer.Data;
using MtbVisualizer.Models.Activities;

namespace MtbVisualizer.Data
{
    public class ApplicationDbContext : IdentityDbContext, IMtbVisualizerDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StravaUser> StravaUsers { get; set; }

        public DbSet<VisualActivity> VisualActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SummaryActivity>()
                .Ignore(s => s.StartLatlng);

            modelBuilder.Entity<SummaryActivity>()
                .Ignore(s => s.EndLatlng);

            modelBuilder.Entity<SummaryActivity>()
                .Ignore(s => s.Athlete);

            modelBuilder.Entity<VisualActivity>(v =>
            {
                v.OwnsOne(p => p.Summary);
            });

            modelBuilder.Entity<StravaUser>()
                .Property(s => s.UserId)
                .ValueGeneratedNever();
        }

        void IMtbVisualizerDbContext.SaveChanges()
        {
            SaveChanges();
        }

        async Task IMtbVisualizerDbContext.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        void IMtbVisualizerDbContext.Add<T>(T entity)
        {
            Add<T>(entity);
        }
    }
}
