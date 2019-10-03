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

namespace StravaVisualizerTest
{
    [TestClass]
    public class MapControllerTest
    {
        private IHttpContextHelper httpContextHelper;
        private IStravaClient stravaClient;
        private IMap map; 

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
            stravaClient.requesAllUserActivities("access_token", 123).Returns(activities);

            map = Substitute.For<IMap>();
            ICollection<ActivityCoordinates> coordinates = new List<ActivityCoordinates>()
            {
                new ActivityCoordinates(),
                new ActivityCoordinates()
            };
            map.getCoordinates(activities).Returns(coordinates);
        }

        [TestMethod]
        public void Test_Index_Return_View()
        {          
            MapController controller = new MapController(httpContextHelper, stravaClient, map);

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("MapAsync", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMap_Return_View()
        {           
            MapController controller = new MapController(httpContextHelper, stravaClient, map);
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
    }
}
