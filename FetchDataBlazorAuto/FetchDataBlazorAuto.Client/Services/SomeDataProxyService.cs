
using System.Net.Http.Json;

namespace FetchDataBlazorAuto.Client.Services
{
    public class SomeDataProxyService : ISomeDataService
    {
        private readonly HttpClient _httpClient;

        public SomeDataProxyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int[]> GetNumbersAsync()
        {
            Console.WriteLine("Client Project -> SomeDataProxyService");
            var numbers = await _httpClient.GetFromJsonAsync<int[]>("/api/fetch-data");
            return numbers;
        }
    }
}
