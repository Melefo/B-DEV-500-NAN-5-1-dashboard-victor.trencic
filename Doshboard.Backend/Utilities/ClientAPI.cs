using System.Net;

namespace Doshboard.Backend.Utilities
{
    public static class ClientAPI
    {
        private static HttpClient _client = new();

        public static async Task<T?> GetAsync<T>(string url, KeyValuePair<string, string> header = default)
        {
            if (!header.Equals(default))
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return default;
            if (response.StatusCode == HttpStatusCode.NoContent)
                return default;
            if (!header.Equals(default))
                _client.DefaultRequestHeaders.Remove(header.Key);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public static async Task<T?> PostAsync<T>(string url, KeyValuePair<string, string> header = default)
        {
            if (!header.Equals(default))
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            var response = await _client.PostAsync(url, null);

            if (!response.IsSuccessStatusCode)
                return default;
            if (response.StatusCode == HttpStatusCode.NoContent)
                return default;
            if (!header.Equals(default))
                _client.DefaultRequestHeaders.Remove(header.Key);
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
