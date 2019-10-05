using IO.Swagger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StravaVisualizerTest
{   
    [TestClass]
    public class ActivitiesDBContextTest
    {
        List<SummaryActivity> activities;

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
        }

        [TestMethod]
        public void Test_getActivities()
        {
            IActivitiesDBContext activitiesDbContext = new ActivitiesDBContext();

            activitiesDbContext.Activities = activities;
            var result = activitiesDbContext.Activities;

            CollectionAssert.AreEqual(activities, result);
        }

        [TestMethod]
        public void Test_addActivities()
        {
            IActivitiesDBContext activitiesDbContext = new ActivitiesDBContext();
            List<SummaryActivity> newActivities = new List<SummaryActivity>
            {
                new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
                new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()),
            };
            newActivities[0].StartLatlng.Add(30.0F);
            newActivities[0].StartLatlng.Add(40.0F);
            newActivities[1].StartLatlng.Add(30.6F);
            newActivities[1].StartLatlng.Add(40.6F);
            List<SummaryActivity> joinedActivities = new List<SummaryActivity>(activities);
            joinedActivities.AddRange(newActivities);

            activitiesDbContext.AddActivities((IEnumerable<SummaryActivity>) activities);            

            var result = activitiesDbContext.Activities;

            
            CollectionAssert.AreEqual(joinedActivities, result);
        }

        [TestMethod]
        public void Test_findActivitiesByType()
        {
            IActivitiesDBContext activitiesDbContext = new ActivitiesDBContext();

            activitiesDbContext.Activities = activities;
            var result = activitiesDbContext.FindActivitiesByType(ActivityType.Ride);

            CollectionAssert.AreEqual(activities[1], result);
        }
    }
}
