using System.Net;

namespace Doshboard.Backend.Utilities
{
    public static class ClientAPI
    {
        private static HttpClient _client = new();

        public static async Task<T?> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return default;
            if (response.StatusCode == HttpStatusCode.NoContent)
                return default;
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public static async Task<T?> PostAsync<T>(string url)
        {
            var response = await _client.PostAsync(url, null);

            if (!response.IsSuccessStatusCode)
                return default;
            if (response.StatusCode == HttpStatusCode.NoContent)
                return default;
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
