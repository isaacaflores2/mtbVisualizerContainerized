using MtbVisualizer.Models.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtbVisualizer.Models.MonthSummary
{
    public class MonthSummary
    {
        public int Month { get; set; }
        public DateTime WeekStartDate { get; set; }
        public ICollection<VisualActivity> Activites { get; set; }


        public MonthSummary(DateTime today, IList<VisualActivity> visualActivities)
        {
            Month = today.Month;
            WeekStartDate = getCurrentWeekStartDate(today);
            Activites = getActivitiesForThisMonth(visualActivities);
        }

        public int getCurrentMonth()
        {
            return Month;
        }

        public static DateTime getCurrentWeekStartDate(DateTime today)
        {         
            var dayOfYear = today.Date.DayOfYear;
            var dayOfWeek = today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)today.DayOfWeek;
            var weekStartDayOfYear = dayOfYear - dayOfWeek;
            DateTime weekStartDate = new DateTime(today.Year, 1, 1).AddDays(weekStartDayOfYear);

            return weekStartDate;
        }

        public IList<VisualActivity> getActivitiesForThisMonth(ICollection<VisualActivity> visualActivities)
        {
            var activites = (from activity in visualActivities
                         where activity.Summary.StartDate.Value.Month == Month &&
                         activity.Summary.StartDate.Value.Year == WeekStartDate.Year
                         select activity).ToList();

            return activites;
        }

        public IList<VisualActivity> getActivitiesForThisWeek(ICollection<VisualActivity> visualActivities)
        {
           
            var activites = (from activity in visualActivities
                             where (activity.Summary.StartDate.Value.Date.DayOfYear >= WeekStartDate.DayOfYear) &&
                             (activity.Summary.StartDate.Value.Date.Day <= WeekStartDate.Day + 6)
                             select activity).ToList();

            return activites;
        }
    }
}
