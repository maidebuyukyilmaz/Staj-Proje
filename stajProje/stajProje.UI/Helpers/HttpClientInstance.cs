

namespace stajProje.UI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient() {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7050/api/") // Ensure this is a valid and complete URI
            };
            return client;

        }
    }
}
