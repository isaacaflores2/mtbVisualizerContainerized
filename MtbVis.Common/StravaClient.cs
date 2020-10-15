using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Concurrent;

namespace MtbVis.Common
{
    public class StravaClient : IStravaClient
    {
        private readonly IActivitiesApi _activitiesApi;

        private readonly IAthletesApi _athletesApi;

        public StravaClient(IActivitiesApi activitiesApi, IAthletesApi athletesApi)
        {
            this._activitiesApi = activitiesApi;
            this._athletesApi = athletesApi;
        }

        public IEnumerable<VisualActivity> getAllUserActivities(string accessToken, int userId)
        {
            var summaryActivities = requestAllUserActivitiesAsync(accessToken, userId).Result;
            List<VisualActivity> visualActivites = new List<VisualActivity>();
            foreach (var summary in summaryActivities)
            {
                visualActivites.Add(new VisualActivity(summary));
            }
            return visualActivites.AsEnumerable();
        }

        public async Task<IEnumerable<SummaryActivity>> requestAllUserActivitiesAsync(string accessToken, int userId)
        {
            Configuration.Default.AccessToken = accessToken;

            try
            {
                var athleteStats = await _athletesApi.GetStatsAsync(userId);
                int totalActivites = calcTotalActivityCount(athleteStats);
                return await requestActivities(totalActivites);
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

        private async Task<IEnumerable<SummaryActivity>> requestActivities(int totalRides_Runs_Swims, int perPage = 30)
        {
            var activities = new ConcurrentBag<SummaryActivity>();
            int numPages = totalRides_Runs_Swims / perPage + 1;

            //Loop for total/perPage times to get at least the number of total rides, swims, and runs
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

        public IEnumerable<VisualActivity> getUserActivitiesByIdAfter(string accessToken, DateTime afterDate)
        {
            var summaryActivities = requestActivitiesAfterAsync(accessToken, afterDate, perPage: 50).Result;

            if (summaryActivities == null)
            {
                return null;
            }

            var visualActivites = new List<VisualActivity>();
            foreach (var summary in summaryActivities)
            {
                visualActivites.Add(new VisualActivity(summary));
            }

            return visualActivites.AsEnumerable();
        }

        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAfterAsync(string accessToken, DateTime afterDate, int perPage = 30)
        {
            Configuration.Default.AccessToken = accessToken;

            try
            {
                var activities = new List<SummaryActivity>();
                var dto = new DateTimeOffset(afterDate);
                var afterDateEpoch = (int)dto.ToUnixTimeSeconds();

                int i = 1;
                while (true)
                {
                    var activitesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i, after: afterDateEpoch, perPage: perPage);
                    if (activitesPage.Count == 0)
                    {
                        break;
                    }

                    activities.AddRange(activitesPage);
                    i++;
                }
                return activities;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        public IEnumerable<Coordinates> getAllUserCoordinatesById(string accessToken, int id)
        {
            var activities = getAllUserActivities(accessToken, id);

            return extractCoordinates(activities);
        }

        public IEnumerable<Coordinates> getUserCoordinatesByIdAfter(string accessToken, DateTime afterDate)
        {
            var activities = getUserActivitiesByIdAfter(accessToken, afterDate);

            return extractCoordinates(activities);
        }

        private IEnumerable<Coordinates> extractCoordinates(IEnumerable<VisualActivity> activities)
        {
            if (activities == null)
            {
                return null;
            }

            ICollection<Coordinates> coordinates = new LinkedList<Coordinates>();
            foreach (var activity in activities)
            {
                coordinates.Add(
                    new Coordinates(activity.UserId, activity.ActivityId, activity.Summary.Type.ToString(), activity.StartLat, activity.StartLong)
                );
            }

            return coordinates;
        }
    }
}