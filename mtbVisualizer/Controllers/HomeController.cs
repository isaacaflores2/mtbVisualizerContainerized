using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MtbVisualizer.Models;
using MtbVisualizer.Data;
using MtbVisualizer.Models;
using MtbVisualizer.Models.Activities;
using mtbVisualizer.Services;
using MtbVisualizer.ViewModels;
using System.Threading.Tasks;

namespace MtbVisualizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISummaryService summaryService;
        private readonly IHttpContextHelper httpContextHelper;


        public HomeController(IHttpContextHelper httpContextHelper, ISummaryService summaryService)
        {
            this.httpContextHelper = httpContextHelper;            
            this.summaryService = summaryService;
        }

        public IActionResult Index()
        {            
            return View("Index");                        
        }

        public async Task<PartialViewResult> LoadCalendarPartial(DateTime date)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    MonthSummary exampleMonthSummary = ExampleData.GetMonthSummary();
            //    return PartialView("_CalendarPartial", exampleMonthSummary);
            //}

            httpContextHelper.Context = HttpContext;
            string accessToken = httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);

            var monthSummaryActivities = (await summaryService.GetMonthSummaryActivities(accessToken, stravaId)).ToList();
            
            return PartialView("_CalendarPartial", monthSummaryActivities);
        }

        public async Task<PartialViewResult> LoadTablePartial(DateTime date)
        {
            if (!User.Identity.IsAuthenticated)
            {
                MonthSummary exampleMonthSummary = ExampleData.GetMonthSummary();
                IList<VisualActivity> exampleActivities = exampleMonthSummary.getActivitiesForThisWeek(exampleMonthSummary.Activites);
                return PartialView("_TablePartial", exampleActivities);
            }

            httpContextHelper.Context = HttpContext;
            string accessToken = httpContextHelper.getAccessToken();
            int stravaId = Convert.ToInt32(User.FindFirst("stravaId").Value);

            var monthSummaryActivities = (await summaryService.GetMonthSummaryActivities(accessToken, stravaId)).ToList();
            var activitiesThisWeek = MonthSummaryActivity.getActivitiesForThisWeek(monthSummaryActivities, date);
                        
            return PartialView("_TablePartial", activitiesThisWeek);
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