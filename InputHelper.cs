
namespace AdventOfCode2024
{
    public class InputHelper
    {
        
        public static async Task<List<string>> FetchInputAsync(int day)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", $"session={GetSessionToken()}");
            string url = $"https://adventofcode.com/2024/day/{day}/input";
            Console.WriteLine($"Fetching URL: {url}");
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                Console.WriteLine($"HTTP Status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to fetch input: {response.StatusCode}\n{errorMessage}");
                }

                string content = await response.Content.ReadAsStringAsync();

                return new List<string>(content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching input for day {day}: {ex.Message}");
                throw;
            }
            
        }
        private static string GetSessionToken()
        {
            return Environment.GetEnvironmentVariable("ADVENT_SESSION_TOKEN");
        }
    }
}
