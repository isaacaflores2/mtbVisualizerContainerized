using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MtbVisualizer.Controllers;
using NSubstitute;
using Microsoft.AspNetCore.Http;
using MtbVisualizer.Models;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using MtbVisualizerTest.Doubles;
using MtbVisualizer.Data;
using mtbVisualizer.Services;
using System.Threading.Tasks;
using MtbVisualizer.ViewModels;


namespace MtbVisualizerTest
{
    [TestClass]
    public class MapControllerTest
    {
        private IHttpContextHelper httpContextHelper;
        //private IStravaClient stravaClient;
        //private IMap map;
        //private IEnumerable<StravaUser> userActivities;
        private IStravaVisualizerRepository userActivityRepository;
        private IMapCoordinatesService mapCoordinatesService;

        [TestInitialize]
        public void Setup()
        {
            httpContextHelper = Substitute.For<IHttpContextHelper>();
            httpContextHelper.getAccessToken().Returns("access_token");

            mapCoordinatesService = Substitute.For<IMapCoordinatesService>();
            var activityCoordinates = TestData.ActivityCoordinatesList();
            mapCoordinatesService.GetActivityCoordinates("access_token", 123).Returns(Task.FromResult(activityCoordinates));
            
        }

        [TestMethod]
        public void Test_Index_Return_View()
        {          
            MapController controller = new MapController(httpContextHelper, userActivityRepository, mapCoordinatesService);

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMap_Return_View()
        {           
            MapController controller = new MapController(httpContextHelper, userActivityRepository, mapCoordinatesService);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "123")               
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMapPartial() as PartialViewResult;

            Assert.AreEqual("_BingMapPartial", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMapPartial_Context_Data()
        {
            MapController controller = new MapController(httpContextHelper, userActivityRepository, mapCoordinatesService);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "123")
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMapPartial().Model as ICollection<Coordinate>;            
                        
            Assert.IsNotNull(result);            
            Assert.AreEqual(2, result.Count());            
            Assert.AreEqual( 30.6F , result.Last().Latitude);
        }
        
        [TestMethod]
        public void Test_LoadMapByTypePartial()
        {
            MapController controller = new MapController(httpContextHelper, userActivityRepository, mapCoordinatesService);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("stravaId", "123")
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.LoadMapByTypePartial("Ride").Model as ICollection<Coordinate>;
                        
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);                        
        }
    }
}
