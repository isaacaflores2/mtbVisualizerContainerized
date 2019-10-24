using IO.Swagger.Model;
using StravaVisualizer.Models.Activities;
using StravaVisualizer.Models.MonthSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StravaVisualizer.Data
{
    public static class ExampleData
    {
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

            var summaryForThisWeek = new SummaryActivity(name: "Morning run", startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Crossfit, movingTime: 60, distance: 5000, elapsedTime: 3000, athlete: new MetaAthlete(123), startDate: firstDayOfTheWeek, id: id);
            summaryForThisWeek.StartLatlng.Add(30.0F);
            summaryForThisWeek.StartLatlng.Add(40.0F);
            summaryForThisWeek.EndLatlng.Add(30.0F);
            summaryForThisWeek.EndLatlng.Add(40.0F);
            activities.Add(new VisualActivity(summaryForThisWeek));
            
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
