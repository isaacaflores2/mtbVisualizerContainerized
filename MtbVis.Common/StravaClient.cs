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
                return await requestActivitiesAsync(totalActivites);
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

        public async Task<IEnumerable<SummaryActivity>> requestActivitiesAsync(int totalRides_Runs_Swims, int perPage = 30)
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

            return activities.ToList();
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
                    if (activitesPage == null || activitesPage.Count == 0)
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
            return getAllUserCoordinatesByIdAsync(accessToken, id).Result;
        }

        private async Task<IEnumerable<Coordinates>> getAllUserCoordinatesByIdAsync(string accessToken, int id)
        {
            Configuration.Default.AccessToken = accessToken;

            try
            {
                var athleteStats = await _athletesApi.GetStatsAsync(id);
                int totalActivites = calcTotalActivityCount(athleteStats);
                return await requestCoordinatesAsync(totalActivites);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling getAllUserCoordinatesByIdAsync: " + e.Message);
            }

            return null;
        }

        private async Task<IEnumerable<Coordinates>> requestCoordinatesAsync(int totalRides_Runs_Swims, int perPage = 30)
        {
            var coordinates = new ConcurrentBag<Coordinates>();
            int numPages = totalRides_Runs_Swims / perPage + 1;

            //Loop for total/perPage times to get at least the number of total rides, swims, and runs
            Parallel.For(1, numPages, async page =>
            {

                var activitiesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: page, perPage: perPage);
                if (activitiesPage != null && activitiesPage.Count() != 0)
                {
                    saveActivityStartCoordinates(activitiesPage, coordinates);
                }
            });

            //Then sequentially request pages until returned page is empty
            //This allows us to get the remaining actvities includes in the total (ski, yoga, workout, etc.)
            while (true)
            {
                var activitiesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: numPages, perPage: perPage);
                if (activitiesPage == null || activitiesPage.Count == 0)
                {
                    break;
                }

                saveActivityStartCoordinates(activitiesPage, coordinates);

                numPages++;
            }

            return coordinates;
        }

        public IEnumerable<Coordinates> getUserCoordinatesByIdAfter(string accessToken, DateTime afterDate)
        {
            Configuration.Default.AccessToken = accessToken;
            var coordinates = requestCoordinatesAfterAsync(accessToken, afterDate, perPage: 50).Result;

            return coordinates.AsEnumerable();
        }

        private async Task<IEnumerable<Coordinates>> requestCoordinatesAfterAsync(string accessToken, DateTime afterDate, int perPage = 30)
        {
            try
            {
                var coordinates = new ConcurrentBag<Coordinates>();
                var dto = new DateTimeOffset(afterDate);
                var afterDateEpoch = (int)dto.ToUnixTimeSeconds();
                int i = 1;

                while (true)
                {
                    var activitiesPage = await _activitiesApi.GetLoggedInAthleteActivitiesAsync(page: i, after: afterDateEpoch, perPage: perPage);
                    if (activitiesPage == null || activitiesPage.Count == 0)
                    {
                        break;
                    }

                    saveActivityStartCoordinates(activitiesPage, coordinates);

                    i++;
                }

                return coordinates;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.getLoggedInAthleteActivities: " + e.Message);
            }
            return null;
        }

        private void saveActivityStartCoordinates(IEnumerable<SummaryActivity> summaryActivities, ConcurrentBag<Coordinates> coordinates)
        {
            if (summaryActivities == null && summaryActivities.Count() == 0)
            {
                return;
            }
            
            foreach (var summaryActivity in summaryActivities)
            {
                coordinates.Add(
                    new Coordinates(summaryActivity)
                );
            }
        }
    }
}