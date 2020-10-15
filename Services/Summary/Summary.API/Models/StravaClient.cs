using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Concurrent;

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
            int totalRides_Runs_Swims = athleteStats.AllRideTotals.Count.Value;
            totalRides_Runs_Swims += athleteStats.AllRunTotals.Count.Value;
            totalRides_Runs_Swims += athleteStats.AllSwimTotals.Count.Value;
                        
            return totalRides_Runs_Swims;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivities( int totalRides_Runs_Swims, int perPage =30)
        {
            var activities = new ConcurrentBag<SummaryActivity>();
            int numPages = totalRides_Runs_Swims / perPage + 1;

            //Loop for total/30 times to get at least the number of total rides, swims, and runs
            Parallel.For(1, numPages, async page =>
            {

                var activitiesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: page, perPage: perPage);
                if (activitiesPage != null && activitiesPage.Count != 0)
                {
                    activities.AddRange(activitiesPage);
                }
            });

            //Then sequentially request pages until returned page is empty
            //This allows us to get the remaining actvities includes in the total (ski, yoga, workout, etc.)
            while (true)
            {
                var activitesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: numPages, perPage: perPage);
                if (activitesPage == null || activitesPage.Count == 0)
                {
                    break;
                }

                activities.AddRange(activitesPage);
                numPages++;
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

    public static class Extensions
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
            {
                @this.Add(element);
            }
        }
    }
}