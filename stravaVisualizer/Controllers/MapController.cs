using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stravaVisualizer.Data;
using stravaVisualizer.Models;
using GeoCoordinatePortable;
using StravaVisualizer.Models;
using IO.Swagger.Model;
using System.Diagnostics;

namespace stravaVisualizer.Controllers
{
   
    [Authorize]
    public class MapController : Controller
    {
       // private readonly StravaUserActivitiesDbContext _db;
        public IDictionary<string, string> AuthProperties { get; set; }

        //public MapController(StravaUserActivitiesDbContext db)
        //{
        //    //_db = db;
        //}
        
        //[Route("")]
        //public async Task<IActionResult> Index()
        //{
        //    var authResult = await HttpContext.AuthenticateAsync();
        //    AuthProperties = authResult.Properties.Items;

        //    var accessToken = AuthProperties.FirstOrDefault(p => p.Key == ".Token.access_token").Value;
        //    ViewBag.Token = accessToken;

        //    var activities = StravaUserActivities.requestUserActivities(accessToken);
        //    var latlong = activities.First().StartLatlng.Take(2);
        //    String latlongString = latlong.ElementAt(0).ToString() + "," +latlong.ElementAt(1).ToString();
        //    ViewBag.latlong = latlongString;
        //    return View();
        //}

     
        public async Task<IActionResult> Index()
        {                
            return View("MapAsync");
        }

    
        public  ActionResult LoadMap()
        {
            string accessToken = getAccessToken().Result;
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            Debug.WriteLine("Load Map called!");
            Map map = new Map();
            map.Activities = StravaClient.requesAllUserActivities(accessToken, stravaId).Result;
            map.generatePinsByType(ActivityType.Ride);

            return PartialView("_BingMapPartial", map.Coordinates);
        }

        public PartialViewResult Partial()
        {
            return PartialView("_Partial");
        }

        private async Task<string> getAccessToken()
        {
            var authResult = await HttpContext.AuthenticateAsync();            
            AuthProperties = authResult.Properties.Items;
            return AuthProperties.FirstOrDefault(p => p.Key == ".Token.access_token").Value;
        }

      
    }
}