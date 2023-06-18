using Stud_io.StudyGroups.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class MicroservicesRequestService : IMicroservicesRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MicroservicesRequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetRequestAt(string uri)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJlYTc4OGYzMy1kNzlmLTQ2OTctYTQzMS1lMTFhMzkwZjIwZGIiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg3MTE1NzIwLCJleHAiOjE2ODc3MjA1MjAsImlhdCI6MTY4NzExNTcyMH0.n0ScQd79pm5zYxH7685o714sy9OU15FqnfZTylT1BZM");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var response = await httpClient.GetAsync(uri);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> PostRequestAt(string uri, List<string> studentIds)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJlYTc4OGYzMy1kNzlmLTQ2OTctYTQzMS1lMTFhMzkwZjIwZGIiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg3MTE1NzIwLCJleHAiOjE2ODc3MjA1MjAsImlhdCI6MTY4NzExNTcyMH0.n0ScQd79pm5zYxH7685o714sy9OU15FqnfZTylT1BZM");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent(JsonSerializer.Serialize(studentIds), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> PostRequestWithUrlOnly(string uri)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJlYTc4OGYzMy1kNzlmLTQ2OTctYTQzMS1lMTFhMzkwZjIwZGIiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg3MTE1NzIwLCJleHAiOjE2ODc3MjA1MjAsImlhdCI6MTY4NzExNTcyMH0.n0ScQd79pm5zYxH7685o714sy9OU15FqnfZTylT1BZM");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent("", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        //public async Task PostAt(string uri, )
    }
}
