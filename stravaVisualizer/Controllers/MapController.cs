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

namespace stravaVisualizer.Controllers
{
    [Route("Map")]
    [Authorize]
    public class MapController : Controller
    {
        private readonly StravaUserActivitiesDbContext _db;
        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(StravaUserActivitiesDbContext db)
        {
            _db = db;
        }
        
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

        [Route("")]
        public async Task<IActionResult> Index()
        {
            IList<GeoCoordinate> coordinates = new List<GeoCoordinate>();
            
            coordinates.Add(new GeoCoordinate(47.04, -122.97 ));
            coordinates.Add(new GeoCoordinate(47.24, -122.97 ));
            coordinates.Add(new GeoCoordinate(47.34, -123.00 ));

            return View("Bing", coordinates);
        }



        }
}