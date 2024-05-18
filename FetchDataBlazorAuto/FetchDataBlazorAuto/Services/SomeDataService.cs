using FetchDataBlazorAuto.Client.Services;

namespace FetchDataBlazorAuto.Services
{
    public class SomeDataService : ISomeDataService
    {
        public async Task<int[]> GetNumbersAsync()
        {
            Console.WriteLine("Main Project -> SomeDataService");
           return Enumerable.Range(1, 10).ToArray();
        }
    }
}
