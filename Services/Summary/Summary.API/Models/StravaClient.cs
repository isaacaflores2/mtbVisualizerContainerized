using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace Summary.API.Models
{
    public class StravaClient: IStravaClient
    {
        private readonly IActivitiesApi _activitiesApi;

        private readonly IAthletesApi _athletesApi;

        public StravaClient(IActivitiesApi activitiesApi, IAthletesApi athletesApi)
        {
            this._activitiesApi = activitiesApi;
            this._athletesApi = athletesApi;
        }

        public IEnumerable<VisualActivity> getAllUserActivities(string accessToken, int id)
        {
            var summaryActivities =  requestAllUserActivitiesAsync(accessToken, id).Result;
            List<VisualActivity> visualActivites = new List<VisualActivity>();
            foreach(var summary in summaryActivities)
            {
                visualActivites.Add(new VisualActivity(summary));
            }
            return visualActivites.AsEnumerable(); 
        }

        public async Task<IEnumerable<SummaryActivity>> requestAllUserActivitiesAsync(string accessToken, int id)
        {           
            Configuration.Default.AccessToken = accessToken;

            try
            {
                var athleteStats = await _athletesApi.GetStatsAsync(id);                
                int totalActivites = calcTotalActivityCount(athleteStats);
                return  await requestActivities(totalActivites);                             
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        private int calcTotalActivityCount(ActivityStats athleteStats)
        {            
            int total = athleteStats.AllRideTotals.Count.Value;
            total += athleteStats.AllRunTotals.Count.Value;
            total += athleteStats.AllSwimTotals.Count.Value;
            
            return total;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivities( int total)
        {
            List<SummaryActivity> activities = new List<SummaryActivity>();
            int i = 1;
            while (true)
            {
                var activitesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i);
                if(activitesPage.Count == 0 )
                {
                    break;
                }

                activities.AddRange(activitesPage);
                i++;
            }
            return activities;
        }
       
        public IEnumerable<VisualActivity> getUserActivitiesByIdAfter(string accessToken, User user, DateTime afterDate)
        {
            List<VisualActivity> visualActivites = new List<VisualActivity>();

            if(user.MonthSummaries == null)
            {
                return visualActivites;
            }

            var summaryActivities =  requestActivitiesAfterAsync(accessToken, user, afterDate).Result;

            if (summaryActivities == null)
            {
                return null;
            }

            foreach (var summary in summaryActivities)
            {
                visualActivites.Add(new VisualActivity(summary));
            }
                        
            return visualActivites.AsEnumerable();
        }
    
        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAfterAsync(string accessToken, User user, DateTime afterDate)
        {
            Configuration.Default.AccessToken = accessToken;
            

            try
            {
                var athleteStats = await _athletesApi.GetStatsAsync(user.UserId);
                int totalActivites = calcTotalActivityCount(athleteStats);
                int requiredActivities = getActivityDifferenceSinceLastDownload(user, totalActivites);
                return await requestActivitiesAfter(requiredActivities, afterDate);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        private int getActivityDifferenceSinceLastDownload(User user, int totalActivities)
        {
            int activitesDownloaded = user.MonthSummaries.Count();
            return totalActivities - activitesDownloaded;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAfter(int requiredActivities, DateTime afterDate)
        {
            List<SummaryActivity> activities = new List<SummaryActivity>();
            DateTimeOffset dto = new DateTimeOffset(afterDate);
            var afterDateEpoch = (int)dto.ToUnixTimeSeconds();
            int requiredPages = (int)Math.Ceiling(requiredActivities / 30.0);
  
            int i = 1;
            while (true)
            {
                var activitesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i, after: afterDateEpoch);
                if (activitesPage.Count == 0)
                {
                    break;
                }

                activities.AddRange(activitesPage);
                i++;
            }
            return activities;

        }       
    }
}
