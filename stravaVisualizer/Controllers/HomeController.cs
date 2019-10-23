﻿using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using stravaVisualizer.Models;
using StravaVisualizer.Data;
using StravaVisualizer.Models;
using StravaVisualizer.Models.MonthSummary;

namespace StravaVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStravaVisualizerRepository context;
        private readonly IHttpContextHelper _httpContextHelper;

        public HomeController(IHttpContextHelper httpContextHelper, IStravaVisualizerRepository context)
        {
            this._httpContextHelper = httpContextHelper;
            this.context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                _httpContextHelper.Context = HttpContext;
                string accessToken = _httpContextHelper.getAccessToken();
                int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);
                var user = context.GetStravaUserById(stravaId);
                if(user == null || user.VisualActivities == null || user.VisualActivities.Count == 0)
                {
                    return View("Index", null);
                }
                
                MonthSummary monthSummary = new MonthSummary(DateTime.Now, user.VisualActivities.ToList());
                return View("Index", monthSummary);
            }
            else
            {
                MonthSummary monthSummary = ExampleData.GetMonthSummary();
                return View("Index", monthSummary);

            }
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}