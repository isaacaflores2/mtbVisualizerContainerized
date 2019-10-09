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
using StravaVisualizer.Models.Activities;

namespace stravaVisualizer.Controllers
{   
    [Authorize]
    public class MapController : Controller
    {
        private readonly IHttpContextHelper _httpContextHelper;
        private readonly IStravaClient _stravaClient;
        private readonly IMap _map;
        private readonly IStravaVisualizerRepository _stravaVisualizerRepository;
         
        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(IHttpContextHelper httpContextHelper, IStravaClient stravaClient, IMap map, IStravaVisualizerRepository userActivityRepository) 
        {
            this._httpContextHelper = httpContextHelper;
            this._stravaClient = stravaClient;
            this._map = map;
            this._stravaVisualizerRepository = userActivityRepository;
        }

        public IActionResult Index()
        {                
            return View("MapAsync");
        }
    
        public  async Task<PartialViewResult> LoadMap()
        {
            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            var stravaUser = _stravaVisualizerRepository.GetStravaUserById(stravaId);
            ICollection<Coordinate> coordinates;
            
            if (stravaUser == null || stravaUser.VisualActivities == null || stravaUser.VisualActivities.Count == 0)
            {
                var activities = _stravaClient.getAllUserActivities(accessToken, stravaId);
                stravaUser = new StravaUser()
                {
                    VisualActivities = activities.ToList(),
                    UserId = stravaId,
                    LastDownload = DateTime.Now.Date
                };
                _stravaVisualizerRepository.Add(stravaUser);
                await _stravaVisualizerRepository.SaveChangesAsync();

                foreach (var visualActivity in stravaUser.VisualActivities)
                {
                    _stravaVisualizerRepository.Add(visualActivity);
                   // _stravaVisualizerRepository.SaveChanges();
                }

               
            }
            //var coordinates = _map.getCoordinatesByType(_stravaClient.getAllUserActivities(accessToken, stravaId), ActivityType.Ride);
            
            coordinates = _map.getCoordinatesByType(stravaUser.VisualActivities, ActivityType.Ride);
            
            return PartialView("_BingMapPartial", coordinates);
        }
   
        private async Task<string> getAccessToken()
        {                                   
            return await HttpContext.GetTokenAsync("access_token");
        }
                
    }
}