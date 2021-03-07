using AzureUMAPI.Interfaces;
using AzureUMAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureUMAPI.Services
{
    public class UserService : IUserService
    {
        private const string GraphUrl = "https://graph.microsoft.com/v1.0/";

        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UsersResponse> GetAllUsers(string token)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(GraphUrl + "users"),
                Method = HttpMethod.Get
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var response = await _httpClientFactory.CreateClient().SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsersResponse>(content);


        }
    }
}
