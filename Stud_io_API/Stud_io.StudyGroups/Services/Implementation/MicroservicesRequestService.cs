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

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkZTI4ODI4My1lZTI5LTRiNzMtYjk1Ny1iZjIwNmNmMWE0YjQiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg1ODI4Njc0LCJleHAiOjE2ODY0MzM0NzQsImlhdCI6MTY4NTgyODY3NH0.45JHMBXwjfQcxAuWr1BYCZLogzmgFB2oVFdi6ThArKY");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var response = await httpClient.GetAsync(uri);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<string> PostRequestAt(string uri, List<string> studentIds)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkZTI4ODI4My1lZTI5LTRiNzMtYjk1Ny1iZjIwNmNmMWE0YjQiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg1ODI4Njc0LCJleHAiOjE2ODY0MzM0NzQsImlhdCI6MTY4NTgyODY3NH0.45JHMBXwjfQcxAuWr1BYCZLogzmgFB2oVFdi6ThArKY");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent(JsonSerializer.Serialize(studentIds), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        //public async Task PostAt(string uri, )
    }
}
