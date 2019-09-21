using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IO.Swagger.Model;
using StravaVisualizer.Models;
using Microsoft.AspNetCore.Http;

namespace StravaVisualizerTest
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public async void ExtractCoordinates_Test()
        {
            //var authResult = await HttpContext.AuthenticateAsync();
            //public IDictionary<string, string> AuthProperties { get; set; }
            //AuthProperties = authResult.Properties.Items;
            //var accessToken = AuthProperties.FirstOrDefault(p => p.Key == ".Token.access_token").Value;

            //List<SummaryActivity> activities = StravaClient.requestUserActivities();
            Assert.Fail();
        }
    }
}
