using IO.Swagger.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models.Activities;
using StravaVisualizerTest.Doubles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StravaVisualizerTest
{
    [TestClass]
    public class UserActivitiesTest
    {
        List<VisualActivity> visualActivities;

        [TestInitialize]
        public void Setup()
        {
            visualActivities = TestData.VisualActivitiesList();
        }

        [TestMethod]
        public void Test_UserActivities()
        {
            StravaUser activities = new StravaUser();

            activities.VisualActivities =  visualActivities;
            activities.LastDownload = DateTime.Now.Date;
            activities.UserId = 123;

            CollectionAssert.AreEqual(visualActivities, activities.VisualActivities);
            Assert.AreEqual(DateTime.Now.Date, activities.LastDownload);
            Assert.AreEqual(123, activities.UserId);
        }
    }
}
