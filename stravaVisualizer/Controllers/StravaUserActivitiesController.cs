using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using stravaVisualizer.Data;
using stravaVisualizer.Models;

namespace stravaVisualizer.Controllers
{
    [Route("maps")]
    public class StravaUserActivitiesController : Controller
    {
        private readonly StravaUserActivitiesDbContext _db;
        public IDictionary<string, string> AuthProperties { get; set; }

        public StravaUserActivitiesController(StravaUserActivitiesDbContext db)
        {
            _db = db;
        }
        
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            AuthProperties = authResult.Properties.Items;

            var accessToken = AuthProperties.FirstOrDefault(p => p.Key == ".Token.access_token").Value;
            ViewBag.Token = accessToken;

            var activities = StravaUserActivities.requestUserActivities(accessToken);
            var latlong = activities.First().StartLatlng.Take(2);
            String latlongString = latlong.ElementAt(0).ToString() + "," +latlong.ElementAt(1).ToString();
            ViewBag.latlong = latlongString;
            return View();
        }
        
    }
}