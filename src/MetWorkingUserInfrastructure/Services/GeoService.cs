using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using MetWorkingUserDomain.Interfaces;
using MetWorkingUserDomain.Models;

namespace MetWorkingUserInfrastructure.Services
{
    public class GeoService : IGeoService
    {
        private readonly HttpClient _httpClient;

        public GeoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Timeline>> GetUserTimeLine(Guid userId)
        {
            var httpResponse = await _httpClient.GetAsync($"timeline/{userId}");

            if (!httpResponse.IsSuccessStatusCode) return null;

            var readAsStringAsync = await httpResponse.Content.ReadAsStringAsync();
            var responseTimeLine = JsonSerializer.Deserialize<List<Timeline>>(readAsStringAsync);

            return responseTimeLine;
        }
    }
}