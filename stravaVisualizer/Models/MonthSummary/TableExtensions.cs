using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaVisualizer.Models.MonthSummary
{
    public static class TableExtensions
    {
        public static string ToStringWithOptionalHours(this TimeSpan timeSpan)
        {

            string timeSpanText = string.Format(
            timeSpan.TotalHours >= 1 ? @"{0:h\:mm\:ss}" : @"{0:mm\:ss}", timeSpan);

            return timeSpanText;
            //var stringBuilder = new StringBuilder();

            //if ((int)timeSpan.TotalHours > 0)
            //{
            //    stringBuilder.Append((int)timeSpan.TotalHours);
            //    stringBuilder.Append(":");
            //}



            //stringBuilder.Append(timeSpan.Minutes.ToString("d2"));
            //if (timeSpan.Seconds < 10)
            //{
            //    stringBuilder.Append(":0");
            //}
            //else
            //{
            //    stringBuilder.Append(":");
            //}
            //stringBuilder.Append(timeSpan.Seconds.ToString("s"));

            //return stringBuilder.ToString();
        }
    }
}
