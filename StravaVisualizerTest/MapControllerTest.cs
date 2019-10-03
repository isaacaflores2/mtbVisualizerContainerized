using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stravaVisualizer.Controllers;
using NSubstitute;
using Microsoft.AspNetCore.Http;
using StravaVisualizer.Models;
using System.Security.Claims;

namespace StravaVisualizerTest
{
    [TestClass]
    public class MapControllerTest
    {
        private IHttpContextHelper httpContextHelper;

        [TestInitialize]
        public void Setup()
        {
            httpContextHelper = Substitute.For<IHttpContextHelper>();
            httpContextHelper.getAccessToken().Returns("1");
        }

        [TestMethod]
        public void Test_Index_Return_View()
        {          
            MapController controller = new MapController(httpContextHelper);

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("MapAsync", result.ViewName);
        }

        [TestMethod]
        public void Test_LoadMap_Return_View()
        {           
            MapController controller = new MapController(httpContextHelper);
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
