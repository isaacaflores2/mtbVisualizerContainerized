using Microsoft.Extensions.Options;
using MtbVisualizer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mtbVisualizer.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettings> settings;
        private readonly string remoteServiceBaseUrl;

        public SummaryService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            this.httpClient = httpClient;
            this.settings = settings;

            remoteServiceBaseUrl = $"{this.settings.Value.SummaryUrl}/api/v1/summary/";
        }

        public async Task<IEnumerable<MonthSummaryActivity>> GetMonthSummaryActivities(string accessToken, int id, DateTime today)
        {
            var uri = $"{remoteServiceBaseUrl}month/?id={id}&accessToken={accessToken}&today={today}";

            var responseString = await httpClient.GetStringAsync(uri);

            var activities = JsonConvert.DeserializeObject<IEnumerable<MonthSummaryActivity>>(responseString);

            return activities;
        }
    }
}
