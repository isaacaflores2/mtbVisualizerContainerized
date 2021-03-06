﻿using IO.Swagger.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtbVisualizer.Services;
using MtbVisualizer.Data;
using MtbVisualizer.Models;
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
        private readonly IMapCoordinatesService mapCoordinatesService;

        public IDictionary<string, string> AuthProperties { get; set; }

        public MapController(IHttpContextHelper httpContextHelper, IMapCoordinatesService mapCoordinatesService) 
        {
            this._httpContextHelper = httpContextHelper;                        
            this.mapCoordinatesService = mapCoordinatesService;
        }

        public IActionResult Index()
        {                
            return View("Index");
        }
    
        public async Task<PartialViewResult> LoadMapPartial()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var exampleActivityCoordinates = ExampleData.ActivityCoordinatesList();
                return PartialView("_BingMapPartial", exampleActivityCoordinates);
            }

            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
            
            var activityCoordinates = (await mapCoordinatesService.GetActivityCoordinates(accessToken, stravaId)).ToList();
    
            return PartialView("_BingMapPartial", activityCoordinates);
        }

        public async Task<PartialViewResult> LoadMapByTypePartial(string type)
        {            
            if (!User.Identity.IsAuthenticated)
            {
                var exampleActivityCoordinatesByType = ActivityCoordinates.GetActivityCoordinatesByType(ExampleData.ActivityCoordinatesList(), type);
                return PartialView("_BingMapPartial", exampleActivityCoordinatesByType);
            }

            _httpContextHelper.Context = HttpContext;
            string accessToken = _httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);

            var activityCoordinates = (await mapCoordinatesService.GetActivityCoordinates(accessToken, stravaId)).ToList();
            var activityCoordinatesByType = ActivityCoordinates.GetActivityCoordinatesByType(activityCoordinates, type);
            
            return PartialView("_BingMapPartial", activityCoordinatesByType);
        }       
    }
}