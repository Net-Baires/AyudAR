using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auth0
{

    public class TokenResponse {
        public string AccessToken { get; set; }
    }

    public class Auth0Settings
    {
        [JsonIgnore]
        public string BaseUrl { get; private set; }

        [JsonProperty("client_id")]
        public string ClientId { get; private set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }

        [JsonProperty("audience")]
        public string Audience { get; private set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; private set; }

        public static Auth0Settings FromEnvironmentVariables()
        {
            return new Auth0Settings
            {
                BaseUrl = Environment.GetEnvironmentVariable("AUTH0_BASEURL"),
                ClientId = Environment.GetEnvironmentVariable("AUTH0_CLIENTID"),
                ClientSecret = Environment.GetEnvironmentVariable("AUTH0_SECRET"),
                Audience = Environment.GetEnvironmentVariable("AUTH0_AUDIENCE"),
                GrantType = "client_credentials"
            };
        }
    }

    public class Auth0Api
    {
        private readonly TelemetryClient _telemetryClient;
        private readonly Auth0Settings _settings;

        public Auth0Api(TelemetryClient telemetryClient, Auth0Settings settings)
        {
            _telemetryClient = telemetryClient;
            _settings = settings;

        }

        private async Task<T> ExecuteAsync<T>(RestRequest req)
        {
            var client = new RestClient($"{_settings.BaseUrl}/oauth/token");
            var res = await client.ExecuteTaskAsync<T>(req);
            return res.Data;
        }

        public async Task<string> GetTokenAsync()
        {
            return await _telemetryClient.TrackDependencyAsync<string>("Auth0Client", "GetToken", async () =>
            {
                var req = new RestRequest(Method.POST);
                req.AddHeader("Content-Type", "application/json");
                req.AddParameter("application/json", JsonConvert.SerializeObject(_settings), ParameterType.RequestBody);
                var res = await this.ExecuteAsync<TokenResponse>(req);
                return res.AccessToken;
            });
        }
    }
}
