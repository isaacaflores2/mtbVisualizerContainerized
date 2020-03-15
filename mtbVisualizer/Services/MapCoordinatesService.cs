using Microsoft.Extensions.Options;
using MtbVisualizer.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace mtbVisualizer.Services
{
    public class MapCoordinatesService : IMapCoordinatesService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettings> settings;
        private readonly string remoteServiceBaseUrl;

        public MapCoordinatesService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            this.httpClient = httpClient;
            this.settings = settings;

            remoteServiceBaseUrl = $"{this.settings.Value.MapUrl}/api/v1/map/";
        }

        public async Task<IEnumerable<ActivityCoordinates>> GetActivityCoordinates(string accessToken, int id)
        {
            var uri = $"{remoteServiceBaseUrl}coordinates/?id={id}&accessToken={accessToken}";

            var responseString = await httpClient.GetStringAsync(uri);

            var coordinates = JsonConvert.DeserializeObject<IEnumerable<ActivityCoordinates>>(responseString);

            return coordinates;
        }
    }
}
