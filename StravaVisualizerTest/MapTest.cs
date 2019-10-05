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

            activities[0].StartLatlng.Add(30.0F);
            activities[0].StartLatlng.Add(40.0F);
            activities[1].StartLatlng.Add(30.6F);
            activities[1].StartLatlng.Add(40.6F);                        
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

            Assert.AreEqual(30.0F, result[0].Latitude);
            Assert.AreEqual(40.0F, result[0].Longitude);
            Assert.AreEqual(30.6F, result[1].Latitude);
            Assert.AreEqual(40.6F, result[1].Longitude);
        }

        [TestMethod]
        public void Test_extractCoordinates()
        {
            Map map = new Map();
            map.Activities = activities;

            map.extractCoordinates();
            var result = (List<Coordinate>)map.Coordinates;

            Assert.AreEqual(30.0F, result[0].Latitude);
            Assert.AreEqual(40.0F, result[0].Longitude);
            Assert.AreEqual(30.6F, result[1].Latitude);
            Assert.AreEqual(40.6F, result[1].Longitude);            
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
            Assert.AreEqual(30.6F, result[0].Latitude);
            Assert.AreEqual(40.6F, result[0].Longitude);           
        }

        [TestMethod]
        public void Test_getUniqueCoordinatesByType()
        {
            Map map = new Map();
            activities.Add(new SummaryActivity(type: ActivityType.Ride, startLatlng: new LatLng(), movingTime: 60));
            activities[2].StartLatlng.Add(30.0F);
            activities[2].StartLatlng.Add(40.0F);

            map.getUniqueCoordinatesByType(activities, ActivityType.Ride);
            var result = (List<Coordinate>) map.Coordinates;

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(30.6F, result[0].Latitude);
            Assert.AreEqual(40.6F, result[0].Longitude);
            Assert.AreEqual(30.0F, result[1].Latitude);
            Assert.AreEqual(40.0F, result[1].Longitude);
          
        }

        [TestMethod]
        public void Test_updateNumVisits()
        {
            Map map = new Map();
            activities.Add(new SummaryActivity(type: ActivityType.Ride, startLatlng: new LatLng(), movingTime: 60));
            activities[2].StartLatlng.Add((float?)30.0);
            activities[2].StartLatlng.Add((float?)40.0);

            foreach ( var activity in activities)
            {
                map.updateNumVisits(activity);
            }            
            var result = map.NumVisits;

            Assert.AreEqual(2, result.Count);
            result.TryGetValue(new Coordinate(30.0F, 40.0F), out var visits);
            Assert.AreEqual(2, visits);
        }
    }
}
