using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stravaVisualizer.Controllers;
using NSubstitute;
using Microsoft.AspNetCore.Http;
using StravaVisualizer.Models;
using System.Security.Claims;
using System.Collections.Generic;
using IO.Swagger.Model;
using StravaVisualizer.Models.Map;
using StravaVisualizer.Models.Activities;
using System;
using System.Linq;

namespace StravaVisualizerTest
{
    [TestClass]
    public class MapControllerTest
    {
        private IHttpContextHelper httpContextHelper;
        private IStravaClient stravaClient;
        private IMap map;
        private IEnumerable<UserActivity> userActivities;
        private IUserActivityRepository userActivityRepository;

        [TestInitialize]
        public void Setup()
        {
            httpContextHelper = Substitute.For<IHttpContextHelper>();
            httpContextHelper.getAccessToken().Returns("1");

            stravaClient = Substitute.For<IStravaClient>();
            IEnumerable<SummaryActivity> activities = new List<SummaryActivity>
            {
                new SummaryActivity(),
                new SummaryActivity()
            };

            IEnumerable<SummaryActivity> newUserActivities = new List<SummaryActivity>()
            {
                new SummaryActivity(),
                new SummaryActivity()
            };

            stravaClient.getAllUserActivities("access_token", 123).Returns(activities);
            stravaClient.getAllUserActivities("access_token", 2222).Returns(newUserActivities);

            map = Substitute.For<IMap>();
            var rideCoordinate = new Coordinate(30.0F, 40.0F);
            ICollection<Coordinate> coordinates = new List<Coordinate>()
            {
                new Coordinate(),
                rideCoordinate,
            };
            
            map.getCoordinatesByType(Arg.Any<IEnumerable<SummaryActivity>>(), ActivityType.Ride).Returns(coordinates);

            var userActivity = new UserActivity { Activities = (List<SummaryActivity>) activities, UserId = 2, LastDownload = DateTime.Now };
            userActivities = new List<UserActivity>
            {
                new UserActivity {Activities = (List<SummaryActivity>)activities, UserId = 1, LastDownload = DateTime.Now},
                userActivity,
                new UserActivity {Activities = (List<SummaryActivity>)activities, UserId = 3, LastDownload = DateTime.Now},

            }.AsQueryable();
            userActivityRepository = Substitute.For<IUserActivityRepository>();
            userActivityRepository.GetUserActivities().Returns(userActivities);            
            userActivityRepository.GetUserActivitiesById(123).Returns(userActivity);
            userActivityRepository.GetUserActivitiesById(2222).Returns(new UserActivity());
        }

        [TestMethod]
        public void Test_Index_Return_View()
        {          
            MapController controller = new MapController(httpContextHelper, stravaClient, map, userActivityRepository);

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("MapAsync", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMap_Return_View()
        {           
            MapController controller = new MapController(httpContextHelper, stravaClient, map, userActivityRepository);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "123")               
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMap() as PartialViewResult;

            Assert.AreEqual("_BingMapPartial", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMap_Context_Data()
        {
            MapController controller = new MapController(httpContextHelper, stravaClient, map, userActivityRepository);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "123")
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMap() as PartialViewResult;

            Assert.AreEqual(typeof(List<Coordinate>), result.Model.GetType());
            Assert.AreEqual( 30.0F , ((IList<Coordinate>)result.Model)[1].Latitude);
        }

        [TestMethod]
        public void Test_LoadMap_Context_Data_For_New_User()
        {
            MapController controller = new MapController(httpContextHelper, stravaClient, map, userActivityRepository);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "2222")
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMap() as PartialViewResult;

            Assert.AreEqual(typeof(List<Coordinate>), result.Model.GetType());
            Assert.AreEqual(30.0F, ((IList<Coordinate>)result.Model)[1].Latitude);
        }
    }
}
