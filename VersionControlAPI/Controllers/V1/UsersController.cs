using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VersionControlAPI.DTOs;

namespace VersionControlAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ApiTestURL = "https://dummyapi.io/data/v1/user?limit=30";
        private const string ApiTestID = "631e905c8f13d3051d72df80";
        private readonly HttpClient _httpClient;

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetUsersData")]
        public async Task<IActionResult> GetUsersDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", ApiTestID);
            var response = await _httpClient.GetStreamAsync(ApiTestURL);
            var usersData = await JsonSerializer.DeserializeAsync<UserResponseData>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(usersData);
        }
    }
}
