using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ExtendSharp
{
    public partial class ExtendService
    {
        private readonly string _apiKey;

        public ExtendService(string baseUrl)
        {
            _baseUrl = baseUrl;

            _httpClient = new HttpClient();

            _settings = new System.Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    Error = HandleDeserializationError
                };
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            errorArgs.ErrorContext.Handled = true;
        }

        public ExtendService(string baseUrl, string apiKey) : this(baseUrl)
        {
            _apiKey = apiKey;
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            if (string.IsNullOrEmpty(_apiKey) || client.DefaultRequestHeaders.Contains("Authorization")) return;
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {_apiKey}");
        }

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }

        partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
        }
    }
}
