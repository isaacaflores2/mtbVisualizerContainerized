using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using StravaVisualizer.Models;
using Microsoft.AspNetCore.Http;
using StravaVisualizer.Models.Map;

namespace StravaVisualizerTest
{
    [TestClass]
    public class MapTest
    {
        List<SummaryActivity> activities;

        [TestInitialize]
        public void Setup()
        {
            activities = new List<SummaryActivity>
            {
                new SummaryActivity(type:ActivityType.Crossfit, startLatlng: new LatLng(), movingTime:60) ,
                new SummaryActivity(type:ActivityType.Ride, startLatlng: new LatLng()), 
            };

            activities[0].StartLatlng.Add((float?)30.0);
            activities[0].StartLatlng.Add((float?)40.0);
            activities[1].StartLatlng.Add((float?)30.6);
            activities[1].StartLatlng.Add((float?)40.6);                        
        }
        

        [TestMethod]
        public void Test_getCoordinates_withNull_Input()
        {
            Map map = new Map();
               
            Assert.ThrowsException< ArgumentNullException>(()=> map.getCoordinates(null));
        }

        [TestMethod]
        public void Test_getCoordinates_withValid_Input()
        {
            Map map = new Map();

            var result = (List<Coordinate>) map.getCoordinates(activities);

            Assert.AreEqual((float?)30.0, result[0].Latitude);
            Assert.AreEqual((float?)40.0, result[0].Longitude);
            Assert.AreEqual((float?)30.6, result[1].Latitude);
            Assert.AreEqual((float?)40.6, result[1].Longitude);
        }

        [TestMethod]
        public void Test_extractCoordinates()
        {
            Map map = new Map();
            map.Activities = activities;

            map.extractCoordinates();
            var result = (List<Coordinate>)map.Coordinates;

            Assert.AreEqual((float?)30.0, result[0].Latitude);
            Assert.AreEqual((float?)40.0, result[0].Longitude);
            Assert.AreEqual((float?)30.6, result[1].Latitude);
            Assert.AreEqual((float?)40.6, result[1].Longitude);            
        }

        [TestMethod]
        public void Test_addCoordinate()
        {
            Map map = new Map();
            map.Activities = activities;

            map.addCoordinate(activities[0]);
            var result = (List<Coordinate>)map.Coordinates;

            Assert.AreEqual(1, result.Count);                
        }

        [TestMethod]
        public void Test_getCoordinatesByType_withNull_Input()
        {
            Map map = new Map();

            Assert.ThrowsException<ArgumentNullException>(() => map.getCoordinatesByType(null, ActivityType.Ride));
        }

        [TestMethod]
        public void Test_getCoordinatesBytype_withValid_Input()
        {
            Map map = new Map();

            var result = (List<Coordinate>)map.getCoordinatesByType(activities, ActivityType.Ride);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual((float?)30.6, result[0].Latitude);
            Assert.AreEqual((float?)40.6, result[0].Longitude);
           
        }

    }
}
