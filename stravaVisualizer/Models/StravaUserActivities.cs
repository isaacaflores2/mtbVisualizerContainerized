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

namespace stravaVisualizer.Models
{
    public class StravaUserActivities
    {
        public int Id { get; set; }
        public string _userActivities;

        public string UserActivities
        {
            get
            {
                return _userActivities;
            }
            set
            {
                _userActivities = JsonConvert.SerializeObject(value);
            }
        }

        public StravaUserActivities()
        {            
        }
        //public IEnumerable<GeoCoordinate> ActivityCoordinates { get; set;}

        public static IEnumerable<SummaryActivity> requestUserActivities(string accessToken)
        {
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = accessToken;

            var apiInstance = new ActivitiesApi();
            var before = 56;  // Integer | An epoch timestamp to use for filtering activities that have taken place before a certain time. (optional) 
            var after = 56;  // Integer | An epoch timestamp to use for filtering activities that have taken place after a certain time. (optional) 
            var page = 56;  // Integer | Page number. (optional) 
            var perPage = 56;  // Integer | Number of items per page. Defaults to 30. (optional)  (default to 30)

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
