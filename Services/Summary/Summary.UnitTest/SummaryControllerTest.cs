using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Summary.API.Controllers;
using Summary.API.Data;
using Summary.API.Models;
using Summary.UnitTest.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Summary.UnitTest
{
    [TestClass]
    public class SummaryControllerTest
    {
        private string accessToken;
        private int stravaId;
        private IStravaClient stravaClient;
        private ISummaryRepository context;

        [TestInitialize]
        public void Setup()
        {
            accessToken = "access_token";
            stravaId = 123;
            stravaClient = Substitute.For<IStravaClient>(); ;
            context = Substitute.For<ISummaryRepository>();

            //Mock stravaClient
            IEnumerable<VisualActivity> activities = TestData.VisualActivitiesList();
            IEnumerable<VisualActivity> newUserActivities = TestData.NewVisualActivitiesList();            
            stravaClient.getAllUserActivities(accessToken, 123).Returns(activities);
            stravaClient.getAllUserActivities(accessToken, 2222).Returns(newUserActivities);            
            stravaClient.getUserActivitiesByIdAfter(accessToken, Arg.Any<User>(), Arg.Any<DateTime>()).Returns(newUserActivities);          

            //Mock repository
            var stravaUser = new User { UserId = 123, MonthSummaries = TestData.MonthSummaryActivityList()};
            context = Substitute.For<ISummaryRepository>();
            context.GetUserById(123).Returns(stravaUser);
            context.GetUserById(2222).Returns(new User());

        }

        [TestMethod]
        public void Test_GetMonthSummaryById_ForReturningUser()
        {
            //Arrange
            var controller = new SummaryController(context, stravaClient);
            var month = 9;             

            //Act
            var actionResult = controller.MonthSummaryById(accessToken, stravaId, month ).Value.ToList();

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(2, actionResult.Count);            
        }

        [TestMethod]
        public void Test_GetMonthSummaryById_ForNewUser()
        {
            //Arrange
            var controller = new SummaryController(context, stravaClient);
            var month = 9;

            //Act
            var actionResult = controller.MonthSummaryById(accessToken, 2222, month).Value.ToList();

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(1, actionResult.Count);
        }
    }
}
