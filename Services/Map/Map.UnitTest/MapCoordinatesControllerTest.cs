using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using Map.API.Data;
using System.Collections.Generic;
using Map.API.Controllers;
using Map.API.Models;
using Map.UnitTest.Doubles;

namespace Map.UnitTest
{
    [TestClass]
    public class MapCoordinatesControllerTest
    {
        private string accessToken;
        private int stravaId;
        private IStravaClient stravaClient;  
        private ICoordinatesRepository context;

        [TestInitialize]
        public void Setup()
        {
            accessToken = "access_token";
            stravaId = 123;
            stravaClient = Substitute.For<IStravaClient>(); ;
            context = Substitute.For<ICoordinatesRepository>();            

            //Mock stravaClient
            IEnumerable<VisualActivity> activities = TestData.VisualActivitiesList();
            IEnumerable<VisualActivity> newUserActivities = TestData.NewVisualActivitiesList();
            IEnumerable<Coordinates> coordinates = TestData.CoordinatesList();
            IEnumerable<Coordinates> newCoordinates = TestData.NewCoordinatesList();
            stravaClient.getAllUserActivities(accessToken, 123).Returns(activities);
            stravaClient.getAllUserActivities(accessToken, 2222).Returns(newUserActivities);
            stravaClient.getAllUserCoordinatesById(accessToken, 123).Returns(coordinates);
            stravaClient.getAllUserCoordinatesById(accessToken, 2222).Returns(coordinates);
            stravaClient.getUserActivitiesByIdAfter(accessToken, Arg.Any<User>(), Arg.Any<DateTime>()).Returns(newUserActivities);
            stravaClient.getUserCoordinatesById(accessToken, Arg.Any<User>(), Arg.Any<DateTime>()).Returns(newCoordinates);

            //Mock repository
            var stravaUser = new User { StartCoordinates = coordinates.ToList(), UserId = 123, LastDownload = DateTime.Now };        
            context = Substitute.For<ICoordinatesRepository>();            
            context.GetUserById(123).Returns(stravaUser);
            context.GetUserById(2222).Returns(new User());

        }

        [TestMethod]
        public void Test_CoordinatesById_ForReturingUser()
        {
            //Arrange            
            var controller = new MapCoordinatesController(context, stravaClient);            
            var expectedCoordinates = TestData.CoordinatesList().ToList();
            expectedCoordinates.AddRange(TestData.NewCoordinatesList());
            
            //Act
            var actionResult = controller.CoordinatesById(accessToken, stravaId).Value.ToList();
            
            //Assert            
            Assert.AreEqual(expectedCoordinates.Count, actionResult.Count);
            Assert.AreEqual(expectedCoordinates.First().ActvityID, actionResult.First().ActvityID);
        }

        [TestMethod]
        public void Test_CoordinatesById_ForNewUser()
        {
            //Arrange            
            var controller = new MapCoordinatesController(context, stravaClient);            
            var expectedCoordinates = TestData.CoordinatesList().ToList();

            //Act
            var actionResult = controller.CoordinatesById(accessToken, 2222).Value.ToList();

            //Assert            
            Assert.AreEqual(expectedCoordinates.Count, actionResult.Count);
            Assert.AreEqual(expectedCoordinates.First().ActvityID, actionResult.First().ActvityID);
        }
    }
}
