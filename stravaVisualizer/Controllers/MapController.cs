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
using StravaVisualizer.Models.Map;

namespace stravaVisualizer.Controllers
{   
    [Authorize]
    public class MapController : Controller
    {
        private readonly IHttpContextHelper _httpContextHelper;
        private readonly IStravaClient _stravaClient;
        private readonly IMap _map;

        // private readonly StravaUserActivitiesDbContext _db;        
        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(IHttpContextHelper httpContextHelper, IStravaClient stravaClient, IMap map) 
        {
            this._httpContextHelper = httpContextHelper;
            this._stravaClient = stravaClient;
            this._map = map; 
        }

        public IActionResult Index()
        {                
            return View("MapAsync");
        }
    
        public  PartialViewResult LoadMap()
        {
            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            var coordinates = _map.getCoordinatesByType(_stravaClient.getAllUserActivities(accessToken, stravaId), ActivityType.Ride);

            //_map.Activities = _stravaClient.requesAllUserActivities(accessToken, stravaId);
            //map.Activities = StravaClient.requesAllUserActivities(accessToken, stravaId).Result;
            //_map.generatePinsByType(ActivityType.Ride);

            return PartialView("_BingMapPartial", coordinates);
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