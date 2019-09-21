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
    public class StravaClient
    {
                   
        public static IEnumerable<SummaryActivity> requestUserActivities(string accessToken)
        {
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = accessToken;
            var apiInstance = new ActivitiesApi();
            
            try
            {                
                List<SummaryActivity> result = apiInstance.GetLoggedInAthleteActivities();
                return result;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        public static IEnumerable<SummaryActivity> requestUserActivities_After(string accessToken, DateTime afterDate)
        {
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = accessToken;
            var apiInstance = new ActivitiesApi();
            DateTimeOffset dto = new DateTimeOffset(afterDate);
            var after = dto.ToUnixTimeSeconds();  // Integer | An epoch timestamp to use for filtering activities that have taken place after a certain time. (optional) 
            
            try
            {
                // List Athlete Activities
                List<SummaryActivity> result = apiInstance.GetLoggedInAthleteActivities();
                return result;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }
    }
}
