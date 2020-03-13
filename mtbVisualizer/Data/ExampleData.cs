using IO.Swagger.Model;
using MtbVisualizer.Models.Activities;
using MtbVisualizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Data
{
    public static class ExampleData
    {

        public static IList<ActivityCoordinates> ActivityCoordinatesList()
        {
            IList<ActivityCoordinates> activities = new List<ActivityCoordinates>();

            int id = 1;
            var date = new DateTime(2019, 6, 21);

            //Tiger Mountain
            for(int i =0; i< 5; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id );

                //summary.StartLatlng.Add(47.47F);
                //summary.StartLatlng.Add(-121.93F);
                //summary.EndLatlng.Add(47.47F);
                //summary.EndLatlng.Add(-121.93F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Ride.ToString(),
                    Latitude = 47.47F,
                    Longitude = -121.93F
                };

                activities.Add(activityCoordinate);                
            }


            //Duthie Hill
            for (int i = 0; i < 15; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                //summary.StartLatlng.Add(47.57F);
                //summary.StartLatlng.Add(-121.98F);
                //summary.EndLatlng.Add(47.57F);
                //summary.EndLatlng.Add(-121.98F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Ride.ToString(),
                    Latitude = 47.57F,
                    Longitude = -121.98F
                };

                activities.Add(activityCoordinate);
            }

            //Swan creek
            for (int i = 0; i < 50; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);
                //summary.StartLatlng.Add(47.21F);
                //summary.StartLatlng.Add(-122.40F);
                //summary.EndLatlng.Add(47.21F);
                //summary.EndLatlng.Add(-122.40F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Ride.ToString(),
                    Latitude = 47.21F,
                    Longitude = -122.40F
                };

                activities.Add(activityCoordinate);
            }

            //Capital State
            for (int i = 0; i < 30; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                //summary.StartLatlng.Add(46.94F);
                //summary.StartLatlng.Add(-123.13F);
                //summary.EndLatlng.Add(46.94F);
                //summary.EndLatlng.Add(-123.13F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Ride.ToString(),
                    Latitude = 46.94F,
                    Longitude = -123.13F
                };

                activities.Add(activityCoordinate);
            }

            //Capital State Runs
            for (int i = 0; i < 20; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                //summary.StartLatlng.Add(46.94F);
                //summary.StartLatlng.Add(-123.13F);
                //summary.EndLatlng.Add(46.94F);
                //summary.EndLatlng.Add(-123.13F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Run.ToString(),
                    Latitude = 46.94F,
                    Longitude = -123.13F
                };

                activities.Add(activityCoordinate);
            }

            //Point Defiance Runs
            for (int i = 0; i < 5; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);
                
                //summary.StartLatlng.Add(47.31F);
                //summary.StartLatlng.Add(-122.53F);
                //summary.EndLatlng.Add(47.31F);
                //summary.EndLatlng.Add(-122.53F);
                
                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Run.ToString(),
                    Latitude = 47.31F,
                    Longitude = -122.53F
                };

                activities.Add(activityCoordinate);
            }
            
            //Chambers Bay Runs
            for (int i = 0; i < 7; i++)
            {
                //var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                //    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);
                
                //summary.StartLatlng.Add(47.20F);
                //summary.StartLatlng.Add(-122.57F);
                //summary.EndLatlng.Add(47.20F);
                //summary.EndLatlng.Add(-122.57F);

                var activityCoordinate = new ActivityCoordinates()
                {
                    Id = id,
                    UserID = 123,
                    ActvityID = 1L,
                    ActivityType = ActivityType.Run.ToString(),
                    Latitude = 47.20F,
                    Longitude = -122.57F
                };

                activities.Add(activityCoordinate);
            }
            return activities;
        }

        public static IList<MonthSummaryActivity> GetMonthSummaryActivities()
        {
            IList<MonthSummaryActivity> activities = new List<MonthSummaryActivity>();
            Random gen = new Random();            
            var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var firstDayOfTheWeek = MonthSummaryActivity.getCurrentWeekStartDate(DateTime.Today);
            var dates = randomDatesThisMonth(gen, firstDayOfMonth, firstDayOfTheWeek);

            if (dates.Contains(firstDayOfTheWeek))
            {
                dates.Remove(firstDayOfTheWeek);
            }

            int id = 1; 
            foreach(var date in dates)
            {     
                var monthSummary = new MonthSummaryActivity()
                {
                    Id = id,
                    UserId = 123,
                    Name = "Morning Run",
                    Distance = 5000,
                    ElapsedTime = 1380,
                    Type = ActivityType.Run.ToString(),
                    StartDate = date
                };
                activities.Add(monthSummary);

                id++;
            }

            //var summaryForCurrentDay = new SummaryActivity(name: "Morning run", startLatlng: new LatLng(), endLatlng: new LatLng(),
            //        type: ActivityType.Run, movingTime: 60, distance: 5000, elapsedTime: 1380, athlete: new MetaAthlete(123), startDate: DateTime.Today, id: id);

            //summaryForCurrentDay.StartLatlng.Add(30.0F);
            //summaryForCurrentDay.StartLatlng.Add(40.0F);
            //summaryForCurrentDay.EndLatlng.Add(30.0F);
            //summaryForCurrentDay.EndLatlng.Add(40.0F);

            var summaryForCurrentDay = new MonthSummaryActivity()
            {
                Id = id,
                UserId = 123,
                Name = "Morning Run",
                Distance = 5000,
                ElapsedTime = 1380,
                Type = ActivityType.Run.ToString(),
                StartDate = DateTime.Today
            };
            activities.Add(summaryForCurrentDay);

            return activities;
        }
      
        private static List<DateTime> randomDatesThisMonth(Random gen, DateTime start, DateTime end)
        {
            List<DateTime> dates = new List<DateTime>();

            int range = (end - start).Days - 1;
            
            if(range == 0)
            {
                dates.Add(DateTime.Today);                
            }
            else
            {
                int numActivities = (int) Math.Ceiling(range/2.0);
                for(int i =0; i< numActivities; i++)
                {
                    var newDate =  start.AddDays(gen.Next(range));
                    if (!dates.Contains(newDate))
                    {
                        dates.Add(newDate);
                    }
                }                
            }            
            return dates;
        }
    }
}
