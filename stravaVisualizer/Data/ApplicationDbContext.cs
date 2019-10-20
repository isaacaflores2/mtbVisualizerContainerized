using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StravaVisualizer.Data;
using StravaVisualizer.Models.Activities;

namespace stravaVisualizer.Data
{
    public class ApplicationDbContext : IdentityDbContext, IStravaVisualizerDbContext
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

        void IStravaVisualizerDbContext.SaveChanges()
        {
            SaveChanges();
        }

        async Task IStravaVisualizerDbContext.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        void IStravaVisualizerDbContext.Add<T>(T entity)
        {
            Add<T>(entity);
        }
    }
}
