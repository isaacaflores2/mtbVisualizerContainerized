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
