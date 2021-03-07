using AzureUMAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureUMAPI.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;


        public AuthService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessToken()
        {
            string clientId = _config.GetValue<string>("ActiveDirectory:ClientId");
            string clientSecret = _config.GetValue<string>("ActiveDirectory:ClientSecret");
            string tenantId = _config.GetValue<string>("ActiveDirectory:TenantId");

            var content = new Dictionary<string, string>
            {
                { "client_id", clientId},
                { "scope", "https://graph.microsoft.com/.default" },
                { "client_secret", clientSecret },
                { "grant_type", "client_credentials" }
            };

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(content)
            };

            var response = await _httpClientFactory.CreateClient().SendAsync(request);
            var accessToken = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync()).access_token;

            return accessToken;
        }

     
      
    }
}
