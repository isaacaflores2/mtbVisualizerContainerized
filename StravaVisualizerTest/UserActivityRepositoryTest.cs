using IO.Swagger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using StravaVisualizer.Data;
using Microsoft.EntityFrameworkCore;

namespace StravaVisualizerTest
{   
    [TestClass]
    public class UserActivityRepositoryTest
    {
        List<SummaryActivity> summaries;
        IQueryable<UserActivity> userActivities;
        IUserActivityDbContext userActivityDbContext;
        IUserActivityRepository userActivityRepository;

        [TestInitialize]
        public void Setup()
        {
            summaries = new List<SummaryActivity>
            {
                new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
                new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()),
            };

            userActivities = new List<UserActivity>
            {
                new UserActivity {Activities = summaries, UserId = 1, LastDownload = DateTime.Now},
                new UserActivity {Activities = summaries, UserId = 2, LastDownload = DateTime.Now},
                new UserActivity {Activities = summaries, UserId = 3, LastDownload = DateTime.Now},                

            }.AsQueryable();

            summaries[0].StartLatlng.Add(30.0F);
            summaries[0].StartLatlng.Add(40.0F);
            summaries[1].StartLatlng.Add(30.6F);
            summaries[1].StartLatlng.Add(40.6F);



            var mockSet = Substitute.For<DbSet<UserActivity>, IQueryable<UserActivity>>();
            ((IQueryable<UserActivity>)mockSet).Provider.Returns(userActivities.Provider);
            ((IQueryable<UserActivity>)mockSet).Expression.Returns(userActivities.Expression);
            ((IQueryable<UserActivity>)mockSet).ElementType.Returns(userActivities.ElementType);
            ((IQueryable<UserActivity>)mockSet).GetEnumerator().Returns(userActivities.GetEnumerator());            
            userActivityDbContext = Substitute.For<IUserActivityDbContext>();
            userActivityDbContext.UserActivities.Returns(mockSet);

            userActivityRepository = new UserActivityRepository(userActivityDbContext);
        }

        [TestMethod]
        public void Test_GetUserActivities()
        {
            var result = userActivityRepository.GetUserActivities();

            Assert.AreEqual(1, result.ElementAt(0).UserId);
        }

        [TestMethod]
        public void Test_GetUserActivitiesById()
        {
            var result = userActivityRepository.GetUserActivitiesById(2);

            Assert.AreEqual(2, result.UserId);
        }
        
        [TestMethod]
        public void Test_AddNewUserActivity()
        {
            //var newUserActivity = new UserActivity()
            //{
            //    Activities = new List<SummaryActivity>(),
            //    UserId = 1,
            //    LastDownload = DateTime.Now.Date
            //};

            //userActivityRepository.Add(newUserActivity);
            //var dbSet = userActivityRepository.GetUserActivities();

            //Assert.AreEqual(4, dbSet.Count());
            Assert.ThrowsException<ArgumentNullException>(() => userActivityRepository.Add(null));
        }
    }
}
