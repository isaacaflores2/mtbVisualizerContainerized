using MtbVisualizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mtbVisualizer.Services
{
    public interface ISummaryService
    {
        Task<IEnumerable<MonthSummaryActivity>> GetMonthSummaryActivities(string accessToken, int id);
    }
}
