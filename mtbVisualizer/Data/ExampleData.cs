using IO.Swagger.Model;
using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Data
{
    public static class ExampleData
    {

        public static IList<VisualActivity> MapVisualActivitiesList()
        {
            IList<VisualActivity> activities = new List<VisualActivity>();

            int id = 1;
            var date = new DateTime(2019, 6, 21);

            //Tiger Mountain
            for(int i =0; i< 5; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id );

                summary.StartLatlng.Add(47.47F);
                summary.StartLatlng.Add(-121.93F);
                summary.EndLatlng.Add(47.47F);
                summary.EndLatlng.Add(-121.93F);
                activities.Add(new VisualActivity(summary));                
            }


            //Duthie Hill
            for (int i = 0; i < 15; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                summary.StartLatlng.Add(47.57F);
                summary.StartLatlng.Add(-121.98F);
                summary.EndLatlng.Add(47.57F);
                summary.EndLatlng.Add(-121.98F);
                activities.Add(new VisualActivity(summary));
            }

            //Swan creek
            for (int i = 0; i < 50; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);


                summary.StartLatlng.Add(47.21F);
                summary.StartLatlng.Add(-122.40F);
                summary.EndLatlng.Add(47.21F);
                summary.EndLatlng.Add(-122.40F);                
                activities.Add(new VisualActivity(summary));
            }

            //Capital State
            for (int i = 0; i < 30; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Ride, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                summary.StartLatlng.Add(46.94F);
                summary.StartLatlng.Add(-123.13F);
                summary.EndLatlng.Add(46.94F);
                summary.EndLatlng.Add(-123.13F);
                activities.Add(new VisualActivity(summary));
            }

            //Capital State Runs
            for (int i = 0; i < 20; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                summary.StartLatlng.Add(46.94F);
                summary.StartLatlng.Add(-123.13F);
                summary.EndLatlng.Add(46.94F);
                summary.EndLatlng.Add(-123.13F);
                activities.Add(new VisualActivity(summary));
            }

            //Point Defiance Runs
            for (int i = 0; i < 5; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);
                
                summary.StartLatlng.Add(47.31F);
                summary.StartLatlng.Add(-122.53F);
                summary.EndLatlng.Add(47.31F);
                summary.EndLatlng.Add(-122.53F);
                activities.Add(new VisualActivity(summary));
            }
            
            //Point Defiance Runs
            for (int i = 0; i < 7; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Run, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);
                
                summary.StartLatlng.Add(47.20F);
                summary.StartLatlng.Add(-122.57F);
                summary.EndLatlng.Add(47.20F);
                summary.EndLatlng.Add(-122.57F);
                activities.Add(new VisualActivity(summary));
            }
            return activities;
        }

        public static IList<VisualActivity> MonthVisualActivitiesList()
        {
            IList<VisualActivity> activities = new List<VisualActivity>();
            Random gen = new Random();            
            var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var firstDayOfTheWeek = MonthSummary.getCurrentWeekStartDate(DateTime.Today);
            var dates = randomDatesThisMonth(gen, firstDayOfMonth, firstDayOfTheWeek);

            if (dates.Contains(firstDayOfTheWeek))
            {
                dates.Remove(firstDayOfTheWeek);
            }

            int id = 1; 
            foreach(var date in dates)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Crossfit, movingTime: 60, distance: 3, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: date, id: id);

                summary.StartLatlng.Add(30.0F);
                summary.StartLatlng.Add(40.0F);
                summary.EndLatlng.Add(30.0F);
                summary.EndLatlng.Add(40.0F);
                activities.Add(new VisualActivity(summary));
                id++;
            }

            var summaryForCurrentDay = new SummaryActivity(name: "Morning run", startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Run, movingTime: 60, distance: 5000, elapsedTime: 1380, athlete: new MetaAthlete(123), startDate: DateTime.Today, id: id);
            summaryForCurrentDay.StartLatlng.Add(30.0F);
            summaryForCurrentDay.StartLatlng.Add(40.0F);
            summaryForCurrentDay.EndLatlng.Add(30.0F);
            summaryForCurrentDay.EndLatlng.Add(40.0F);
            activities.Add(new VisualActivity(summaryForCurrentDay));
            
            return activities;
        }

        public static MonthSummary GetMonthSummary()
        {
            var today =  DateTime.Now;
            MonthSummary month = new MonthSummary(today, MonthVisualActivitiesList() );

            return month;
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
