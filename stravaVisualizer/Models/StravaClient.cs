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
        public async Task<IEnumerable<SummaryActivity>> allUserActivities(string accessToken, int id)
        {
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = accessToken;
            var activitiesApiInstance = new ActivitiesApi();
            var athleteApiInstance = new AthletesApi();

            try
            {
                ActivityStats athleteStats = athleteApiInstance.GetStats(id);
                int totalRides = athleteStats.AllRideTotals.Count.Value;
                totalRides += athleteStats.AllRunTotals.Count.Value;
                totalRides += athleteStats.AllSwimTotals.Count.Value;
                return await getActivities(activitiesApiInstance, totalRides);                             
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        public async Task<List<SummaryActivity>> getActivities(ActivitiesApi api, int total)
        {
            List<SummaryActivity> activities = new List<SummaryActivity>();
            int requiredPages = (int) Math.Ceiling(total /30.0);
                           
            for(int i = 1; i <= requiredPages; i++)
            {
                var activitesPage =  await api.GetLoggedInAthleteActivitiesAsync(page: i);                
                activities.AddRange(activitesPage);
            }
            return activities;
        }


        public  IEnumerable<SummaryActivity> requestUserActivities_After(string accessToken, DateTime afterDate)
        {
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = accessToken;
            var apiInstance = new ActivitiesApi();
            DateTimeOffset dto = new DateTimeOffset(afterDate);
            var after = dto.ToUnixTimeSeconds();  // Integer | An epoch timestamp to use for filtering activities that have taken place after a certain time. (optional) 
            
            try
            {
                // List Athlete Activities
                List<SummaryActivity> result = apiInstance.GetLoggedInAthleteActivities(page: 100);
                return result;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        IEnumerable<SummaryActivity> IStravaClient.requesAllUserActivities(string accessToken, int id)
        {
            return allUserActivities(accessToken, id).Result;
        }

        public IEnumerable<SummaryActivity> requesUserActivitiesAfter(string accessToken, int id, DateTime afterDate)
        {
            throw new NotImplementedException();
        }
    }
}
