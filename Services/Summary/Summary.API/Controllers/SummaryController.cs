using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Summary.API.Data;
using Summary.API.Models;

namespace Summary.API.Controllers
{    
    [ApiController]
    [Route("api/v1/summary")]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryRepository context;
        private readonly IStravaClient stravaClient;

        public SummaryController(ISummaryRepository context, IStravaClient stravaClient)
        {
            this.context = context;
            this.stravaClient = stravaClient;
        }

        // GET: api/v1/summary/month
        [HttpGet]        
        [Route("month")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<MonthSummaryActivity>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<MonthSummaryActivity>> MonthSummaryById(string accessToken, int id, int month)
        {
            if (String.IsNullOrEmpty(accessToken) || id <= 0)
            {
                return BadRequest();
            }
            
            var activities = getUserMonthlyActivities(accessToken, id, month).ToList();

            if (activities != null)
            {
                return activities;
            }

            return NotFound();
        }

        private IEnumerable<MonthSummaryActivity> getUserMonthlyActivities(string accessToken, int id, int month)
        {
            var user = context.GetUserById(id);

            if (user == null || user.MonthSummaries == null || user.MonthSummaries.Count == 0)
            {
                var allUserActivities = stravaClient.getAllUserActivities(accessToken, id);        
                var monthSummaryActivites = convertToMonthSummaryActivities(allUserActivities);

                user = new User()
                {
                    UserId = id,
                    LastDownload = DateTime.Now.Date,
                    MonthSummaries = monthSummaryActivites.ToList(),
                };
                context.Add(user);
                context.SaveChanges();
            }
            else
            {
                var userActivities = stravaClient.getUserActivitiesByIdAfter(accessToken, user, user.LastDownload);              
                var monthSummaryActivites = convertToMonthSummaryActivities(userActivities);

                if (monthSummaryActivites != null)
                {
                    user.LastDownload = DateTime.Now.Date;
                    foreach (var activity in monthSummaryActivites)
                    {
                        if (!context.Contains(activity))
                        {
                            context.Add(activity);
                            user.MonthSummaries.Add(activity);
                        }
                    }
                    context.SaveChanges();
                }
            }

            var activitiesThisMonth = from activity in user.MonthSummaries
                                      where activity.StartDate.Value.Month == month
                                      select activity;

            if (activitiesThisMonth == null || activitiesThisMonth.ToList().Count == 0)
            {
                return null;
            }

            return activitiesThisMonth;
        }

        private IEnumerable<MonthSummaryActivity> convertToMonthSummaryActivities(IEnumerable<VisualActivity> visualActivities){
            var monthSummaryActivities = new LinkedList<MonthSummaryActivity>();

            foreach(var activity in visualActivities)
            {
                monthSummaryActivities.AddLast(
                    new MonthSummaryActivity()
                    {
                        UserId = (int) activity.UserId,
                        Name = activity.Summary.Name,
                        Distance = activity.Summary.Distance,
                        ElapsedTime = activity.Summary.ElapsedTime,
                        Type = activity.Summary.Type.ToString(),
                        StartDate = activity.Summary.StartDate
                    }
                );
            }

            return monthSummaryActivities;
        }

        // GET: api/v1/summary/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}