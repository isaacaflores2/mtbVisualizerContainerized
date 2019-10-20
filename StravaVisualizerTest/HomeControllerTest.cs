using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using StravaVisualizer.Controllers;
using StravaVisualizer.Data;
using StravaVisualizer.Models;
using StravaVisualizer.Models.Activities;
using StravaVisualizerTest.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace StravaVisualizerTest
{
    [TestClass]
    public class HomeControllerTest
    {
        private IHttpContextHelper httpContextHelper;
        private IStravaVisualizerRepository context;
        private IEnumerable<StravaUser> userActivities;

        [TestInitialize]
        public void Setup()
        {
            httpContextHelper = Substitute.For<IHttpContextHelper>();
            httpContextHelper.getAccessToken().Returns("access_token");
            IEnumerable<VisualActivity> activities = TestData.MonthVisualActivitiesList();

            var userActivity = new StravaUser { VisualActivities = (List<VisualActivity>)activities, UserId = 2, LastDownload = DateTime.Now };
            userActivities = new List<StravaUser>
            {
                new StravaUser {VisualActivities = (List<VisualActivity>)activities, UserId = 1, LastDownload = DateTime.Now},
                userActivity,
                new StravaUser {VisualActivities = (List<VisualActivity>)activities, UserId = 3, LastDownload = DateTime.Now},

            }.AsQueryable();

            context = Substitute.For<IStravaVisualizerRepository>();
            context.GetUserActivities().Returns(userActivities);
            context.GetStravaUserById(123).Returns(userActivity);
            context.GetStravaUserById(2222).Returns(new StravaUser());
        }

        

        [TestMethod]
        public void Test_Index_Return_View()
        {
            HomeController controller = new HomeController(httpContextHelper, context);
            var claims = new Claim[] { new Claim("stravaId", "123") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_Index_For_User_With_No_Data()
        {
            HomeController controller = new HomeController(httpContextHelper, context);
            var claims = new Claim[] { new Claim("stravaId", "222") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }



        [TestMethod]
        public void Test_Privacy_Return_View()
        {
            HomeController controller = new HomeController(httpContextHelper, context);

            var result = controller.Privacy() as ViewResult;

            Assert.AreEqual("Privacy", result.ViewName);
        }
    }
}
