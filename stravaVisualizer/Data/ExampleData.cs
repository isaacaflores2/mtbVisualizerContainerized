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

            for (int i = 0; i < 10; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Crossfit, movingTime: 60, athlete: new MetaAthlete(123), startDate: new DateTime(2019, 09, i + 1), id: i);

                summary.StartLatlng.Add(30.0F);
                summary.StartLatlng.Add(40.0F);
                summary.EndLatlng.Add(30.0F);
                summary.EndLatlng.Add(40.0F);

                activities.Add(new VisualActivity(summary));
            }

            for (int i = 0; i < 30; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Crossfit, movingTime: 60, athlete: new MetaAthlete(123), startDate: new DateTime(2019, 10, i + 1), id: 9 + i);

                summary.StartLatlng.Add(30.0F);
                summary.StartLatlng.Add(40.0F);
                summary.EndLatlng.Add(30.0F);
                summary.EndLatlng.Add(40.0F);

                activities.Add(new VisualActivity(summary));
            }

            return activities;
        }

        public static MonthSummary GetMonthSummary()
        {
            var today =  DateTime.Now;
            MonthSummary month = new MonthSummary(today, MonthVisualActivitiesList() );

            return null;
        }
    }
}
