using BlazorServerApp.Domain.Models;

namespace BlazorServerApp.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/user";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAll(bool isOnline)
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>(_apiUrl + (isOnline ? string.Empty : "offline"));
            return users ?? new List<User>();
        }
    }
}
