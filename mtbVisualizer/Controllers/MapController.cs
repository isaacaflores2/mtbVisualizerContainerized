using IO.Swagger.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtbVisualizer.Services;
using MtbVisualizer.Data;
using MtbVisualizer.Models;
using MtbVisualizer.Models.Activities;
using MtbVisualizer.Models.Map;
using MtbVisualizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Controllers
{
    
    public class MapController : Controller
    {
        private readonly IHttpContextHelper _httpContextHelper;        
        private readonly IStravaVisualizerRepository _context;
        private readonly IMapCoordinatesService mapCoordinatesService;

        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(IHttpContextHelper httpContextHelper, IStravaVisualizerRepository userActivityRepository, 
                                IMapCoordinatesService mapCoordinatesService) 
        {
            this._httpContextHelper = httpContextHelper;            
            this._context = userActivityRepository;
            this.mapCoordinatesService = mapCoordinatesService;
        }

        public IActionResult Index()
        {                
            return View("Index");
        }
    
        public async Task<PartialViewResult> LoadMapPartial()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    var exampleCoordinates = _map.getCoordinates(ExampleData.MapVisualActivitiesList());
            //    return PartialView("_BingMapPartial", exampleCoordinates);
            //}

            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            
            var activityCoordinates = (await mapCoordinatesService.GetActivityCoordinates(accessToken, stravaId)).ToList();
            var coordinates = convertToCoordinates(activityCoordinates);

            return PartialView("_BingMapPartial", coordinates);
        }

        private ICollection<Coordinate> convertToCoordinates(ICollection<ActivityCoordinates> activityCoordinates)
        {
            if( activityCoordinates == null || activityCoordinates.Count == 0)
            {
                return null; 
            }
            
            var coordinates = extractCoordinates(activityCoordinates);

            return coordinates;
        }

        private ICollection<Coordinate> extractCoordinates(ICollection<ActivityCoordinates> activityCoordinates)
        {
            var coordinates = new LinkedList<Coordinate>();
            foreach (var a in activityCoordinates)
            {
                if (a == null )
                    continue;

                coordinates.AddLast( new Coordinate(a.Latitude, a.Longitude));
            }

            return coordinates;
        }

        public async Task<PartialViewResult> LoadMapByTypePartial(String type)
        {

            //Enum.TryParse(type, out ActivityType activityType);

            //if (!User.Identity.IsAuthenticated)
            //{                
            //    var exampleCoordinates = _map.getCoordinatesByType(ExampleData.MapVisualActivitiesList(), activityType);
            //    return PartialView("_BingMapPartial", exampleCoordinates);
            //}

            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);

            var activityCoordinates = (await mapCoordinatesService.GetActivityCoordinates(accessToken, stravaId)).ToList();
            var activityCoordinatesByType = GetActivityCoordinatesByType(activityCoordinates, type);
            var coordinates = convertToCoordinates(activityCoordinatesByType);
            
            return PartialView("_BingMapPartial", coordinates);
        }

        private ICollection<ActivityCoordinates> GetActivityCoordinatesByType(ICollection<ActivityCoordinates> activityCoordinates, string type)
        {
            var activityCoordinatesByType = (from activity in activityCoordinates
                                            where activity.ActivityType == type
                                            select activity).ToList();

            return activityCoordinatesByType;
        }

   
        //private StravaUser getUpdatedUserActivities(string accessToken, int id)
        //{
        //    var user = _context.GetStravaUserById(id);

        //    if (user == null || user.VisualActivities == null || user.VisualActivities.Count == 0)
        //    {
        //        var activities = _stravaClient.getAllUserActivities(accessToken, id);
        //        user = new StravaUser()
        //        {
        //            VisualActivities = activities.ToList(),
        //            UserId = id,
        //            LastDownload = DateTime.Now.Date
        //        };
        //        _context.Add(user);
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        var lastDownloadDate = new DateTime(2019, 9, 29);
        //        var latestActivities = _stravaClient.getUserActivitiesAfter(accessToken, user, user.LastDownload);

        //        if (latestActivities != null)
        //        {
        //            foreach (var activity in latestActivities)
        //            {
        //                if (!_context.Contains(activity))
        //                {
        //                    _context.Add(activity);
        //                    user.VisualActivities.Add(activity);
        //                }
        //            }
        //            _context.SaveChanges();
        //        }
        //    }
        //    return user; 
        //} 
    }
}