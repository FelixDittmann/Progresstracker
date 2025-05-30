using Progresstracker.Application;

namespace Progresstracker.Adapter.Steam
{
    public class SteamSource : IDataSource
    {
        private readonly HttpClient _httpClient;

        public SteamSource(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void ConnectToDataSource(string url)
        {
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<string> GetData()
        {
            return await _httpClient.GetStringAsync(_httpClient.BaseAddress);
        }
    }
}
