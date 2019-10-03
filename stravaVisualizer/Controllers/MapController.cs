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
using Microsoft.AspNetCore.Identity;

namespace stravaVisualizer.Controllers
{   
    [Authorize]
    public class MapController : Controller
    {
        private readonly IHttpContextHelper _httpContextHelper;

        // private readonly StravaUserActivitiesDbContext _db;        
        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(IHttpContextHelper httpContextHelper)
        {
            this._httpContextHelper = httpContextHelper;
        }

        public IActionResult Index()
        {                
            return View("MapAsync");
        }
    
        public  PartialViewResult LoadMap()
        {
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            
            Map map = new Map();
            //map.Activities = StravaClient.requesAllUserActivities(accessToken, stravaId).Result;
            //map.generatePinsByType(ActivityType.Ride);

            return PartialView("_BingMapPartial", map.Coordinates);
        }
   
        private async Task<string> getAccessToken()
        {                       
            //var authResult = await HttpContext.AuthenticateAsync();               
            //AuthProperties = authResult.Properties.Items;
            //return AuthProperties.FirstOrDefault(p => p.Key == ".Token.access_token").Value;
            return await HttpContext.GetTokenAsync("access_token");
        }

      
    }
}