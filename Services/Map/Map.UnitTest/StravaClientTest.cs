using System;
using System.Collections.Generic;
using System.Text;
using IO.Swagger.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using IO.Swagger.Model;
using System.Threading.Tasks;
using Map.UnitTest.Doubles;
using Map.API.Models;
using System.Linq;
using MtbVis.Common;

namespace Map.UnitTest
{
    [TestClass]
    public class StravaClientTest
    {
        private IAthletesApi athleteApi;
        private IActivitiesApi activitiesApi;
        private int totalRides = 5;
        private int totalRuns = 5;
        private int totalSwims = 1;
        private List<SummaryActivity> emptyActivities;

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

            emptyActivities = new List<SummaryActivity>();           

            activitiesApi.GetLoggedInAthleteActivitiesAsync(page: 1, perPage: Arg.Any<int>()).Returns(Task.FromResult(activities));
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page: 2, perPage: Arg.Any<int>()).Returns(Task.FromResult(emptyActivities));

            List<SummaryActivity> activitiesAfter = new List<SummaryActivity>
            {
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3(),
                TestData.SummaryActivity3()
            };
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page: 1, after: Arg.Any<int>(), perPage: Arg.Any<int>()).Returns(Task.FromResult(activitiesAfter));
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page: 2, after: Arg.Any<int>(), perPage: Arg.Any<int>()).Returns(Task.FromResult(emptyActivities));
        }

        [TestMethod]
        public void Test_RequestAllUserActivities()
        {            
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            List<VisualActivity> result = (List<VisualActivity>) stravaClient.getAllUserActivities("access_token", 123);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(60, result.ToArray()[0].Summary.MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.First().Summary.Type);
        }

        [TestMethod]
        public async Task Test_requestAllUserActivitiesAsync()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            var result = (List<SummaryActivity>) await stravaClient.requestAllUserActivitiesAsync("access_token", 123);
            
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(60, result.Last().MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.First().Type);
        }

        [TestMethod]
        public async Task Test_requestActivities()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            var result = (List<SummaryActivity>)await stravaClient.requestActivitiesAsync(totalRides+totalRuns+totalSwims);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(60, result.Last().MovingTime);
            Assert.AreEqual(ActivityType.Ride, result.First().Type);
        }

        [TestMethod]
        public void Test_RequesUserActivitiesAfter()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);
            DateTime dateTime = DateTime.Now;
                                    
            List<VisualActivity> result = (List<VisualActivity>) stravaClient.getUserActivitiesByIdAfter("access_token", dateTime);

            Assert.AreEqual(9, result.Count);
            Assert.AreEqual(100, result.Last().Summary.MovingTime);
            Assert.AreEqual(ActivityType.Run, result.First().Summary.Type);
        }

        [TestMethod]
        public void Test_RequesUserActivitiesAfter_ZeroRequiredPages()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);
            DateTime dateTime = DateTime.Now;
            activitiesApi.GetLoggedInAthleteActivitiesAsync(page: 1, after: Arg.Any<int>(), perPage: Arg.Any<int>()).Returns(Task.FromResult(emptyActivities));

            List<VisualActivity> result = (List<VisualActivity>)stravaClient.getUserActivitiesByIdAfter("access_token", dateTime);

            Assert.AreEqual(0, result.Count);           
        }

        [TestMethod]
        public async Task requestActivitiesAfterAsync()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);
            DateTime dateTime = DateTime.Now;
           
            List<SummaryActivity> result = (List<SummaryActivity>) await stravaClient.requestActivitiesAfterAsync("access_token", dateTime);

            Assert.AreEqual(9,result.Count);
            Assert.AreEqual(100, result.ToArray()[0].MovingTime);
            Assert.AreEqual(ActivityType.Run, result.ToArray()[1].Type);
        }


        //[TestMethod]
        //public async Task Test_requestActivitiesAfter()
        //{
        //    StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

        //    DateTime dateTime = DateTime.Now;

        //    List<SummaryActivity> result = (List<SummaryActivity>) await stravaClient.requestActivitiesAfterAsync(totalRides + totalRuns + totalSwims, dateTime);

        //    Assert.AreEqual(9, result.Count);
        //    Assert.AreEqual(100, result.ToArray()[0].MovingTime);
        //    Assert.AreEqual(ActivityType.Run, result.ToArray()[1].Type);
        //}

        [TestMethod]
        public void Test_GetAllCoordinatesById()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);

            var result = stravaClient.getAllUserCoordinatesById("access_token", 123);

            Assert.AreEqual(2, result.Count());                   
            Assert.AreEqual(ActivityType.Crossfit.ToString(), result.Last().ActivityType);        
            Assert.AreEqual(ActivityType.Ride.ToString(), result.First().ActivityType);        
        }

        [TestMethod]
        public void Test_GetUserCoordinatesId_WithAfterDate()
        {
            StravaClient stravaClient = new StravaClient(activitiesApi, athleteApi);
            DateTime dateTime = DateTime.Now;
                
            var result = stravaClient.getUserCoordinatesByIdAfter("access_token", dateTime);

            Assert.AreEqual(9, result.Count());           
        }
    }
}
