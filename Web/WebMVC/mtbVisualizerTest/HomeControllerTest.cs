﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using MtbVisualizer.Controllers;
using MtbVisualizer.Data;
using MtbVisualizer.Models;
using MtbVisualizerTest.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using mtbVisualizer.Services;
using System.Threading.Tasks;
using MtbVisualizer.ViewModels;


namespace MtbVisualizerTest
{
    [TestClass]
    public class HomeControllerTest
    {
        private IHttpContextHelper httpContextHelper;                
        private ISummaryService summaryService;

        [TestInitialize]
        public void Setup()
        {
            httpContextHelper = Substitute.For<IHttpContextHelper>();
            httpContextHelper.getAccessToken().Returns("access_token");
            
            summaryService = Substitute.For<ISummaryService>();
            var monthSummaries = TestData.MonthSummariesList();
            summaryService.GetMonthSummaryActivities("access_token", 123, Arg.Any<DateTime>()).Returns(Task.FromResult(monthSummaries));
        }

        [TestMethod]
        public void Test_Index_Return_View()
        {
            HomeController controller = new HomeController(httpContextHelper, summaryService);
            var claims = new Claim[] { new Claim("stravaId", "123") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            //var result = controller.Index() as ViewResult;
            var result = controller.Index() as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Map", result.ControllerName);
        }

        [TestMethod]
        public void Test_Index_For_User_With_No_Data()
        {
            HomeController controller = new HomeController(httpContextHelper, summaryService);
            var claims = new Claim[] { new Claim("stravaId", "222") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            //var result = controller.Index() as ViewResult;
            var result = controller.Index() as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Map", result.ControllerName);
        }

        [TestMethod]
        public void Test_Calendar_Partial_View()
        {
            HomeController controller = new HomeController(httpContextHelper, summaryService);
            var claims = new Claim[] { new Claim("stravaId", "123") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var testDate = new DateTime(2019, 10, 17);
            var result = controller.LoadCalendarPartial(testDate).Result as PartialViewResult;
            var activities = result.Model as ICollection<MonthSummaryActivity>;

            Assert.AreEqual("_CalendarPartial", result.ViewName);
            Assert.AreEqual(2, activities.Count());
        }

        [TestMethod]
        public void Test_Table_Partial_View()
        {
            HomeController controller = new HomeController(httpContextHelper, summaryService);
            var claims = new Claim[] { new Claim("stravaId", "123") };
            var identity = new ClaimsIdentity(claims, "mock");
            var user = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var testDate = new DateTime(2019, 10, 17);
            var result = controller.LoadTablePartial(testDate).Result as PartialViewResult;
            var activities = result.Model as ICollection<MonthSummaryActivity>;

            Assert.AreEqual("_TablePartial", result.ViewName);
            Assert.AreEqual(1, activities.Count);
        }

        [TestMethod]
        public void Test_Privacy_Return_View()
        {
            HomeController controller = new HomeController(httpContextHelper, summaryService);

            var result = controller.Privacy() as ViewResult;

            Assert.AreEqual("Privacy", result.ViewName);
        }
    }
}
