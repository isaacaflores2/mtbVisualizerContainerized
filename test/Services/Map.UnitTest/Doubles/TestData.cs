using IO.Swagger.Model;
using Map.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Map.UnitTest.Doubles
{
    public class  TestData
    {

        public static ICollection<VisualActivity> SingleVisuActvityList()
        {
            var summary1 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                type: ActivityType.Crossfit, movingTime: 60, athlete: new MetaAthlete(123), id: 1);
            
            summary1.StartLatlng.Add(30.0F);
            summary1.StartLatlng.Add(40.0F);            
            summary1.EndLatlng.Add(30.0F);
            summary1.EndLatlng.Add(40.0F);
            

            ICollection<VisualActivity> activities = new List<VisualActivity>
            {
                new VisualActivity(summary1),                   
            };

            return activities;
        }

        public static ICollection<VisualActivity> VisualActivitiesList()
        {
            var summary1 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(), 
                type:ActivityType.Crossfit, movingTime:60, athlete: new MetaAthlete(123), id: 1);
            var summary2 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(), 
                type: ActivityType.Ride, movingTime: 60, athlete: new MetaAthlete(123), id: 2);
            summary1.StartLatlng.Add(30.0F);
            summary1.StartLatlng.Add(40.0F);
            summary2.StartLatlng.Add(30.6F);
            summary2.StartLatlng.Add(40.6F);
            summary1.EndLatlng.Add(30.0F);
            summary1.EndLatlng.Add(40.0F);
            summary2.EndLatlng.Add(30.6F);
            summary2.EndLatlng.Add(40.6F);

            ICollection<VisualActivity> activities = new List<VisualActivity>
            {
                new VisualActivity(summary1),
                new VisualActivity(summary2)
            };

            return activities; 
        }

        public static ICollection<VisualActivity> NewVisualActivitiesList()
        {
            var summary1 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                   type: ActivityType.Ride, movingTime: 60, athlete: new MetaAthlete(123), id: 2);
            var summary2 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                type: ActivityType.Ride, movingTime: 15, athlete: new MetaAthlete(123), id: 3);
            summary1.StartLatlng.Add(30.0F);
            summary1.StartLatlng.Add(40.0F);
            summary2.StartLatlng.Add(30.6F);
            summary2.StartLatlng.Add(40.6F);
            summary1.EndLatlng.Add(30.0F);
            summary1.EndLatlng.Add(40.0F);
            summary2.EndLatlng.Add(30.6F);
            summary2.EndLatlng.Add(40.6F);

            ICollection<VisualActivity> activities = new List<VisualActivity>
            {
                new VisualActivity(summary1),
                new VisualActivity(summary2)
            };

            return activities;
        }

        public static ICollection<Coordinates> CoordinatesList()
        {
         
            ICollection<Coordinates> coordinates = new List<Coordinates>
            {
                new Coordinates(123, 1, ActivityType.Crossfit.ToString(), 30.0F, 40.0F),
                new Coordinates(123, 2, ActivityType.Ride.ToString(), 30.6F, 40.6F),              
            };

            return coordinates;
        }

        public static ICollection<Coordinates> NewCoordinatesList()
        {
            ICollection<Coordinates> coordinates = new List<Coordinates>
            {
                new Coordinates(123, 3, ActivityType.Ride.ToString(), 30.0F, 40.0F),
                new Coordinates(123, 4, ActivityType.Ride.ToString(), 30.6F, 40.6F),
            };

            return coordinates;
        }

        public static SummaryActivity SummaryActivity1()
        {
            var summary1 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(), 
                type: ActivityType.Crossfit, movingTime: 60, athlete: new MetaAthlete(123));
            
            summary1.StartLatlng.Add(30.0F);
            summary1.StartLatlng.Add(40.0F);
         
            summary1.EndLatlng.Add(30.0F);
            summary1.EndLatlng.Add(40.0F);
          

            return summary1;
        }

        public static SummaryActivity SummaryActivity2()
        {
            
            var summary2 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(), 
                type: ActivityType.Ride, movingTime: 60, athlete: new MetaAthlete(123));
            
            summary2.StartLatlng.Add(30.6F);
            summary2.StartLatlng.Add(40.6F);
            
            summary2.EndLatlng.Add(30.6F);
            summary2.EndLatlng.Add(40.6F);

            return summary2;
        }

        public static SummaryActivity SummaryActivity3()
        {

            var summary2 = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                 type: ActivityType.Run, movingTime: 100, athlete: new MetaAthlete(123));

            summary2.StartLatlng.Add(30.6F);
            summary2.StartLatlng.Add(40.6F);

            summary2.EndLatlng.Add(30.6F);
            summary2.EndLatlng.Add(40.6F);

            return summary2;
        }

        public static ICollection<VisualActivity> MonthVisualActivitiesList()
        {
            ICollection<VisualActivity> activities = new List<VisualActivity>();        

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

            for (int i = 0; i< 30; i++)
            {
                var summary = new SummaryActivity(startLatlng: new LatLng(), endLatlng: new LatLng(),
                    type: ActivityType.Crossfit, movingTime: 60, athlete: new MetaAthlete(123), startDate: new DateTime(2019, 10, i+1), id: 9 + i);
                
                summary.StartLatlng.Add(30.0F);
                summary.StartLatlng.Add(40.0F);
                summary.EndLatlng.Add(30.0F);
                summary.EndLatlng.Add(40.0F);

                activities.Add(new VisualActivity(summary));
            }

            return activities;
        }
    }
}
