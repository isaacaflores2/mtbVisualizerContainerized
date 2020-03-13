using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtbVisualizer.ViewModels
{
    public static class TableExtensions
    {
        public static string ToStringWithOptionalHours(this TimeSpan timeSpan)
        {

            string timeSpanText = string.Format(
            timeSpan.TotalHours >= 1 ? @"{0:h\:mm\:ss}" : @"{0:mm\:ss}", timeSpan);

            return timeSpanText;        
        }
    }
}
