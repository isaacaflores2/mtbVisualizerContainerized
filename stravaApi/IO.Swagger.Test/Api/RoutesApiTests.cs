/* 
 * Strava API v3
 *
 * The [Swagger Playground](https://developers.strava.com/playground) is the easiest way to familiarize yourself with the Strava API by submitting HTTP requests and observing the responses before you write any client code. It will show what a response will look like with different endpoints depending on the authorization scope you receive from your athletes. To use the Playground, go to https://www.strava.com/settings/api and change your “Authorization Callback Domain” to developers.strava.com. Please note, we only support Swagger 2.0. There is a known issue where you can only select one scope at a time. For more information, please check the section “client code” at https://developers.strava.com/docs.
 *
 * OpenAPI spec version: 3.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing RoutesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class RoutesApiTests
    {
        private RoutesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new RoutesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of RoutesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' RoutesApi
            //Assert.IsInstanceOfType(typeof(RoutesApi), instance, "instance is a RoutesApi");
        }

        
        /// <summary>
        /// Test GetRouteAsGPX
        /// </summary>
        [Test]
        public void GetRouteAsGPXTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //instance.GetRouteAsGPX(id);
            
        }
        
        /// <summary>
        /// Test GetRouteAsTCX
        /// </summary>
        [Test]
        public void GetRouteAsTCXTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //instance.GetRouteAsTCX(id);
            
        }
        
        /// <summary>
        /// Test GetRouteById
        /// </summary>
        [Test]
        public void GetRouteByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //var response = instance.GetRouteById(id);
            //Assert.IsInstanceOf<Route> (response, "response is Route");
        }
        
        /// <summary>
        /// Test GetRoutesByAthleteId
        /// </summary>
        [Test]
        public void GetRoutesByAthleteIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //int? page = null;
            //int? perPage = null;
            //var response = instance.GetRoutesByAthleteId(id, page, perPage);
            //Assert.IsInstanceOf<List<Route>> (response, "response is List<Route>");
        }
        
    }

}
