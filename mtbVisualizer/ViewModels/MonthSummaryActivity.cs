using System;
using System.Collections.Generic;
using System.Linq;

namespace MtbVisualizer.ViewModels
{
    public class MonthSummaryActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
        public int ElapsedTime { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }

        public static DateTime getCurrentWeekStartDate(DateTime today)
        {
            var dayOfYear = today.Date.DayOfYear;
            var dayOfWeek = today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)today.DayOfWeek;
            var weekStartDayOfYear = dayOfYear - dayOfWeek;
            DateTime weekStartDate = new DateTime(today.Year, 1, 1).AddDays(weekStartDayOfYear);

            return weekStartDate;
        }

        public static ICollection<MonthSummaryActivity> getActivitiesForThisWeek(ICollection<MonthSummaryActivity> monthSummaryActivity, DateTime today)
        {

            var WeekStartDate = getCurrentWeekStartDate(today);

            var activites = (from activity in monthSummaryActivity
                             where (activity.StartDate.Date.DayOfYear >= WeekStartDate.DayOfYear) &&
                             (activity.StartDate.Date.Day <= WeekStartDate.Day + 6)
                             select activity).ToList();

            return activites;
        }
    }
}
