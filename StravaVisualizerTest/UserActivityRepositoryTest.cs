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
        List<SummaryActivity> activities;
        IUserActivityDbContext userActivityDbContext;
        IUserActivityRepository userActivityRepository;

        [TestInitialize]
        public void Setup()
        {
            activities = new List<SummaryActivity>
            {
                new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
                new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()),
            };

            activities[0].StartLatlng.Add(30.0F);
            activities[0].StartLatlng.Add(40.0F);
            activities[1].StartLatlng.Add(30.6F);
            activities[1].StartLatlng.Add(40.6F);

            var mockSet = Substitute.For<DbSet<UserActivity>, IQueryable<UserActivity>>();
            
            userActivityDbContext = Substitute.For<IUserActivityDbContext>();
            userActivityDbContext.UserActivities.Returns(mockSet);

            userActivityRepository = new UserActivityRepository(userActivityDbContext);
        }

    //    [TestMethod]
    //    public void Test_getActivities()
    //    {
    //        var result = (List<SummaryActivity>)userActivityRepository.Summaries;

    //        CollectionAssert.AreEqual(activities, result);
    //    }

    //    [TestMethod]
    //    public void Test_addActivities()
    //    {
    //        List<SummaryActivity> newActivities = new List<SummaryActivity>
    //        {
    //            new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
    //            new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()),
    //        };
    //        newActivities[0].StartLatlng.Add(30.0F);
    //        newActivities[0].StartLatlng.Add(40.0F);
    //        newActivities[1].StartLatlng.Add(30.6F);
    //        newActivities[1].StartLatlng.Add(40.6F);
    //        List<SummaryActivity> joinedActivities = new List<SummaryActivity>(activities);
    //        joinedActivities.AddRange(newActivities);

    //        userActivityRepository.AddActivities((IList<SummaryActivity>)activities);

    //        var result = (List<SummaryActivity>)userActivityRepository.Summaries;


    //        CollectionAssert.AreEqual(joinedActivities, result);
    //    }

    //    [TestMethod]
    //    public void Test_findActivitiesByType()
    //    {
    //        userActivityRepository.Summaries = (IQueryable<SummaryActivity>)activities;
    //        var result = (List<SummaryActivity>)userActivityRepository.FindActivitiesByType(ActivityType.Ride);

    //        CollectionAssert.AreEqual(activities, result);
    //    }
    }
}
