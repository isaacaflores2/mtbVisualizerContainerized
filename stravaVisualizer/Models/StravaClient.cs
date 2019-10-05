using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Newtonsoft.Json;
using System.Diagnostics;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace StravaVisualizer.Models
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

        public IEnumerable<SummaryActivity> getAllUserActivities(string accessToken, int id)
        {
            return requestAllUserActivitiesAsync(accessToken, id).Result;
        }

        public async Task<IEnumerable<SummaryActivity>> requestAllUserActivitiesAsync(string accessToken, int id)
        {           
            Configuration.Default.AccessToken = accessToken;

            try
            {
                ActivityStats athleteStats = await _athletesApi.GetStatsAsync(id);                
                int totalRides = athleteStats.AllRideTotals.Count.Value;
                totalRides += athleteStats.AllRunTotals.Count.Value;
                totalRides += athleteStats.AllSwimTotals.Count.Value;
                return  await requestActivities(totalRides);                             
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivities( int total)
        {
            List<SummaryActivity> activities = new List<SummaryActivity>();
            int requiredPages = (int) Math.Ceiling(total /30.0);
                           
            for(int i = 1; i <= requiredPages; i++)
            {
                var activitesPage =  await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i);                
                activities.AddRange(activitesPage);
            }
            return activities;
        }
       
        public IEnumerable<SummaryActivity> getUserActivitiesAfter(string accessToken, int id, DateTime afterDate)
        {
            return requestActivitiesAfterAsync(accessToken, id, afterDate).Result;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAfterAsync(string accessToken, int id, DateTime afterDate)
        {
            Configuration.Default.AccessToken = accessToken;                       
            int requirePages = 60;

            try
            {
                return await requestActivitiesAfter(requirePages, afterDate);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAfter(int total, DateTime afterDate)
        {
            List<SummaryActivity> activities = new List<SummaryActivity>();
            DateTimeOffset dto = new DateTimeOffset(afterDate);
            var afterDateEpoch = (int)dto.ToUnixTimeSeconds();
            int requiredPages = (int)Math.Ceiling(total / 30.0);

            for (int i = 1; i <= requiredPages; i++)
            {
                var activitesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i, after: afterDateEpoch);
                activities.AddRange(activitesPage);
            }
            return activities;
        }

    }
}
