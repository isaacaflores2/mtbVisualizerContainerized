using IO.Swagger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StravaVisualizerTest
{
    [TestClass]
    public class UserActivitiesTest
    {
        List<SummaryActivity> summaries;

        [TestInitialize]
        public void Setup()
        {
            summaries = new List<SummaryActivity>
            {
                new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
                new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()),
            };

            summaries[0].StartLatlng.Add(30.0F);
            summaries[0].StartLatlng.Add(40.0F);
            summaries[1].StartLatlng.Add(30.6F);
            summaries[1].StartLatlng.Add(40.6F);
        }

        [TestMethod]
        public void Test_UserActivities()
        {
            UserActivity activities = new UserActivity();

            activities.Activities =  summaries;
            activities.LastDownload = DateTime.Now.Date;
            activities.UserId = 123;

            CollectionAssert.AreEqual(summaries, activities.Activities);
            Assert.AreEqual(DateTime.Now.Date, activities.LastDownload);
            Assert.AreEqual(123, activities.UserId);
        }
    }
}
