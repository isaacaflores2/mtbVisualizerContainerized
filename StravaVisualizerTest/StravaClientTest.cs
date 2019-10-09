using System;
using System.Collections.Generic;
using System.Text;
using IO.Swagger.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StravaVisualizer.Models;
using NSubstitute;
using IO.Swagger.Model;
using System.Threading.Tasks;
using StravaVisualizer.Models.Activities;
using StravaVisualizerTest.Doubles;

namespace StravaVisualizerTest
{
    [TestClass]
    public class StravaClientTest
    {
        private IAthletesApi athleteApi;
        private IActivitiesApi activitiesApi;
        private int totalRides = 50;
        private int totalRuns = 100;
        private int totalSwims = 1;
        

        [TestInitialize]
        public void Setup()
        {
   
            athleteApi = Substitute.For<IAthletesApi>();
            ActivityStats stats = new ActivityStats(
                allRideTotals: new ActivityTotal(count: totalRides),
                allRunTotals: new ActivityTotal(count: totalRuns),
                allSwimTotals: new ActivityTotal(count: totalSwims)
                );
            athleteApi.GetStatsAsync(Arg.Any<int>()).Returns(stats);

            activitiesApi = Substitute.For<IActivitiesApi>();
            List<SummaryActivity> activities = new List<SummaryActivity>
            {
                TestData.SummaryActivity1(),
                TestData.SummaryActivity2()
                
            };          
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page:Arg.Any<int>()).Returns(Task.FromResult(activities));

            List<SummaryActivity> activitiesAfter = new List<SummaryActivity>
            {
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3()
            };
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page:Arg.Any<int>(), after: Arg.Any<int>()).Returns(Task.FromResult(activitiesAfter));
        }

        [TestMethod]
        public void Test_RequestAllUserActivities()
        {            
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            List<VisualActivity> result = (List<VisualActivity>) stravaClient.getAllUserActivities("access_token", 123);


            Assert.AreEqual(12, result.Count);
            Assert.AreEqual(60, result.ToArray()[0].Summary.MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.ToArray()[1].Summary.Type);
        }

        [TestMethod]
        public async Task Test_requestAllUserActivitiesAsync()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            var result = (List<SummaryActivity>) await stravaClient.requestAllUserActivitiesAsync("access_token", 123);
            
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual(60, result.ToArray()[0].MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.ToArray()[1].Type);
        }

        [TestMethod]
        public async Task Test_requestActivities()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            var result = (List<SummaryActivity>)await stravaClient.requestActivities(totalRides+totalRuns+totalSwims);

            Assert.AreEqual(12, result.Count);
            Assert.AreEqual(60, result.ToArray()[0].MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.ToArray()[1].Type);
        }

        [TestMethod]
        public void Test_RequesUserActivitiesAfter()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            DateTime dateTime = DateTime.Now;

            List<VisualActivity> result = (List<VisualActivity>) stravaClient.getUserActivitiesAfter("access_token", 123, dateTime);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(100, result.ToArray()[0].Summary.MovingTime);
            Assert.AreEqual(ActivityType.Run, result.ToArray()[1].Summary.Type);
        }

        [TestMethod]
        public async Task requestActivitiesAfterAsync()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            DateTime dateTime = DateTime.Now;

            List<SummaryActivity> result = (List<SummaryActivity>) await stravaClient.requestActivitiesAfterAsync("access_token", 123, dateTime);

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(100, result.ToArray()[0].MovingTime);
            Assert.AreEqual(ActivityType.Run, result.ToArray()[1].Type);
        }


        [TestMethod]
        public async Task Test_requestActivitiesAfter()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            DateTime dateTime = DateTime.Now;

            List<SummaryActivity> result = (List<SummaryActivity>) await stravaClient.requestActivitiesAfter(totalRides + totalRuns + totalSwims, dateTime);

            Assert.AreEqual(12, result.Count);
            Assert.AreEqual(100, result.ToArray()[0].MovingTime);
            Assert.AreEqual(ActivityType.Run, result.ToArray()[1].Type);
        }              
    }
}
